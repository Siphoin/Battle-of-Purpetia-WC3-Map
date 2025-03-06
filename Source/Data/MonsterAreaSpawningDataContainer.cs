using System.Collections.Generic;

namespace Source.Data
{
    public static class MonsterAreaSpawningDataContainer
    {
        public static IEnumerable<MonsterAreaSpawningData> GetData ()
        {
            MonsterAreaSpawningData[] data = new MonsterAreaSpawningData[]
            {
                new ()
                {
                    MonstersList = new()
                    {
                        {"ugho", 5 },
                        {"uabo", 2 }

                    },
                    Region = Regions.RegionUndeadSpawn
                }
            };

            return data;
        }
    }
}
