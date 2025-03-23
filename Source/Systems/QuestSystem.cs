using Source.Data.Quests;
using System;
using System.Collections.Generic;
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

        public static void CallEventQuestStatus(int index, QuestStatus questStatus)
        {
            try
            {
                var instance = _quests[index];
                CallEventQuestStatus(instance, questStatus);
            }
            catch
            {

                throw;
            }
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
