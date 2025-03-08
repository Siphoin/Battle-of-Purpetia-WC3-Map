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
                    Region = Regions.RegionUndeadSpawn,
                    Level = 1
                },

                new ()
                {
                    MonstersList = new()
                    {
                        {"nmrr", 8 },
                        {"nmrl", 2 },
                        {"nmpg", 6 }


                    },
                    Region = Regions.RegionMurlocSpawn,
                    Level = 1
                },

               new ()
                {
                    MonstersList = new()
                    {
                        {"uske", 3 },
                        {"nzom", 5 },
                        {"unec", 4 }


                    },
                    Region = Regions.RegionUndeadSpawnZombieMore,
                    Level = 5
                },

                new ()
                {
                    MonstersList = new()
                    {
                        {"ninf", 5 },
                        {"nfgu", 7 },
                        {"nerd", 3 },


                    },
                    Region = Regions.RegionUndeadSpawnDemons,
                    Level = 8
                },

            };

            return data;
        }
    }
}
