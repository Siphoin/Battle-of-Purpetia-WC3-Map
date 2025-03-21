using Source.Data;
using Source.Models;
using Source.Triggers.Base;
using Source.Triggers.HeroTriggers;
using System;
using System.Collections.Generic;
using System.Linq;
using WCSharp.Api;
using WCSharp.Events;
using WCSharp.Shared.Data;
using static WCSharp.Api.Common;
namespace Source.Triggers.MonsterAreaSystem.Triggers
{
    public class MonsterAreaSpawnTrigger : TriggerInstance
    {
        public static event Action<unit, unit, item> OnDropItem;
        private static int _currentForce = -4;
        private const int MULTIPLIER_FORCE_PER_LEVEL_PLAYER = 5;
        private const int IMFERNAL_TIME_DIE = 250;

        private Dictionary<string, int> MonstersList { get; set; }

        private Dictionary<int, int> MonstersListCached { get; set; }

        private Rectangle Rectangle { get; set; }


        public MonsterAreaSpawnTrigger(MonsterAreaSpawningData monsterAreaSpawningData)
        {
            MonstersList = monsterAreaSpawningData.MonstersList;
            Rectangle = monsterAreaSpawningData.Region;
            MonstersListCached = new();
        }

        private void OnHeroNewLevel()
        {
            _currentForce++;
        }

        public override trigger GetTrigger()
        {
            var newTrigger = trigger.Create();
            newTrigger.AddAction(SpawnStart);
            return newTrigger;
        }

        private void SpawnStart ()
        {
            for (int i = 0; i < player.Count; i++)
            {
                trigger triggerLevelUpHero = trigger.Create();
                triggerLevelUpHero.RegisterPlayerUnitEvent(Player(i), EVENT_PLAYER_HERO_LEVEL);
                triggerLevelUpHero.AddAction(OnHeroNewLevel);
            }
            int countUnits = 0;

            foreach (var monster in MonstersList)
            {
                countUnits += monster.Value;
            }

            for (int i = 0; i < countUnits; i++)
            {
                SpawnRandomUnit();
            }
        }

        private void SpawnRandomUnit ()
        {
            var unitIndex = GetRandomInt(0, MonstersList.Count - 1);
            SpawnUnit(unitIndex);
        }

        private void SpawnUnit(int unitIndex)
        {
            var unitType = MonstersList.ElementAt(unitIndex).Key;
            var randomAngle = GetRandomInt(0, 270);
            var position = Rectangle.GetRandomPoint();

            var newUnit = unit.Create(MapConfig.MonsterPlayer, FourCC(unitType), position.X, position.Y, randomAngle);
            newUnit.CanSleep = true;

            if (!MonstersListCached.TryGetValue(FourCC(unitType), out int count))
            {
                MonstersListCached.Add(FourCC(unitType), 1);
            }

            else
            {
                MonstersListCached[FourCC(unitType)] = count + 1;
            }

            CalculatePowerUnit(newUnit);

            PlayerUnitEvents.Register(UnitEvent.Dies, () => MonsterDie(newUnit), newUnit);
            InfernalTimeDie(newUnit);
        }

        private void MonsterDie(unit unit)
        {
#if DEBUG
            Console.WriteLine($"respawn new unit monster");
#endif
            PlayerUnitEvents.Unregister(UnitEvent.Dies, () => MonsterDie(unit), unit);
            if (!MonstersListCached.TryGetValue(GetUnitTypeId(unit), out int count))
            {
                MonstersListCached.Add(GetUnitTypeId(unit), 1);
            }

            else
            {
                MonstersListCached[GetUnitTypeId(unit)] = count - 1;
            }
            trigger respawnTrigger = trigger.Create();
            respawnTrigger.AddAction(() =>
            {
                var timer = CreateTimer();
                TimerStart(timer, MapConfig.DelayRespawnMonster, false, () =>
                {
                    DestroyTimer(timer);

                    SpawnRandomUnit();

                    respawnTrigger.Dispose();
                });
            });

            respawnTrigger.Execute();
            DropItem();
        }

        private void DropItem()
        {
            var killedUnit = GetDyingUnit();
            var killer = GetKillingUnit();
            var chance = GetRandomReal(0, 500);

            if (chance >= 450)
            {
                var itemId = ChooseRandomItem(killedUnit.Level - 1);
                var item = CreateItem(itemId, killedUnit.X, killedUnit.Y);
                UnitAddItem(killedUnit, item);

                OnDropItem?.Invoke(killer, killedUnit, item);
            }
        }

        private void CalculatePowerUnit (unit unit)
        {
            if (_currentForce < 2)
            {
                return;
            }

            int addLife = ((int)unit.Life * 3 / 100) * _currentForce;
            unit.GoldBountyAwardedBase += 5;
            unit.MaxLife += addLife;
            unit.Life = unit.MaxLife;
            
        }

        #region SpecialEvents
        private void InfernalTimeDie (unit unit)
        {
            if (GetUnitTypeId(unit) != FourCC("ninf"))
            {
                return;
            }
            Console.WriteLine("Infernal die activated");
            trigger triggerDie = trigger.Create();
            triggerDie.AddAction(() =>
            {
                var t = CreateTimer();
                TimerStart(t, IMFERNAL_TIME_DIE, false, () =>
                {
                    DestroyTimer(t);
                    unit.Kill();
                    DestroyTrigger(triggerDie);

#if DEBUG
                    Console.WriteLine("Infernal die finished");
#endif
                });
            });

            triggerDie.Execute();
        }
        #endregion
    }
}
