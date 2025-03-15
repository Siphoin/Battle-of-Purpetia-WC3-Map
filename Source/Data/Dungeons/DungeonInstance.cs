
using Source.Models;
using Source.Triggers.ArenaTriggers.Triggers;
using Source.Triggers.Base;
using Source.Triggers.GUITriggers.Triggers;
using Source.Triggers.HeroTriggers;
using System;
using System.Collections.Generic;
using System.Linq;
using WCSharp.Api;
using WCSharp.Events;
using WCSharp.Shared;
using WCSharp.Shared.Data;
using WCSharp.Shared.Extensions;
using static WCSharp.Api.Common;
namespace Source.Data.Dungeons
{
    public abstract class DungeonInstance : TriggerInstance
    {
        private List<destructable> _walls = new();
        

        protected DungeonData Data { get; set; }

        protected int ID_BLOCK_WALL_STAGE_1 => FourCC("Dofw");
        protected int ID_BLOCK_WALL_STAGE_2 => FourCC("Dofv");
        private PeriodicTrigger<PeriodcCommandAIAttack> _periodicAICommandTrigger;
        private Rectangle _currentTargetAIRegion;
        private Queue<Rectangle> _queueAIRegions = new();
        private PeriodcCommandAIAttack _periodicAICommandAIAttack;
        private readonly alliancetype[] alliancetypes = new alliancetype[]
        {
            alliancetype.Passive,
            alliancetype.SharedVision,
            alliancetype.HelpRequest,
            alliancetype.HelpResponse,
            alliancetype.SharedSpells
        };

        protected abstract IEnumerable<Rectangle> GetRegionsGuards();
        protected abstract IEnumerable<Rectangle> GetRegionsMiniBosses();
        protected abstract Rectangle GetEnterRegion();
        protected abstract int GetRequiredLevelHero();
        protected abstract Queue<Rectangle> GetAIQueueRegions();

        protected abstract void CreateGates();

        protected virtual void SetupGates()
        {
#if DEBUG
            Console.WriteLine($"dungeon setup gates: {Data.Stages.Count}");
#endif
        }

        protected void SetupStage(List<Rectangle> guardRegions, Rectangle gateRegion)
        {
            var groupGuards = group.Create();
            foreach (var region in guardRegions)
            {
                var tempGroup = group.Create();
                GroupEnumUnitsInRect(tempGroup, region.Rect, null);

                foreach (var unit in tempGroup.ToList())
                {
                    groupGuards.Add(unit);
                }

                DestroyGroup(tempGroup);
            }

            _queueAIRegions.Enqueue(gateRegion);

            ListenStage(groupGuards, gateRegion);
        }

        public void Start ()
        {
            var heroes = PlayerHeroesList.Heroes.Where(x => x.Alive);
            var startRegion = GetEnterRegion();
            var uniqueOwners = new HashSet<int>(); // Используем HashSet для хранения уникальных идентификаторов владельцев
            foreach (var hero in heroes)
            {

                var point = startRegion.GetRandomPoint();
                hero.X = point.X;
                hero.Y = point.Y;
                uniqueOwners.Add(hero.Owner.Id);

#if DEBUG
                if (hero.HeroLevel < GetRequiredLevelHero())
                {
                    hero.HeroLevel = GetRequiredLevelHero();
                }
#endif
                if (hero.Owner != player.LocalPlayer)
                {
                    GUIHeroWidgetTrigger widgetHero = new(hero);
                    widgetHero.GetTrigger().Execute();
                }
                var regionBoss = GetRegionFinallBoss().Center;
                if (AIHeroTrigger.ContainsHero(hero))
                {
                    Console.WriteLine("contains");
                    var ai = AIHeroTrigger.GetAI(hero);
                    ai.CoomandsEnabled = false;
                    ai.MainTimer.Pause();
                    ai.TimerCheckHealth.Pause();
                    IssuePointOrder(hero, "attack", regionBoss.X, regionBoss.Y);
                }
            }

            var ownerList = uniqueOwners.ToList();
            for (int i = 0; i < ownerList.Count; i++)
            {
                for (int j = i + 1; j < ownerList.Count; j++)
                {
                    for (int k = 0; k < alliancetypes.Length; k++)
                    {
                        SetPlayerAlliance(Player(ownerList[i]), Player(ownerList[j]), alliancetypes[k], true); // Делаем их союзниками
                        SetPlayerAlliance(Player(ownerList[j]), Player(ownerList[i]), alliancetypes[k], true); // Делаем их союзниками
                    }

                }
            }
            _currentTargetAIRegion = _queueAIRegions.Dequeue();

            _periodicAICommandAIAttack = new(CheckCommandAI);
            _periodicAICommandTrigger = new(0.5f);
            _periodicAICommandTrigger.Add(_periodicAICommandAIAttack);

            ArenaTrigger.StopTickingNewArena();


        }
        protected abstract string GetDungeonName();
        protected abstract Rectangle GetRegionFinallBoss();

