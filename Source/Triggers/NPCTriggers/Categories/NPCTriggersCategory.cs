using Source.Triggers.Base;
using Source.Triggers.NPCTriggers.Triggers.TalkTriggers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Source.Triggers.NPCTriggers.Categories
{
    public class NPCTriggersCategory : TriggerCategory
    {
        protected override IEnumerable<TriggerInstance> GetAllTriggers()
        {
            TriggerInstance[] triggers = new TriggerInstance[]
            {
                new HicksMuddyNPCTaskRegionTrigger(Regions.QuestNPCCityGoblin),
            };

            return triggers;
        }
    }
}
