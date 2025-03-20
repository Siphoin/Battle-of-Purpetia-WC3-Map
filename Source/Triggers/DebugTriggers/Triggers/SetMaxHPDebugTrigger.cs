﻿using Source.Triggers.Base;
using WCSharp.Api;
using static WCSharp.Api.Common;

namespace Source.Triggers.DebugTriggers.Triggers
{
    // Триггер для установки максимального здоровья
    public class SetMaxHPDebugTrigger : TriggerInstance
    {
        private unit _selectedUnit;

        public override trigger GetTrigger()
        {
            var triggerListener = trigger.Create();
            triggerListener.RegisterPlayerUnitEvent(Player(0), playerunitevent.Selected);
            triggerListener.AddAction(() =>
            {
                var unit = GetTriggerUnit();
                _selectedUnit = !string.IsNullOrEmpty(unit.HeroName) ? unit : null;
            });

            var debugTrigger = trigger.Create();
            debugTrigger.RegisterPlayerChatEvent(Player(0), "SetMaxHP", false);
            debugTrigger.AddAction(() =>
            {
                if (_selectedUnit is null) return;

                var message = GetEventPlayerChatString().Split(' ');
                if (message.Length > 1 && int.TryParse(message[1], out int value))
                {
                    _selectedUnit.MaxLife = value;
                }
            });
            return debugTrigger;
        }
    }
}