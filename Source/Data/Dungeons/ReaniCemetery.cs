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
    }
}
