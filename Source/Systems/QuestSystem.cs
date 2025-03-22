using Source.Data.Quests;
using System.Collections.Generic;
using System.Linq;
using WCSharp.Api;
using static Source.Extensions.CommonExtensions;
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

                QuestMessage.DisplayQuestMessage(quest.PlayerOwner, QuestStatus.Getted, quest.GetTitle());
            }
        }
    }
}
