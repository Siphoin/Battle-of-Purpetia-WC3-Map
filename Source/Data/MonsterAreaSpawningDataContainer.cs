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

                new ()
                {
                    MonstersList = new()
                    {
                        {"nchg", 15 },
                        {"nchw", 7 },
                        {"nchr", 5 },


                    },
                    Region = Regions.RegionFelOrcsSpawn,
                    Level = 3
                },

                new ()
                {
                    MonstersList = new()
                    {
                        {"ngh1", 5 },
                        {"ngh2", 5 },


                    },
                    Region = Regions.RegionGhostsSpawn,
                    Level = 2
                },

                new ()
                {
                    MonstersList = new()
                    {
                        {"ngno", 7 },
                        {"ngnw", 2 },
                        {"ngnv", 3 },
                        {"ngnb", 1 },


                    },
                    Region = Regions.RegionGnollSpawn,
                    Level = 3
                },

                new ()
                {
                    MonstersList = new()
                    {
                        {"nban", 2 },
                        {"nbrg", 2 },
                        {"nrog", 1 },
                        {"nass", 2 },
                        {"nenf", 3 },
                        {"nwiz", 2 },
                        {"nwzr", 1 },


                    },
                    Region = Regions.RegionBanditsSpawn,
                    Level = 4
                },

                new ()
                {
                    MonstersList = new()
                    {
                        {"nenc", 5 },
                        {"nenp", 4 },
                        {"nepl", 2 },


                    },
                    Region = Regions.RegionTreantsSpawn,
                    Level = 5
                },

               new ()
                {
                    MonstersList = new()
                    {
                        {"nsty", 20 },
                        {"nsat", 4 },
                        {"nsts", 2 },
                        {"nsth", 1 },

                    },
                    Region = Regions.RegionSatyrSpawn,
                    Level = 7
                },

            };

            return data;
        }
    }
}
