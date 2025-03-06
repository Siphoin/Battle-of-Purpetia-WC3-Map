using WCSharp.Api;
using static WCSharp.Api.Common;
namespace Source.Models
{
    public static class MapConfig
    {
        public static player MonsterPlayer => Player(11);
        public static float DelayRespawnMonster => 5;
    }
}
