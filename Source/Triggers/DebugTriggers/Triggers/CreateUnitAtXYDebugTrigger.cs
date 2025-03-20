using Source.Triggers.Base;
using WCSharp.Api;
using static WCSharp.Api.Common;

namespace Source.Triggers.DebugTriggers.Triggers
{
    public class CreateUnitAtXYDebugTrigger : TriggerInstance
    {
        public override trigger GetTrigger()
        {
            var debugTrigger = trigger.Create();
            debugTrigger.RegisterPlayerChatEvent(Player(0), "CreateUnit", false);
            debugTrigger.AddAction(() =>
            {
                var message = GetEventPlayerChatString().Split(' ');
                if (message.Length < 5) return;

                if (int.TryParse(message[2], out int playerNumber) &&
                    int.TryParse(message[3], out int x) &&
                    int.TryParse(message[4], out int y))
                {
                    var unitId = FourCC(message[1]);
                    var targetPlayer = Player(playerNumber);
                    CreateUnit(targetPlayer, unitId, x, y, 0f);
                }
            });
            return debugTrigger;
        }
    }
}