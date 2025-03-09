using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}
