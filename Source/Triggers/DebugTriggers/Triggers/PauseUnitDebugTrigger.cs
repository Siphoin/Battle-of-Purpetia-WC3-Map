using Source.Triggers.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCSharp.Api;
using static WCSharp.Api.Common;
namespace Source.Triggers.DebugTriggers.Triggers
{
    public class PauseUnitDebugTrigger : TriggerInstance
    {
        private unit _selectedUnit;

        public override trigger GetTrigger()
        {
            var triggerListener = trigger.Create();
            triggerListener.RegisterPlayerUnitEvent(Player(0), playerunitevent.Selected);
            triggerListener.AddAction(() => _selectedUnit = GetTriggerUnit());

            var debugTrigger = trigger.Create();
            debugTrigger.RegisterPlayerChatEvent(Player(0), "SetPauseUnit", false);
            debugTrigger.AddAction(() =>
            {
                if (_selectedUnit is null) return;

                var message = GetEventPlayerChatString().Split(' ');
                if (message.Length < 3) return;

                if (int.TryParse(message[1], out int pauseState))
                {
                    bool isPause = pauseState == 0 ? false : true;
                    PauseUnit(_selectedUnit, isPause);
                }
            });
            return debugTrigger;
        }
    }
}
