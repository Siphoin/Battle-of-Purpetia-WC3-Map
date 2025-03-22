using Source.Data.Quests;
using System;
using System.Collections.Generic;
using System.Linq;
using WCSharp.Api;
using static Source.Extensions.CommonExtensions;
namespace Source.Systems
{
    public static class QuestSystem
    {
        private static List<QuestInstance> _quests = new();

        public static event Action<QuestInstance, QuestStatus> OnQuestStatusChanged;

        public static void CallEventQuestStatus (QuestInstance instance, QuestStatus questStatus)
        {
            OnQuestStatusChanged?.Invoke(instance, questStatus);
        }

        public static void RegisterQuest (QuestInstance quest)
        {        
                quest.Init();
                quest.GetTrigger();
            _quests.Add(quest);

            QuestMessage.DisplayQuestMessage(quest.PlayerOwner, QuestStatus.Getted, quest.GetTitle());
            }
        
    }
}
