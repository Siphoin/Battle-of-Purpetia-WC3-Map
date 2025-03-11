using System.Collections.Generic;
using WCSharp.Api;
using WCSharp.Shared.Data;

namespace Source.Data.Dungeons
{
    public class DungeonData
    {
        public Dictionary<group, List<DungeonGuardData>> Guards { get; set; }
        public Dictionary<Rectangle, List<BossData>> Bosses { get; set; }
        public unit FinalBoss {  get; set; }
        public Dictionary<Rectangle, destructable> Gates { get; set; }

        public DungeonData()
        {
            Guards = new();
            Bosses = new();
            Gates = new();
        }

    }
}
