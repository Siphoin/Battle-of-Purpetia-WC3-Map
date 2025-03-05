using WCSharp.Api;
using static WCSharp.Api.Common;
namespace Source.Models
{
    public static class MapConfig
    {
        public static player EnemyPlayerWave => Player(11);
        public static float DelayNewWave => 2;
    }
}
