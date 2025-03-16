using System.Collections.Generic;
using System.Linq;
using Source.Data.Dungeons;
using Source.Triggers.DungeonsTriggers.Triggers;
using WCSharp.Api;

namespace Source.Systems
{
    public static class DungeonsSystem
    {
        
        private static List<DungeonInstance> _dungeons = new();
        private static Dictionary<DungeonInstance, DungeonRoomData> _notStartedRooms = new();
        private static List<DungeonInstance> _activeDungeons = new();

        public static void RegisterDungeon (DungeonInstance dungeonInstance)
        {
            _dungeons.Add(dungeonInstance);
            var enterRegion = dungeonInstance.GetEnterRegion();
            DungeonRoomZoneTrigger trigger = new DungeonRoomZoneTrigger(dungeonInstance, enterRegion);
            trigger.GetTrigger();

        }

        public static void TurnDungeon (int index)
        {
            var dungeon = _dungeons[index];
            dungeon.Start();
            _activeDungeons.Add(dungeon);
            _notStartedRooms.Remove(dungeon);
        }

        public static void TurnDungeon(DungeonInstance instance)
        {
            var dungeon = _dungeons.IndexOf(instance);
            TurnDungeon(dungeon);
        }

        public static void EndDungeon(DungeonInstance dungeonInstance)
        {
            if (_activeDungeons.Contains(dungeonInstance))
            {
                _activeDungeons.Remove(dungeonInstance);
            }
        }

        public static bool JoinDungeon (DungeonInstance dungeon, player player)
        {
            if (_activeDungeons.Contains(dungeon))
            {
                return false;
            }
            if (_notStartedRooms.TryGetValue(dungeon, out var roomData))
            {
                roomData.AddPlayer(player);
            }

            else
            {
                DungeonRoomData newRoom = new(dungeon, player);
                _notStartedRooms.Add(dungeon, newRoom);
            }

            return true;
        }


    }
}
