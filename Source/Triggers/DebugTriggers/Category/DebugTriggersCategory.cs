using Source.Triggers.Base;
using Source.Triggers.DebugTriggers.Triggers;
using System.Collections.Generic;

namespace Source.Triggers.DebugTriggers.Category
{
    public class DebugTriggersCategory : TriggerCategory
    {
        protected override IEnumerable<TriggerInstance> GetAllTriggers()
        {
            List<TriggerInstance> triggers = new List<TriggerInstance>();


#if DEBUG
            DungeonDebugExecuterTrigger dungeonDebugExecuterTrigger = new DungeonDebugExecuterTrigger();
            SetHeroLevelDebugTrigger setHeroLevelDebugTrigger = new SetHeroLevelDebugTrigger();
            KillAllCreepsDebugTrigger killAllCreepsDebugTrigger = new KillAllCreepsDebugTrigger();
            triggers.Add(dungeonDebugExecuterTrigger);
            triggers.Add(setHeroLevelDebugTrigger);
            triggers.Add(killAllCreepsDebugTrigger);
#endif
            return triggers;
        }

        public override bool IsExecutedOnStart()
        {
            return false;
        }
    }
}
