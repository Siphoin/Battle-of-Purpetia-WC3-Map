using Source.Data.Quests.TypesQuests;
using Source.Models;
using System.Collections.Generic;
using WCSharp.Api;
using static WCSharp.Api.Common;
namespace Source.Data.Quests.KillQuests
{
    public class MurlocKillQuest : KillUnitsQuestInstance
    {
        public override void Init()
        {
            base.Init();
            GoldReward = 300;


            ItemsRewards = new List<string>()
            {
                "phea",
                "manh",
            };
        }
        public MurlocKillQuest(player playerOwner) : base(playerOwner)
        {
        }

        public override string GetDescription()
        {
            return "Змеелюды неоднократно заявляли свои права на Пурпетию и каждый раз получали отказ. Тогда они поклялись завоевать её любой ценой! Любой... но не своей... В своем высокомерии они отправили на захват своих слуг, рыболюдов. Вы знали, что из них получаются отличные деликатесы? Их любит весь народ герцогства (и не только герцогства, но тсс)! Пора становится рыбаками и поварами! Вперед, на юго-западное озеро!";
        }

        public override string GetIconPath()
        {
            return string.Empty;
        }

        public override string GetTitle()
        {
            return "Ловись рыбка дохлая...";
        }

        public override bool IsRequired()
        {
            return true;
        }

        protected override Dictionary<string, int> GetRequiredUnits()
        {
            Dictionary<string, int> murlocList = new Dictionary<string, int>()
            {
               {"nmrr", 4 },
               {"nmrl", 10 },
               {"nmpg", 1 }
            };

            return murlocList;
        }

        protected override player GetTargetPlayer()
        {
            return MapConfig.MonsterPlayer;
        }
    }
}
