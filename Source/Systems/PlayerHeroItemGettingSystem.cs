using Source.Data;
using Source.Extensions;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WCSharp.Api;
using static WCSharp.Api.Common;
using static Source.Extensions.CommonExtensions;
namespace Source.Systems
{
    public static class PlayerHeroItemGettingSystem
    {
        public static void AddItems (player player, IEnumerable<item> items)
        {
            var hero = PlayerHeroesList.Heroes.Where(x => x.Owner == player).First();
            StringBuilder message = new();
            message.AppendLine("Получены новые предметы!".Colorize(YELOOW_TEXT_HEX));

            foreach (var item in items)
            {
                message.AppendLine(item.Name.Colorize(GREEN_TEXT_HEX));
                UnitAddItem(hero, item);
            }

            DisplayTextToPlayer(player, 0, 0, message.ToString());

           
        }
    }
}
