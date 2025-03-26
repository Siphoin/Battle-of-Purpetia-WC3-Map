using Source.Data.Quests;
using System;
using System.Collections.Generic;
using static Source.Extensions.CommonExtensions;
namespace Source.Systems
{
    public static class QuestSystem
    {
        private static List<QuestInstance> _quests = new();

        public static IEnumerable<QuestInstance> Quests => _quests;

        public static event Action<QuestInstance, QuestStatus> OnQuestStatusChanged;

        public static void CallEventQuestStatus (QuestInstance instance, QuestStatus questStatus)
        {
            OnQuestStatusChanged?.Invoke(instance, questStatus);
        }

#if DEBUG
        public static void SetCompleteQuestStatus_Debug(int index)
        {
            try
            {
                var instance = _quests[index];
                instance.MarkIsCompleted_Debug(true);
            }
            catch
            {

                throw;
            }
        }
#endif

        public static void RegisterQuest (QuestInstance quest)
        {        
                quest.Init();
                quest.GetTrigger();
            _quests.Add(quest);

            QuestMessage.DisplayQuestMessage(quest.PlayerOwner, QuestStatus.Getted, quest.GetTitle());
            }
        
    }
}
