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
                    IconPath = "ReplaceableTextures/CommandButtons/BTNHeroPaladin.blp",
                    HeroId = "H000:Harf"
                },

                                new HeroSelectMenuData
                {
                    IconPath = "ReplaceableTextures/CommandButtons/BTNHeroPaladin.blp",
                    HeroId = "H000:Harf"
                },

                                                new HeroSelectMenuData
                {
                    IconPath = "ReplaceableTextures/CommandButtons/BTNHeroPaladin.blp",
                    HeroId = "H000:Harf"
                },
            };

            return heroes;
        }
    }
}
