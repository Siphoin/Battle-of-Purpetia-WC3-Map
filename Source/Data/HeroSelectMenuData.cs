using static WCSharp.Api.Common;
namespace Source.Data
{
    public struct HeroSelectMenuData
    {
        public HeroSelectMenuData(string heroId, string iconPath)
        {
            HeroId = heroId;
            IconPath = iconPath;
        }

        public string HeroId { get;  set; }
        public string IconPath { get; set; }

        public int GetTypeIdUnit ()
        {
            return FourCC(HeroId);
        }
    }
}
