using Source.Models;
using Source.Triggers.Base;
using System;
using WCSharp.Api;
using static WCSharp.Api.Common;
namespace Source.Triggers.MainTriggers.Triggers
{
    public class MainTrigger : TriggerInstance
    {
        public override trigger GetTrigger()
        {
            trigger trigger = trigger.Create();
            trigger.AddAction(Main);
            return trigger;
        }

        private void Main()
        {
            InitPurpetiaAliance();
            InvertyionColorsPlayers();
        }

        private void InitPurpetiaAliance()
        {
            for (int i = 0; i < player.MaxPlayerSlots; i++)
            {
                var player = Player(i);

                if (player == player.NeutralAggressive ||
                    player == player.NeutralPassive ||
                    player == player.NeutralVictim ||
                    player == player.NeutralExtra ||
                    player == MapConfig.DungeonPlayer ||
                    player == MapConfig.MonsterPlayer || player == MapConfig.PurpetiaPlayer)
                {
                    continue;
                }

                SetPlayerAlliance(player, MapConfig.PurpetiaPlayer, alliancetype.Passive, true);
                SetPlayerAlliance(MapConfig.PurpetiaPlayer, player, alliancetype.Passive, true);
            }
        }

        private void InvertyionColorsPlayers ()
        {
            MapConfig.PurpetiaPlayer.Color = playercolor.Purple;
            Player(4).Color = playercolor.Violet;
        }
    }
}
