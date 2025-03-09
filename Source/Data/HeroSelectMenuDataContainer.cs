using System.Collections.Generic;
namespace Source.Data
{
    public static class HeroSelectMenuDataContainer
    {
        public static IEnumerable<HeroSelectMenuData> GetHeroSelectButtons ()
        {
            HeroSelectMenuData[] heroes =
            {
                new HeroSelectMenuData
                {
                    HeroId = "H000:Harf",
                },

               new HeroSelectMenuData
                {
                    HeroId = "H001:Hamg",
                },

                new HeroSelectMenuData
                {
                    HeroId = "VHer:Udre",
                },

                new HeroSelectMenuData
                {
                    HeroId = "O000:Obla",
                },
            };

            return heroes;
        }
    }
}
