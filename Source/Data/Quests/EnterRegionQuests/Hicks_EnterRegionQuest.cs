using Source.Data.Quests.TypesQuests;
using WCSharp.Api;

namespace Source.Data.Quests.EnterRegionQuests
{
    public class Hicks_EnterRegionQuest : EnterRegionNPCQuestInstance
    {
        
        public Hicks_EnterRegionQuest(player playerOwner) : base(playerOwner)
        {
        }

        public override void Init()
        {
            base.Init();
            GoldReward = 50;
        }

        public override string GetDescription()
        {
            return "Встретьтесь с Хиксом Мутным.";
        }

        public override string GetIconPath()
        {
            return string.Empty;
        }


        public override string GetTitle()
        {
            return "Встретьтесь с Хиксом Мутным";
        }

        public override bool IsRequired()
        {
            return true;
        }

        protected override region GetEnterRegion()
        {
            return Regions.QuestNPCCityGoblin.Region;
        }
    }
}
