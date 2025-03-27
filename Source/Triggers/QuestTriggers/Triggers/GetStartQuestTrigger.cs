using Source.Data;
using Source.Data.Quests.EnterRegionQuests;
using Source.Systems;
using Source.Triggers.Base;
using System.Linq;
using WCSharp.Api;
using static WCSharp.Api.Common;
namespace Source.Triggers.QuestTriggers.Triggers
{
    public class GetStartQuestTrigger : TriggerInstance
    {
        private timer _timer;

        public override trigger GetTrigger()
        {
            _timer = timer.Create();
            TimerStart(_timer, 6, true, AddFirstQuest);
            return trigger.Create();
        }

        private void AddFirstQuest()
        {
            if (PlayerHeroesList.GetLocalPlayerHero() is null)
            {
                return;
            }

            var currentQuests = QuestSystem.Quests;

            if (!currentQuests.Any())
            {
                Hicks_EnterRegionQuest hicks_EnterRegionQuest = new(player.LocalPlayer);
                QuestSystem.RegisterQuest(hicks_EnterRegionQuest);
                DestroyTimer(_timer);
            }

            else
            {
                DestroyTimer(_timer);
            }
        }
    }
}
