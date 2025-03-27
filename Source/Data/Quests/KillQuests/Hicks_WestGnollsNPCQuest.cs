using Source.Data.Quests.TypesQuests;
using Source.Models;
using System.Collections.Generic;
using WCSharp.Api;

namespace Source.Data.Quests.KillQuests
{
    public class Hicks_WestGnollsNPCQuest : KillUnitsQuestInstance
    {
        public Hicks_WestGnollsNPCQuest(player playerOwner) : base(playerOwner)
        {
        }

        public override void Init()
        {
            base.Init();
            GoldReward = 600;
            ItemsRewards = new List<string>()
            {
                "rde3",
            };
        }


        public override string GetDescription()
        {
            return "О жадности гноллов ходят легенды... и анекдоты... Хотите один? Так вот: приходят к западному лесу, где живут гноллы, культисты с горой золота и говорят, мол, вы нападете на город, а мы вам за это отдадим все свое добро, разумеется с платой вперед. Ну гноллы и согласились, решились напасть на нас. За это жители натравили на этих жадных собак авантюристов, которым пообещали более солидную сумму, но по выполнению задания. Ну они пришли, всех гноллов убили, ограбили, еще сверху получили! Ха-ха-ха! Че не смеётесь? Не смешно? Это Блекрия!";
        }

        public override string GetIconPath()
        {
            return string.Empty;
        }

        public override string GetTitle()
        {
            return "\"Собачья алчность\"";
        }

        public override bool IsRequired()
        {
            return true;
        }

        protected override Dictionary<string, int> GetRequiredUnits()
        {
            Dictionary<string, int> gnolls = new Dictionary<string, int>()
            {
              {"ngno", 11 },
              {"ngnw", 4 },
            };

            return gnolls;
        }

        protected override player GetTargetPlayer()
        {
            return MapConfig.MonsterPlayer;
        }
    }
}
