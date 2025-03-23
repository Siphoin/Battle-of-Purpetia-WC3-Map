using Source.Triggers.Base;
using WCSharp.Api;
using static WCSharp.Api.Common;
using static Source.Extensions.CommonExtensions;
using System;
namespace Source.Triggers.DebugTriggers.Triggers
{
    public class FastDialogUnitsDebugTrigger : TriggerInstance
    {
        public override trigger GetTrigger()
        {
            trigger debugTrigger = trigger.Create();
            debugTrigger.RegisterPlayerChatEvent(Player(0), "SetFastDialogs", false);
#if DEBUG
            debugTrigger.AddAction(() =>
            {
                var message = GetEventPlayerChatString();
                var parts = message.Split(' ');

                if (parts.Length > 1 && int.TryParse(parts[1], out int valueEnabled))
                {
                    bool isEnabled = valueEnabled == 0 ? FALSE : TRUE;
                    IsFastTransmissionUnit = isEnabled;

                    Console.WriteLine($"IsFastTransmissionUnit: {isEnabled}");
                }
            });
#endif
            return debugTrigger;
        }
    }
}
