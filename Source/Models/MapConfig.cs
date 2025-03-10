using WCSharp.Api;
using static WCSharp.Api.Common;
namespace Source.Models
{
    public static class MapConfig
    {
        public static player MonsterPlayer => Player(11);
        public static float DelayRespawnMonster => 15;
        public const string DEFAULT_PATH_TEXTURE_FULL_HEALTH = "hero_bar_fill_hitPoints.blp";
        public const float NeedHeroXPFormulaA = 1;
        public const float NeedHeroXPFormulaB = 100;
        public const float NeedHeroXPFormulaC = 0;

        public static float CalculateRequiredXP(int level)
        {

            float xp = 200; // Опыт для уровня 1

            // Вычисляем опыт для каждого уровня, начиная с 2
            for (int i = 2; i <= level; i++)
            {
                xp = NeedHeroXPFormulaA * xp + NeedHeroXPFormulaB * i + NeedHeroXPFormulaC;
            }

            return xp;
        }

    }
}
