using Source.Triggers.Base;
using Source.Triggers.TownTriggers.Triggers;
using System.Collections.Generic;

namespace Source.Triggers.TownTriggers.Categories
{
    public class TownTriggersCategory : TriggerCategory
    {
        protected override IEnumerable<TriggerInstance> GetAllTriggers()
        {
            List<TriggerInstance> triggers = new List<TriggerInstance>();
            NoViolanceAreaTownTriggerOff noViolanceAreaTownTriggerOff = new();
            NoViolanceAreaTownTriggerOn noViolanceAreaTownTriggerOn = new();
            triggers.Add(noViolanceAreaTownTriggerOff);
            triggers.Add(noViolanceAreaTownTriggerOn);
            return triggers;
        }
    }
}
