using Source.Data.Quests;
using System.Collections.Generic;
using System.Linq;
using WCSharp.Api;
namespace Source.Systems
{
    public static class QuestSystem
    {
        private static Dictionary<player, List<QuestInstance>> _quests = new();

        public static IEnumerable<QuestInstance> GetQuestsByPlayer (player player)
        {
            if (!_quests.TryGetValue(player, out var instance))
            {
                return Enumerable.Empty<QuestInstance>();
            }

            return instance;
        }

        public static void RegisterQuest (QuestInstance quest)
        {        
            if (!_quests.Any(x => x.Value.Contains(quest)))
            {
                quest.Init();
                quest.GetTrigger();

                if (_quests.TryGetValue(quest.PlayerOwner, out var quests))
                {
                    quests.Add(quest);
                }

                else
                {
                    List<QuestInstance> newQuestList = new List<QuestInstance>()
                    {
                        quest,
                    };

                    _quests.Add(quest.PlayerOwner, quests);
                }
            }
        }
    }
}
