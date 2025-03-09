using Source.Triggers.ArenaTriggers.Triggers;
using Source.Triggers.Base;
using System.Collections.Generic;

namespace Source.Triggers.ArenaTriggers.Categories
{
    public class ArenaTriggersCategory : TriggerCategory
    {
        protected override IEnumerable<TriggerInstance> GetAllTriggers()
        {
            List<TriggerInstance> triggers = new List<TriggerInstance>();
            return triggers;
        }
    }
}
