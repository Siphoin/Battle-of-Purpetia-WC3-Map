using Source.Systems;
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
    public class SetHeroLevelDebugTrigger : TriggerInstance
    {
        private unit _selectedUnit;

        public override trigger GetTrigger()
        {
            trigger triggerListener = trigger.Create(); 
            triggerListener.RegisterPlayerUnitEvent(player.LocalPlayer, playerunitevent.Selected);
            triggerListener.AddAction(() =>
            {
                var unit = GetTriggerUnit();

                if (!string.IsNullOrEmpty(unit.HeroName))
                {
                    _selectedUnit = unit;
                }
            });
            trigger debugTrigger = trigger.Create();
            debugTrigger.RegisterPlayerChatEvent(Player(0), "SetHeroLevel", false);
            debugTrigger.AddAction(() =>
            {
                if (_selectedUnit is null)
                {
                    return;
                }
                var message = GetEventPlayerChatString();
                var parts = message.Split(' '); // Разделяем строку по пробелам

                if (parts.Length > 1 && int.TryParse(parts[1], out int level))
                {
                    SetHeroLevel(_selectedUnit, level, false);
                }
            });
            return debugTrigger;
        }
    }
}
