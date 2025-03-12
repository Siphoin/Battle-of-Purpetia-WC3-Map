using System.Collections.Generic;
using WCSharp.Api;

namespace Source.Data.Dungeons
{
    public class BossData
    {
        public unit Boss {  get; set; }
        public int Face { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        public List<DungeonGuardData> Guards { get; set; }
    }
}
