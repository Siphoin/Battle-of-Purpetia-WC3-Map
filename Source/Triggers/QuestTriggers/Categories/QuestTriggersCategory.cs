using Source.Triggers.Base;
using Source.Triggers.QuestTriggers.Triggers;
using System.Collections.Generic;

namespace Source.Triggers.QuestTriggers.Categories
{
    public class QuestTriggersCategory : TriggerCategory
    {
        protected override IEnumerable<TriggerInstance> GetAllTriggers()
        {
            List<TriggerInstance> triggers = new List<TriggerInstance>()
            {
                new GetStartQuestTrigger(), 
            };
            return triggers;
        }
    }
}
