using Source.Extensions;
using WCSharp.Api;
using static WCSharp.Api.Common;
namespace Source.Systems
{
    public static class PlayerResourcesSystem
    {
        public static void AddGold (player whichPlayer, int amount)
        {
            var currentGold = GetPlayerState(whichPlayer, playerstate.ResourceGold);
            int result = currentGold + amount;
            SetPlayerState(whichPlayer, playerstate.ResourceGold, result);

            if (amount > 0)
            {
                string prefix = "Золото получено:".Colorize("#f5ec42");
                DisplayTextToPlayer(whichPlayer, 0, 0, $"{prefix} Вы получили золото в размере {amount}");
            }

        }

        public static void DecrementGold(player whichPlayer, int amount)
        {
            var currentGold = GetPlayerState(whichPlayer, playerstate.ResourceGold);
            int result = currentGold - amount;
            if (result < 0)
            {
                result = 0;
            }
            SetPlayerState(whichPlayer, playerstate.ResourceGold, result);

        }

        public static void AddWood(player whichPlayer, int amount)
        {
            var currentWood = GetPlayerState(whichPlayer, playerstate.ResourceLumber);
            int result = currentWood + amount;
            SetPlayerState(whichPlayer, playerstate.ResourceLumber, result);

        }

        public static void DecrementWood(player whichPlayer, int amount)
        {
            var currentWood = GetPlayerState(whichPlayer, playerstate.ResourceLumber);
            int result = currentWood - amount;
            if (result < 0)
            {
                result = 0;
            }
            SetPlayerState(whichPlayer, playerstate.ResourceLumber, result);

        }
    }
}
