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
    public class ReaniCemetery : DungeonInstance
    {
        private DungeonData _data;

        public override trigger GetTrigger()
        {
            trigger trigger = trigger.Create();
            trigger.AddAction(() =>
            {
                GetDungeonData();
            });
            return trigger;
        }

        protected override IEnumerable<Rectangle> GetRegionsGuards()
        {
            return new List<Rectangle>
            {
                    Regions.Dungeon1RegionGuards1,
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
                    

            }; 
        }

        protected override IEnumerable<Rectangle> GetRegionsMiniBosses()
        {
            return new List<Rectangle>
            {
                Regions.Dungeon1RegionBossLich,
                Regions.Dungeon1RegionBossDeathKnight,
            };
        }

        protected override Rectangle GetRegionFinallBoss()
        {
            return Regions.Dungeon1BossRegionFinalBoss;
        }

        protected override string GetDungeonName()
        {
            return "Кладбище Резни";
        }

        protected override void SetupGates()
        {
            // FIRST stage
            List<Rectangle> regionsFirstGates = new List<Rectangle>
            {
                Regions.Dungeon1RegionGuards1,
                Regions.Dungeon1RegionGuards2,
                Regions.Dungeon1RegionGuards3,
                
            };

            var stage = Regions.Dungeon1RegionGate1;
            group groupGuards = group.Create();
            foreach (Rectangle region in regionsFirstGates)
            {
                group group = group.Create();
                GroupEnumUnitsInRect(group, region.Rect, null);

                foreach (var unit in group.ToList())
                {
                    groupGuards.Add(unit);
                }

                DestroyGroup(group);
            }

            ListenStage(groupGuards, stage);

            List<Rectangle> regionSecondsGates = new List<Rectangle>
            {
                Regions.Dungeon1RegionGuards4,
                Regions.Dungeon1RegionGuards5,
                Regions.Dungeon1RegionGuards6,

            };

            stage = Regions.Dungeon1RegionGate2;
            groupGuards = group.Create();
            foreach (Rectangle region in regionSecondsGates)
            {
                group group = group.Create();
                GroupEnumUnitsInRect(group, region.Rect, null);

                foreach (var unit in group.ToList())
                {
                    groupGuards.Add(unit);
                }

                DestroyGroup(group);
            }

            ListenStage(groupGuards, stage);

            List<Rectangle> regionBossLich = new List<Rectangle>
            {
                Regions.Dungeon1RegionBossLich,

            };

            stage = Regions.Dungeon1RegionGate3;
            groupGuards = group.Create();
            foreach (Rectangle region in regionBossLich)
            {
                group group = group.Create();
                GroupEnumUnitsInRect(group, region.Rect, null);

                foreach (var unit in group.ToList())
                {
                    groupGuards.Add(unit);
                }

                DestroyGroup(group);
            }

            ListenStage(groupGuards, stage);

            List<Rectangle> regionThreeGates = new List<Rectangle>
            {
                Regions.Dungeon1RegionGuards7,

            };

            stage = Regions.Dungeon1RegionGate5;
            groupGuards = group.Create();
            foreach (Rectangle region in regionThreeGates)
            {
                group group = group.Create();
                GroupEnumUnitsInRect(group, region.Rect, null);

                foreach (var unit in group.ToList())
                {
                    groupGuards.Add(unit);
                }

                DestroyGroup(group);
            }

            ListenStage(groupGuards, stage);

            base.SetupGates();
        }
    }
}
