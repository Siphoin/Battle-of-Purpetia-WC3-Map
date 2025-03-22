using Source.Data.Quests.TypesQuests;
using Source.Models;
using System.Collections.Generic;
using WCSharp.Api;

namespace Source.Data.Quests.KillQuests
{
    public class SouthUndeadNPCQuest : KillUnitsQuestInstance
    {
        public SouthUndeadNPCQuest(player playerOwner) : base(playerOwner)
        {
        }

        public override void Init()
        {
            base.Init();
            GoldReward = 572;
        }


        public override string GetDescription()
        {
            return " Южнее города Беспокойникова Культ Анархии готовит армию до жути голодной нежити. Разговоры здесь излишне: встретьте \"гостей\" как подобает \"гостеприимным хозяевам\". ";
        }

        public override string GetIconPath()
        {
            return string.Empty;
        }

        public override string GetTitle()
        {
            return "Выдать \"хлеб\" с \"солью\"";
        }

        public override bool IsRequired()
        {
            return true;
        }

        protected override Dictionary<string, int> GetRequiredUnits()
        {
            Dictionary<string, int> undeads = new Dictionary<string, int>()
            {
               {"ugho", 3 },
               {"uabo", 2 },
               {"nzom", 8 }
            };

            return undeads;
        }

        protected override player GetTargetPlayer()
        {
            return MapConfig.MonsterPlayer;
        }
    }
}
