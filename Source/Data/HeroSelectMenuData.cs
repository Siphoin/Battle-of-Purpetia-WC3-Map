using static WCSharp.Api.Common;
namespace Source.Data
{
    public struct HeroSelectMenuData
    {
        public string HeroId { get; set; }
        public HeroSelectMenuData(string heroId)
        {
            HeroId = heroId;
        }

        public int GetTypeIdUnit ()
        {
            return FourCC(HeroId);
        }
    }
}
