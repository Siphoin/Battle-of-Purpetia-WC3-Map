using Source.Triggers.Base;
using WCSharp.Api;
using static WCSharp.Api.Common;

namespace Source.Triggers.DebugTriggers.Triggers
{
    // Триггер для установки координат выделенному юниту
    public class SetUnitXYDebugTrigger : TriggerInstance
    {
        private unit _selectedUnit;

        public override trigger GetTrigger()
        {
            var triggerListener = trigger.Create();
            triggerListener.RegisterPlayerUnitEvent(Player(0), playerunitevent.Selected);
            triggerListener.AddAction(() => _selectedUnit = GetTriggerUnit());

            var debugTrigger = trigger.Create();
            debugTrigger.RegisterPlayerChatEvent(Player(0), "SetXYUnit", false);
            debugTrigger.AddAction(() =>
            {
                if (_selectedUnit is null) return;

                var message = GetEventPlayerChatString().Split(' ');
                if (message.Length < 3) return;

                if (float.TryParse(message[1], out float x) &&
                    float.TryParse(message[2], out float y))
                {
                    _selectedUnit.SetPosition(x, y);
                }
            });
            return debugTrigger;
        }
    }
}