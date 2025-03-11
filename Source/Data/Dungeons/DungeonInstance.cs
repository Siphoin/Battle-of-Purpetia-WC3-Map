
using Source.Models;
using Source.Triggers.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using WCSharp.Api;
using WCSharp.Events;
using WCSharp.Shared.Data;
using WCSharp.Shared.Extensions;
using static WCSharp.Api.Common;
namespace Source.Data.Dungeons
{
    public abstract class DungeonInstance : TriggerInstance
    {
        private DungeonData _data;

        protected abstract IEnumerable<Rectangle> GetRegionsGuards();
        protected abstract IEnumerable<Rectangle> GetRegionsMiniBosses();
        protected abstract string GetDungeonName();
        protected abstract Rectangle GetRegionFinallBoss();

        public DungeonData GetDungeonData()
        {
            if (_data is null)
            {
                _data = new();

                SetupGuards();
                SetupMiniBosses();
                SetupFinalBoss();
            }

            return _data;

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
                    _data.FinalBoss = unit;
                    break;
                }
            }

            DestroyGroup(group);
            PlayerUnitEvents.Register(UnitEvent.Dies, RestoreDungeon, _data.FinalBoss);
#if DEBUG
            Console.WriteLine($"dungeon setup final boss: {_data.FinalBoss.Name}");
#endif


        }

        private void RestoreDungeon()
        {
#if DEBUG
            Console.WriteLine("Dungeon Completed");
#endif
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
                _data.Bosses.Add(region, bossData);

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
                    PlayerUnitEvents.Register(UnitEvent.Dies, OnGuardDie, unit);


                }
                _data.Guards.Add(group, guards);

            }

#if DEBUG
            Console.WriteLine($"dungeon setup guards: {GetDungeonName()}");
#endif
        }

        private void RestoreGuards()
        {
            foreach (var guardsData in _data.Guards)
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
                    PlayerUnitEvents.Register(UnitEvent.Dies, OnGuardDie, newUnit);
                    newUnit.DefaultAcquireRange = MapConfig.DefaultAcquireRange;
                    group.Add(newUnit);
                }


            }
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

        #region Events
        private void OnGuardDie()
        {
        }
        #endregion

    }

}
