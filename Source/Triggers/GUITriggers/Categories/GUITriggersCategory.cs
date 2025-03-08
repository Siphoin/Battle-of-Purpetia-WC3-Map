using Source.Triggers.Base;
using Source.Triggers.GUITriggers.Triggers;
using System.Collections.Generic;

namespace Source.Triggers.GUITriggers.Categories
{
    public class GUITriggersCategory : TriggerCategory
    {
        protected override IEnumerable<TriggerInstance> GetAllTriggers()
        {
            List<TriggerInstance> triggers = new List<TriggerInstance>();
            CustomMinimapGUITrigger customMinimapGUITrigger = new CustomMinimapGUITrigger();
            TurnOffStandardGUITrigger turnOffStandardGUITrigger = new();
            triggers.Add(turnOffStandardGUITrigger);
            triggers.Add(customMinimapGUITrigger);
            return triggers;
        }
    }
}
