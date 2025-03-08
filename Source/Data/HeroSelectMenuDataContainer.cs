using System.Collections.Generic;
using System.Linq;
using static WCSharp.Api.Common;
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

        public static HeroSelectMenuData GetDataByIdUnit (int id)
        {
            return GetHeroSelectButtons().Single(x => FourCC(x.IconPath) == id);
        }
    }
}
