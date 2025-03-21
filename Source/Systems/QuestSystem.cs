using Source.Data.Quests;
using System.Collections.Generic;
using System.Linq;
namespace Source.Systems
{
    public static class QuestSystem
    {
        private static List<QuestInstance> _quests = new();

        public static IEnumerable<QuestInstance> Quests => _quests;

        public static void RegisterQuest (QuestInstance quest)
        {        
            if (!_quests.Any(x => x.GetTitle() == quest.GetTitle()))
            {
                quest.Init();
                quest.GetTrigger();
                _quests.Add(quest);
            }
        }
    }
}
