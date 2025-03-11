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
            Dungeon1 dungeon1 = new();
            triggers.Add(dungeon1);
            return triggers;
        }
    }
}
