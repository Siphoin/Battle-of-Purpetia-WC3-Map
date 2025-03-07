using WCSharp.Api;
using static WCSharp.Api.Common;
namespace Source.Models
{
    public static class MapConfig
    {
        public static player MonsterPlayer => player.NeutralAggressive;
        public static float DelayRespawnMonster => 5;

        public static int GetRandomOrderAttackAI ()
        {
            int value = GetRandomInt(2, 6);
            return value;
        }
    }
}
