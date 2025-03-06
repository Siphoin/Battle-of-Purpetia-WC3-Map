using Source.Data;
using Source.Models;
using Source.Triggers.Base;
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

        private Dictionary<string, int> MonstersList { get; set; }

        private Dictionary<int, int> MonstersListCached { get; set; }

        private Rectangle Rectangle { get; set; }


        public MonsterAreaSpawnTrigger(MonsterAreaSpawningData monsterAreaSpawningData)
        {
            MonstersList = monsterAreaSpawningData.MonstersList;
            Rectangle = monsterAreaSpawningData.Region;
            MonstersListCached = new();
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

            if (!MonstersListCached.TryGetValue(FourCC(unitType), out int count))
            {
                MonstersListCached.Add(FourCC(unitType), 1);
            }

            else
            {
                MonstersListCached[FourCC(unitType)] = count + 1;
            }

            PlayerUnitEvents.Register(UnitEvent.Dies, () => MonsterDie(newUnit), newUnit);

#if DEBUG
            Console.WriteLine($"cached new unit monster: {newUnit.Name} current Count: {MonstersListCached[FourCC(unitType)]}");
#endif
        }

        private void MonsterDie(unit unit)
        {
#if DEBUG
            Console.WriteLine($"respawn new unit monster: {unit.Name}");
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
        }
    }
}
