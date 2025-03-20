using Source.Triggers.Base;
using WCSharp.Api;
using static WCSharp.Api.Common;
namespace Source.Triggers.DebugTriggers.Triggers
{
    public class KillUnitDebugTrigger : TriggerInstance
    {
        private unit _selectedUnit;

        public override trigger GetTrigger()
        {
            trigger triggerListener = trigger.Create();
            triggerListener.RegisterPlayerUnitEvent(Player(0), playerunitevent.Selected);
            triggerListener.AddAction(() =>
            {
                var unit = GetTriggerUnit();

                if (!string.IsNullOrEmpty(unit.HeroName))
                {
                    _selectedUnit = unit;
                }

                else
                {
                    _selectedUnit = null;
                }
            });
            trigger debugTrigger = trigger.Create();
            debugTrigger.RegisterPlayerChatEvent(Player(0), "KillUnit", true);
            debugTrigger.AddAction(() =>
            {
                if (_selectedUnit is null)
                {
                    return;
                }
                _selectedUnit.Kill();
                _selectedUnit = null;
            });
            return debugTrigger;
        }
    }
}
