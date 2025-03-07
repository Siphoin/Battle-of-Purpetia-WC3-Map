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
                    IconPath = "ReplaceableTextures/CommandButtons/BTNArthas.blp",
                    HeroId = "H000:Harf"
                },

               new HeroSelectMenuData
                {
                    IconPath = "ReplaceableTextures/CommandButtons/BTNHeroArchMage.blp",
                    HeroId = "H001:Hamg"
                },

                new HeroSelectMenuData
                {
                    IconPath = "ReplaceableTextures/CommandButtons/BTNHeroDreadLord.blp",
                    HeroId = "VHer:Udre"
                },

                new HeroSelectMenuData
                {
                    IconPath = "ReplaceableTextures/CommandButtons/BTNHeroBlademaster.blp",
                    HeroId = "O000:Obla"
                },
            };

            return heroes;
        }
    }
}
