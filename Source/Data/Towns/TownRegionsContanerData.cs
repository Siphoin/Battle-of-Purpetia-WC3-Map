using System.Collections.Generic;
using WCSharp.Shared.Data;

namespace Source.Data.Towns
{
    public static class TownRegionsContanerData
    {
        public static IEnumerable<Rectangle> GetRegions ()
        {
            Rectangle[] regions = new Rectangle[]
            {
                Regions.NoViolanceAreaTown1,
                Regions.NoViolanceAreaTown2,
            };

            return regions;
        }
    }
}
