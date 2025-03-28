﻿using Source.Data;
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
        private static sound _soundItemReward;
        public static void AddItems (player player, IEnumerable<item> items)
        {
            if (_soundItemReward is null)
            {
                _soundItemReward = CreateSoundFromLabel("ItemReward", false, false, false, 10000, 10000);
            }

            var hero = PlayerHeroesList.Heroes.Where(x => x.Owner == player).First();
            bool isPausewdHero = hero.IsPaused;
            if (isPausewdHero)
            {
                PauseUnit(hero, false);
            }
            StringBuilder message = new();
            message.AppendLine("Получены новые предметы!".Colorize(YELOOW_TEXT_HEX));

            foreach (var item in items)
            {
                message.AppendLine(item.Name.Colorize(GREEN_TEXT_HEX));
                UnitAddItem(hero, item);
            }

            DisplayTextToPlayer(player, 0, 0, message.ToString());
            PlaySound(_soundItemReward);

            if (isPausewdHero)
            {
                PauseUnitWithStand(hero);
            }

           
        }
    }
}
