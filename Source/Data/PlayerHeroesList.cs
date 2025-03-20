using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using WCSharp.Api;

namespace Source.Data
{
    public static class PlayerHeroesList
    {
        private static List<unit> _heroes = new();

        public static IEnumerable<unit> Heroes => _heroes;

        public static void Add (unit hero)
        {
            _heroes.Add(hero);
        }

        public static bool Contains (unit hero)
        {
            return _heroes.Contains(hero);
        }

        public static IEnumerable<unit> GetHeroesOwneringPlayers(IEnumerable<player> players)
        {
            return _heroes.Where(hero => players.Contains(hero.Owner));
        }

        public static unit GetLocalPlayerHero ()
        {
            if (!_heroes.Any(hero => hero.Owner == player.LocalPlayer))
            {
                return null;
            }
            return _heroes.Where(hero => hero.Owner == player.LocalPlayer).First();
        }
    }
}
