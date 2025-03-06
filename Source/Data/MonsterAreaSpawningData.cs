using System;
using System.Collections.Generic;
using WCSharp.Shared.Data;

namespace Source.Data
{
    [Serializable]
    public struct MonsterAreaSpawningData
    {

        public Dictionary<string, int> MonstersList { get; set; }

        public Rectangle Region { get; set; }

        public MonsterAreaSpawningData(Dictionary<string, int> monstersList, Rectangle region)
        {
            MonstersList = monstersList;
            Region = region;
        }
    }

}
