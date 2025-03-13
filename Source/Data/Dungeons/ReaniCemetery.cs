using System.Collections.Generic;
using System.Linq;
using WCSharp.Api;
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
            var stages = new List<(List<Rectangle> guardRegions, Rectangle gateRegion)>
    {
        (new List<Rectangle> { Regions.Dungeon1RegionGuards1, Regions.Dungeon1RegionGuards2, 
            Regions.Dungeon1RegionGuards3 }, 
            Regions.Dungeon1RegionGate1),
        (new List<Rectangle> { Regions.Dungeon1RegionGuards4, Regions.Dungeon1RegionGuards5, 
            Regions.Dungeon1RegionGuards6 }, Regions.Dungeon1RegionGate2),
        (new List<Rectangle> { Regions.Dungeon1RegionBossLich }, Regions.Dungeon1RegionGate3),
        (new List<Rectangle> { Regions.Dungeon1RegionGuards7 }, Regions.Dungeon1RegionGate5),
        (new List<Rectangle> { Regions.Dungeon1RegionGuards8 }, Regions.Dungeon1RegionGate10),
        (new List<Rectangle> { Regions.Dungeon1RegionBossDeathKnight }, Regions.Dungeon1RegionGate7),
        (new List<Rectangle> { Regions.Dungeon1RegionGuards9 }, Regions.Dungeon1RegionGate8),
        (new List<Rectangle> { Regions.Dungeon1RegionGuards10 }, Regions.Dungeon1RegionGate9),
        (new List<Rectangle> { Regions.Dungeon1RegionGuards11 }, Regions.Dungeon1RegionFinalGate)
    };

            foreach (var stage in stages)
            {
                SetupStage(stage.guardRegions, stage.gateRegion);
            }

            base.SetupGates();
        }
        protected override Rectangle GetEnterRegion()
        {
            return Regions.Dungeon1EnterRegion;
        }

        protected override int GetRequiredLevelHero()
        {
            return 15;
        }

        protected override Queue<Rectangle> GetAIQueueRegions()
        {
            Rectangle[] regions = new Rectangle[]
            {
                Regions.Dungeon1RegionGuards1,
                Regions.Dungeon1RegionGuards2,
                Regions.Dungeon1RegionGuards3,
                Regions.Dungeon1RegionGuards4,
                Regions.Dungeon1RegionGuards5,
                Regions.Dungeon1RegionGuards6,
                Regions.Dungeon1RegionBossLich,
                Regions.Dungeon1RegionGuards7,
                Regions.Dungeon1RegionGuards8,
                Regions.Dungeon1RegionBossDeathKnight,
                Regions.Dungeon1RegionGuards9,
                Regions.Dungeon1RegionGuards10,
                Regions.Dungeon1RegionGuards11,
                Regions.Dungeon1BossRegionFinalBoss

            };
            Queue<Rectangle> queue = new Queue<Rectangle>();

            foreach (var region in regions)
            {
                queue.Enqueue(region);
            }

            return queue;
        }
    }
}
