using Source.Systems;
using Source.Triggers.Base;
using WCSharp.Api;
using static Source.Extensions.CommonExtensions;
using static WCSharp.Api.Common;
namespace Source.Triggers.DebugTriggers.Triggers
{
    public class QuestCompleteDebugTrigger : TriggerInstance
    {
        public override trigger GetTrigger()
        {
            trigger debugTrigger = trigger.Create();
            debugTrigger.RegisterPlayerChatEvent(Player(0), "QuestComplete", false);
#if DEBUG
            debugTrigger.AddAction(() =>
            {
                var message = GetEventPlayerChatString();
                var parts = message.Split(' ');

                if (parts.Length > 1 && int.TryParse(parts[1], out int questNumber))
                {
                    QuestSystem.SetCompleteQuestStatus_Debug(questNumber - 1);
                }
            });
#endif
            return debugTrigger;
        }
    }
}
