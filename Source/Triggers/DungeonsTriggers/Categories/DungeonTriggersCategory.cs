using Source.Data.Dungeons;
using Source.Systems;
using Source.Triggers.Base;
using System.Collections.Generic;

namespace Source.Triggers.DungeonsTriggers.Categories
{
    public class DungeonTriggersCategory : TriggerCategory
    {
        protected override IEnumerable<TriggerInstance> GetAllTriggers()
        {
            List<TriggerInstance> triggers = new List<TriggerInstance>();
            DungeonInstance[] dungeons = new DungeonInstance[]
            {
                new ReaniCemetery(),
            };
            foreach (var dungeon in dungeons)
            {
                DungeonsSystem.RegisterDungeon(dungeon);
                triggers.Add(dungeon);
            }
            return triggers;
        }
    }
}