        public DungeonData GetDungeonData()
        {
            if (Data is null)
            {
                Data = new();

                SetupGuards();
                SetupMiniBosses();
                SetupFinalBoss();
                SetupGates();
                SetupEnterRegion();
                CreateGates();
            }

            

            return Data;

        }

        private void SetupEnterRegion()
        {
            Data.EnterRegion = GetEnterRegion();
        }

        private void SetupFinalBoss()
        {
            var region = GetRegionFinallBoss();
            group group = group.Create();
            GroupEnumUnitsInRect(group, region.Rect, null);

            foreach (var unit in group.ToList())
            {
                if (!string.IsNullOrEmpty(unit.HeroName))
                {
                    Data.FinalBoss = unit;
                    break;
                }
            }

            DestroyGroup(group);
            PlayerUnitEvents.Register(UnitEvent.Dies, RestoreDungeon, Data.FinalBoss);
#if DEBUG
            Console.WriteLine($"dungeon setup final boss: {Data.FinalBoss.Name}");
#endif


        }

        private void RestoreDungeon()
        {
            trigger triggerRestartDungeon = trigger.Create();
            triggerRestartDungeon.AddAction(() =>
            {
                
                var heroes = PlayerHeroesList.Heroes.Where(x => x.Alive);

                foreach (var hero in heroes)
                {
                    hero.Life = hero.MaxLife;
                    hero.Mana = hero.MaxMana;
                    var regionTown = Regions.HeroSpawn.GetRandomPoint();
                    hero.X = regionTown.X;
                    hero.Y = regionTown.Y;
                }

                
                RestartDungeon();
                DestroyTrigger(triggerRestartDungeon);

                ArenaTrigger.ContinueTickingNewArena();
            });

            triggerRestartDungeon.Execute();
        }

        private void RestartDungeon()
        {
            timer timerRestart = timer.Create();
            timerdialog timerdialog = CreateTimerDialog(timerRestart);
            TimerDialogDisplay(timerdialog, true);
            timerdialog.SetTitle(GetDungeonName());

            timerRestart.Start(MapConfig.DelayRespawnDungeon, false, () =>
            {
                RestoreGuards();
                RestoreBosses();
                RestoreFinalBoss();
                TimerDialogDisplay(timerdialog, false);
                DestroyTimerDialog(timerdialog);
                DestroyTimer(timerRestart);
            });
        }

        private void SetupMiniBosses()
        {
            var regionsBosses = GetRegionsMiniBosses();

            foreach (var region in regionsBosses)
            {
                BossData bossData = new();
                group group = group.Create();
                GroupEnumUnitsInRect(group, region.Rect, null);
                List<DungeonGuardData> guards = new();
                bool bossIsSelected = false;
                foreach (var unit in group.ToList())
                {
                    if (!string.IsNullOrEmpty(unit.HeroName) && !bossIsSelected)
                    {
                        bossIsSelected = true;
                        bossData.Boss = unit;
                    }

                    else
                    {
                        DungeonGuardData guard = new(unit);
                        guards.Add(guard);
                    }
                }

                bossData.Guards = guards;
                Data.Bosses.Add(region, bossData);

            }

#if DEBUG
            Console.WriteLine($"dungeon setup mini bosses: {GetDungeonName()}");
#endif
        }

        private void SetupGuards()
        {
            var _regionsGuards = GetRegionsGuards();

            List<group> _groupsGuards = new();

            foreach (var region in _regionsGuards)
            {
                group newGroup = group.Create();
                GroupEnumUnitsInRect(newGroup, region.Rect, null);
                _groupsGuards.Add(newGroup);
            }

            List<DungeonGuardData> guards = new List<DungeonGuardData>();
            DungeonGuardData guardData = new DungeonGuardData();
            foreach (var group in _groupsGuards.ToList())
            {
                guards = new();
                foreach (var unit in group.ToList())
                {
                    guardData = new(unit);
                    guards.Add(guardData);


                }
                Data.Guards.Add(group, guards);

            }

#if DEBUG
            Console.WriteLine($"dungeon setup guards: {GetDungeonName()}");
#endif
        }

        private void RestoreGuards()
        {
            foreach (var guardsData in Data.Guards)
            {
                var group = guardsData.Key;
                var guards = guardsData.Value.ToList();
                group.Clear();
                for (int i = 0; i < guards.Count; i++)
                {
                    int id = guards[i].IDGuard;
                    float face = guards[i].Face;
                    float x = guards[i].X;
                    float y = guards[i].Y;
                    var newUnit = unit.Create(MapConfig.DungeonPlayer, id, x, y, face);
                    newUnit.DefaultAcquireRange = MapConfig.DefaultAcquireRange;
                    group.Add(newUnit);
                }


            }
        }

