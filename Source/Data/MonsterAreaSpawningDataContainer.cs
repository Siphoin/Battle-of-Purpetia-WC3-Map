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
                        {"uabo", 2 },
                        {"nzom", 6 }
                        

                    },
                    Region = Regions.RegionUndeadSpawn
                },

                new ()
                {
                    MonstersList = new()
                    {
                        {"nmrr", 8 },
                        {"nmrl", 2 },
                        {"nmpg", 6 }


                    },
                    Region = Regions.RegionMurlocSpawn
                }
            };

            return data;
        }
    }
}
