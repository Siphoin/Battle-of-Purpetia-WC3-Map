using Source.Data;
using Source.Triggers.Base;
using Source.Triggers.MonsterAreaSystem.Triggers;
using System.Collections.Generic;

namespace Source.Triggers.MonsterAreaSystem.Categories
{
    public class MonsterTriggersCategory : TriggerCategory
    {
        
        protected override IEnumerable<TriggerInstance> GetAllTriggers()
        {
            var monsterAreas = MonsterAreaSpawningDataContainer.GetData();

            List<TriggerInstance> triggers = new List<TriggerInstance>();
            foreach (var area in monsterAreas)
            {
                MonsterAreaSpawnTrigger monsterAreaSpawnTrigger = new(area);
                triggers.Add(monsterAreaSpawnTrigger);
            }

            return triggers;
        }
    }
}
