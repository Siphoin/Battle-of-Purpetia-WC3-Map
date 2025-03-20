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
            KillUnitDebugTrigger killUnitDebugTrigger = new KillUnitDebugTrigger();
            SetCurrentHPDebugTrigger setCurrentHPDebugTrigger = new SetCurrentHPDebugTrigger();
            SetMaxHPDebugTrigger setMaxHPDebugTrigger = new SetMaxHPDebugTrigger();
            SetMaxManaDebugTrigger setMaxManaDebugTrigger = new SetMaxManaDebugTrigger();
            SetCurrentManaDebugTrigger setCurrentManaDebugTrigger = new SetCurrentManaDebugTrigger();
            SetUnitXYDebugTrigger setUnitXYDebugTrigger = new SetUnitXYDebugTrigger();
            CreateUnitAtXYDebugTrigger createUnitAtXYDebugTrigger = new CreateUnitAtXYDebugTrigger();
            PauseUnitDebugTrigger pauseUnitDebugTrigger = new PauseUnitDebugTrigger();
            ArenaTimerOnDebugTrigger arenaTimerOnDebugTrigger = new ArenaTimerOnDebugTrigger();
            ArenaTimerOffDebugTrigger arenaTimerOffDebugTrigger = new ArenaTimerOffDebugTrigger();
            triggers.Add(dungeonDebugExecuterTrigger);
            triggers.Add(setHeroLevelDebugTrigger);
            triggers.Add(killAllCreepsDebugTrigger);
            triggers.Add(killUnitDebugTrigger);
            triggers.Add(setCurrentManaDebugTrigger);
            triggers.Add(setCurrentHPDebugTrigger);
            triggers.Add(setMaxManaDebugTrigger);
            triggers.Add(setMaxHPDebugTrigger);
            triggers.Add(createUnitAtXYDebugTrigger);
            triggers.Add(setUnitXYDebugTrigger);
            triggers.Add(pauseUnitDebugTrigger);
            triggers.Add(arenaTimerOnDebugTrigger);
            triggers.Add(arenaTimerOffDebugTrigger);
#endif
            return triggers;
        }

        public override bool IsExecutedOnStart()
        {
            return false;
        }
    }
}
