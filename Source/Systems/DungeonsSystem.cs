using System.Collections.Generic;
using Source.Data.Dungeons;

namespace Source.Systems
{
    public static class DungeonsSystem
    {
        
        private static List<DungeonInstance> _dungeons = new();

        public static void RegisterDungeon (DungeonInstance dungeonInstance)
        {
            _dungeons.Add(dungeonInstance);
        }

        public static void TurnDungeon (int index)
        {
            var dungeon = _dungeons[index];
            dungeon.Start();
        }
    }
}
