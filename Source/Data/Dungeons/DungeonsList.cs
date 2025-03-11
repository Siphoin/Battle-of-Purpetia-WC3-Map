using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Source.Data.Dungeons
{
    public static class DungeonsList
    {
        private static bool _isInit = false;
        private static List<DungeonData> _dungeons;

        public static IEnumerable<DungeonData> GetAllDungeons ()
        {
            if (!_isInit)
            {
                _dungeons = new();
                _isInit = true;
            }

            return _dungeons;
        }
    }
}
