using Source.Triggers.Base;
using System;
using WCSharp.Api;
using static WCSharp.Api.Common;
namespace Source.Triggers.DebugTriggers.Triggers
{
    public class DungeonDebugExecuterTrigger : TriggerInstance
    {
        public override trigger GetTrigger()
        {
            trigger debugTrigger = trigger.Create();
            debugTrigger.RegisterPlayerChatEvent(Player(0), "StartDungeon", true);
            debugTrigger.AddAction(() =>
            {
                var message = GetEventPlayerChatStringMatched();
                Console.WriteLine(message);
            });
            return debugTrigger;
        }
    }
}
