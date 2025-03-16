using System;
using System.Collections.Generic;
using WCSharp.Api;

namespace Source.Data.Dungeons
{
    public class DungeonRoomData
    {

        public DungeonInstance TargetDungeon { get; private set; }
        private List<player> Players { get; set; }
        public event Action<player> OnAddPlayer;
        public event Action<player> OnLeavePlayer;

        public DungeonRoomData(DungeonInstance targetDungeon, player firstPlayer)
        {
            TargetDungeon = targetDungeon;
            Players = new()
            {
                firstPlayer
            };
        }

        public void AddPlayer(player player)
        {
            if (!Players.Contains(player))
            {
                Players.Add(player);
                OnAddPlayer?.Invoke(player);
            }
        }

        public void LeavePlayer(player player)
        {
            if (Players.Contains(player))
            {
                Players.Remove(player);
                OnLeavePlayer?.Invoke(player);
            }
        }
    }
}
