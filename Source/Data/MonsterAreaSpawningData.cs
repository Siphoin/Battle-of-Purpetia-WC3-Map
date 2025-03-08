using System;
using System.Collections.Generic;
using WCSharp.Shared.Data;

namespace Source.Data
{
    public struct MonsterAreaSpawningData
    {

        public Dictionary<string, int> MonstersList { get; set; }

        public Rectangle Region { get; set; }
        public int Level { get ; set; }

        public MonsterAreaSpawningData(Dictionary<string, int> monstersList, Rectangle region, int level)
        {
            MonstersList = monstersList;
            Region = region;
            Level = level;

        }
    }

}
