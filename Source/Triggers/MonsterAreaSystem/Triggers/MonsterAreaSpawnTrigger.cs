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
        public static event Action<unit, item> OnDropItem;
        private static int _currentForce = -1;
        private const int MULTIPLIER_FORCE_PER_LEVEL_PLAYER = 5;
        private Dictionary<string, int> MonstersList { get; set; }

        private Dictionary<int, int> MonstersListCached { get; set; }

        private Rectangle Rectangle { get; set; }


        public MonsterAreaSpawnTrigger(MonsterAreaSpawningData monsterAreaSpawningData)
        {
            MonstersList = monsterAreaSpawningData.MonstersList;
            Rectangle = monsterAreaSpawningData.Region;
            MonstersListCached = new();
            HeroSpawnTrigger.OnHeroNewLevel += HeroSpawnTrigger_OnHeroNewLevel;
        }

        private void HeroSpawnTrigger_OnHeroNewLevel(unit unit)
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
        }

        private void MonsterDie(unit unit)
        {
#if DEBUG
            Console.WriteLine($"respawn new unit monster");
#endif
            PlayerUnitEvents.Unregister(UnitEvent.Dies, () => MonsterDie(unit), unit);
            DropItem(unit);
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
        }

        private void DropItem(unit unit)
        {
            var chance = GetRandomReal(0, 500);

            if (chance >= 50)
            {
                var itemId = ChooseRandomItem(unit.Level - 1);
                var item = CreateItem(itemId, unit.X, unit.Y);
                UnitAddItem(unit, item);

                OnDropItem?.Invoke(unit, item);
            }
        }

        private void CalculatePowerUnit (unit unit)
        {
            if (_currentForce < 2)
            {
                return;
            }

            int addLife = ((int)unit.Life * 10 / 100) * _currentForce;
            var addDamage = (unit.AttackBaseDamage1 * 10 / 100) * _currentForce;
            unit.AttackBaseDamage1 += addDamage;
            unit.AttackBaseDamage2 += addDamage;
            unit.GoldBountyAwardedBase += _currentForce;
            unit.MaxLife += addLife;
            unit.Life = unit.MaxLife;
        }
    }
}
