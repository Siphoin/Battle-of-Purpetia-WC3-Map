using Source.Data.Dungeons;
using Source.Triggers.Base;
using System.Collections.Generic;

namespace Source.Triggers.DungeonsTriggers.Categories
{
    public class DungeonTriggersCategory : TriggerCategory
    {
        protected override IEnumerable<TriggerInstance> GetAllTriggers()
        {
            List<TriggerInstance> triggers = new List<TriggerInstance>();
            ReaniCemetery reanicemetery = new();
            triggers.Add(reanicemetery);
            return triggers;
        }
    }
}
