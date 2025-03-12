using System.Collections.Generic;
using WCSharp.Api;
using WCSharp.Shared.Data;

namespace Source.Data.Dungeons
{
    public class DungeonData
    {
        public Rectangle EnterRegion { get; set; }
        public Dictionary<group, List<DungeonGuardData>> Guards { get; set; }
        public Dictionary<Rectangle, BossData> Bosses { get; set; }
        public unit FinalBoss {  get; set; }
        public Dictionary<group, Rectangle> Stages { get; set; }

        public DungeonData()
        {
            Guards = new();
            Bosses = new();
            Stages = new();
        }

    }
}
