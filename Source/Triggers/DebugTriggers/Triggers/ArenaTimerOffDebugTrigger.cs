using Source.Triggers.ArenaTriggers.Triggers;
using Source.Triggers.Base;
using WCSharp.Api;
using static WCSharp.Api.Common;
namespace Source.Triggers.DebugTriggers.Triggers
{
    public class ArenaTimerOffDebugTrigger : TriggerInstance
    {
        public override trigger GetTrigger()
        {
            trigger debugTrigger = trigger.Create();
            debugTrigger.RegisterPlayerChatEvent(Player(0), "StopArenaTimer", true);
            debugTrigger.AddAction(() =>
            {
                ArenaTrigger.StopTickingNewArena();
            });
            return debugTrigger;
        }
    }
}
