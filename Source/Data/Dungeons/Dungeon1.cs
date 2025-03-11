using Source.Models;
using Source.Triggers.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCSharp.Api;
using WCSharp.Events;
using WCSharp.Shared.Data;
using WCSharp.Shared.Extensions;
using static WCSharp.Api.Common;
namespace Source.Data.Dungeons
{
    public class Dungeon1 : DungeonInstance
    {
        private DungeonData _data;

        public override DungeonData GetDungeonData()
        {
            trigger dungeonKillGuardsTrigger = trigger.Create();

            if (_data is null)
            {
                _data = new();
                

                var _regionsGuards = new List<Rectangle>
                {
                    Regions.Dungeon1RegionGuards1,
                    /*
                    Regions.Dungeon1RegionGuards2,
                    Regions.Dungeon1RegionGuards3,
                    Regions.Dungeon1RegionGuards4,
                    Regions.Dungeon1RegionGuards5,
                    Regions.Dungeon1RegionGuards6,
                    Regions.Dungeon1RegionGuards7,
                    Regions.Dungeon1RegionGuards8,
                    Regions.Dungeon1RegionGuards9,
                    Regions.Dungeon1RegionGuards10,
                    Regions.Dungeon1RegionGuards11,
                    */

                };

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
                        guardData = new();
                        guardData.IDGuard = GetUnitTypeId(unit);
                        guardData.X = unit.X;
                        guardData.Y = unit.Y;
                        guardData.Face = unit.Facing;
                        guards.Add(guardData);
                        PlayerUnitEvents.Register(UnitEvent.Dies, OnGuardDie, unit);


                    }
                    Console.WriteLine($"ADD GUARDS DUNGEON1 {guards.Count}");
                    _data.Guards.Add(group, guards);

                }
            }

            return _data;

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

        private void OnGuardDie ()
        {
            var triggerUnit = GetTriggerUnit();
            PlayerUnitEvents.Unregister(UnitEvent.Dies, OnGuardDie, triggerUnit);
           int index = 0;
            foreach (var guard in _data.Guards)
            {
                var group = guard.Key.ToList();
                var guards = guard.Value.ToList();
                index = 0;
                if (group.All(x => !x.Alive))
                {
                    foreach (var unit in group.ToList())
                    {
                        int id = guards[index].IDGuard;
                        float face = guards[index].Face;
                        float x = guards[index].X;
                        float y = guards[index].Y;
                        var newUnit = unit.Create(MapConfig.DungeonPlayer, id, x, y, face);
                        PlayerUnitEvents.Register(UnitEvent.Dies, OnGuardDie, newUnit);
                        index++;
                    }
                }
            }
        }

        
    }
}
