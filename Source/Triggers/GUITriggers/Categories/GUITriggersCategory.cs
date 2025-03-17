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
            CustomConsoleUITrigger customConsoleUITrigger = new CustomConsoleUITrigger();
            CustomMinimapGUITrigger customMinimapGUITrigger = new CustomMinimapGUITrigger();
            TurnOffStandardGUITrigger turnOffStandardGUITrigger = new();
            CustomUnitStatsGUITrigger customUnitStatsGUITrigger = new();
            triggers.Add(customConsoleUITrigger);
            triggers.Add(turnOffStandardGUITrigger);
            triggers.Add(customMinimapGUITrigger);
            triggers.Add(customUnitStatsGUITrigger);
            return triggers;
        }
    }
}
