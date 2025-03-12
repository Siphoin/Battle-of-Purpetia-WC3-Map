using Source.Systems;
using Source.Triggers.Base;
using System;
using WCSharp.Api;
using WCSharp.Shared;
using static WCSharp.Api.Common;
namespace Source.Triggers.DebugTriggers.Triggers
{
    public class DungeonDebugExecuterTrigger : TriggerInstance
    {
        public override trigger GetTrigger()
        {
            trigger debugTrigger = trigger.Create();
            debugTrigger.RegisterPlayerChatEvent(Player(0), "StartDungeon", false);
            debugTrigger.AddAction(() =>
            {
                var message = GetEventPlayerChatString();
                var parts = message.Split(' '); // Разделяем строку по пробелам

                if (parts.Length > 1 && int.TryParse(parts[1], out int dungeonNumber))
                {
                    DungeonsSystem.TurnDungeon(dungeonNumber - 1);
                }
            });
            return debugTrigger;
        }
    }
}
