using Source.Triggers.Base;
using Source.Triggers.DebugTriggers.Triggers;
using System.Collections.Generic;
using WCSharp.Api;

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


            TriggerInstance[] debugTriggers = new TriggerInstance[]
            {
                dungeonDebugExecuterTrigger,
                setHeroLevelDebugTrigger,
                killAllCreepsDebugTrigger,
                killUnitDebugTrigger,
                killAllCreepsDebugTrigger,
                setCurrentHPDebugTrigger,
                setMaxHPDebugTrigger,
                setMaxManaDebugTrigger,
                setCurrentManaDebugTrigger,
                setUnitXYDebugTrigger,
                createUnitAtXYDebugTrigger,
                arenaTimerOffDebugTrigger,
                arenaTimerOnDebugTrigger,
                pauseUnitDebugTrigger,
            };
            foreach (var triggerInstance in debugTriggers)
            {
                triggers.Add(triggerInstance);
            }
#endif
            return triggers;
        }

        public override bool IsExecutedOnStart()
        {
            return false;
        }
    }
}
