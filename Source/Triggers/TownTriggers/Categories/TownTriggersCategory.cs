using Source.Data.Towns;
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
            var towns = TownRegionsContanerData.GetRegions();
            foreach (var region in towns)
            {
                NoViolanceAreaTownTriggernteraction trigger = new(region);
                triggers.Add(trigger);
            } 
            return triggers;
        }
    }

}

