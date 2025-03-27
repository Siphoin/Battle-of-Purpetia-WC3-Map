using Source.Triggers.Base;
using Source.Triggers.MainTriggers.Triggers;
using System.Collections.Generic;

namespace Source.Triggers.MainTriggers.Categories
{
    public class MainTriggersCategory : TriggerCategory
    {
        protected override IEnumerable<TriggerInstance> GetAllTriggers()
        {
           TriggerInstance[] triggers = new TriggerInstance[]
           {
               new MainTrigger(),
           };
            return triggers;
        }
    }
}