        private void RestoreBosses()
        {
            foreach (var boss in Data.Bosses)
            {
                var region = boss.Key;
                var bossData = boss.Value;

                foreach (var guardData in bossData.Guards)
                {
                    int id = guardData.IDGuard;
                    float face = guardData.Face;
                    float x = guardData.X;
                    float y = guardData.Y;
                    var newUnit = unit.Create(MapConfig.DungeonPlayer, id, x, y, face);
                    newUnit.DefaultAcquireRange = MapConfig.DefaultAcquireRange;



                }

                var bossUnit = bossData.Boss;
                var newBoss = unit.Create(MapConfig.DungeonPlayer, bossUnit.UnitType, bossUnit.X, bossUnit.Y, bossUnit.Facing);
                newBoss.HeroLevel = bossData.Boss.HeroLevel;
                RemoveUnit(bossUnit);
                bossData.Boss = newBoss;
            }

        }

        private void RestoreFinalBoss()
        {

            var regionBoss = GetRegionFinallBoss();
            unit finalBoss = unit.Create(MapConfig.DungeonPlayer, Data.FinalBoss.UnitType, regionBoss.Center.X, regionBoss.Center.Y, Data.FinalBoss.Facing);
            finalBoss.HeroLevel = Data.FinalBoss.HeroLevel;
            RemoveUnit(Data.FinalBoss);
            Data.FinalBoss = finalBoss;
        }

        public override trigger GetTrigger()
        {
            trigger trigger = trigger.Create();
            trigger.AddAction(() =>
            {
                GetDungeonData();
            });
            return trigger;
        }
        protected void ListenStage(group group, Rectangle stage)
        {
            foreach (var unit in group.ToList())
            {
                PlayerUnitEvents.Register(UnitEvent.Dies, CheckGroupGateStatus, unit);
            }
            Data.Stages.Add(group, stage);

#if DEBUG
            Console.WriteLine("LISTEN GATE");
#endif
        }

        private void CheckGroupGateStatus()
        {
            bool isRemoving = false;
            group targetGroup = null;
            Rectangle targetStage = null;
            var unit = GetTriggerUnit();
            PlayerUnitEvents.Unregister(UnitEvent.Dies, CheckGroupGateStatus, unit);
            foreach (var gateData in Data.Stages)
            {
                group group = gateData.Key;
                var gate = gateData.Value;

                if (group.Contains(unit))
                {
                    if (group.ToList().All(x => !x.Alive))
                    {
#if DEBUG
                        isRemoving = true;
                        targetGroup = group;
                        targetStage = gate;
#endif
                        break;
                    }
                }
            }

            if (isRemoving)
            {
                EnumDestructablesInRect(targetStage.Rect, null, () =>
                {
                    if (GetEnumDestructable().Type == ID_BLOCK_WALL_STAGE_1 || GetEnumDestructable().Type == ID_BLOCK_WALL_STAGE_2)
                    {
                        _currentTargetAIRegion = _queueAIRegions.Dequeue();
                        Console.WriteLine("Next Stage");
                        GetEnumDestructable().Kill();
                    }
                });
            }
        }

        private void CheckCommandAI ()
        {
            var heroes = PlayerHeroesList.Heroes.Where(x => AIHeroTrigger.ContainsHero(x));
            Rectangle targetRegion = _currentTargetAIRegion; 
            foreach (var hero in heroes)
            {

    var ai = AIHeroTrigger.GetAI(hero);
                var currentOrder = GetUnitCurrentOrder(hero);
                if (currentOrder != Constants.ORDER_ATTACK && currentOrder != Constants.ORDER_MOVE && currentOrder != Constants.ORDER_STAND_DOWN)
                {
                    ai.CoomandsEnabled = false;
                    ai.MainTimer.Pause();
                    ai.TimerCheckHealth.Pause();
                    IssuePointOrder(hero, "attack", targetRegion.Center.X, targetRegion.Center.Y);
                }
            }
        }

        

    }

    public class DungwonStage
    {

        public IEnumerable<Rectangle> GuardsRegion { get; private set; }
        public Rectangle GateRegion { get; private set; }

        public DungwonStage(IEnumerable<Rectangle> guardsRegion, Rectangle gateRegion)
        {
            GuardsRegion = guardsRegion;
            GateRegion = gateRegion;
        }
    }

    public class PeriodcCommandAIAttack : IPeriodicAction
    {
        public bool Active { get; set; } = true;
        public Action CommabdAction { get; set; }

        public PeriodcCommandAIAttack(Action updateStatsAction)
        {
            CommabdAction = updateStatsAction;
        }

        public void Action()
        {
            CommabdAction?.Invoke();
        }
    }

}
