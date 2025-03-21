using Source.Extensions;
using Source.Triggers.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCSharp.Api;
using WCSharp.Events;
using WCSharp.Shared;
using static WCSharp.Api.Common;
using static Source.Extensions.CommonExtensions;
namespace Source.Triggers.GUITriggers.Triggers
{
    public class FloatingDamageTextTrigger : TriggerInstance
    {
        private const float TEXT_DURATION = 2.0f; // Длительность анимации
        private const float TEXT_SPEED = 0.03f;   // Скорость движения текста
        private const float TEXT_FADE = 0.04f;    // Скорость затухан

        public override trigger GetTrigger()
        {
            trigger listener = trigger.Create();
            PlayerUnitEvents.Register(UnitTypeEvent.IsDamaged, OnUnitDamaged);

            return listener;
        }

        private void OnUnitDamaged()
        {
            var damagedUnit = GetTriggerUnit();
            var damageAmount = GetEventDamage();
            if (damagedUnit.IsInvisibleTo(player.LocalPlayer))
            {
                return;
            }

            CreateFloatingText(damagedUnit, damageAmount);
        }

        private void CreateFloatingText(unit unit, float damage)
        {
            var x = GetUnitX(unit) + GetRandomReal(-50, 50);
            var y = GetUnitY(unit) + GetRandomReal(-50, 50);
            var z = GetUnitFlyHeight(unit) + 50; // Высота над юнитом
            CreateDamageText(damage, 11.9f, x, y, 50);
        }

        public void CreateDamageText(float damage, float size, float x, float y, float height)
        {
            texttag texttag = CreateTextTag();
            int roundedDamage = (int)damage;
            string text = $"{roundedDamage.ToString().Colorize(RED_TEXT_HEX)}";

            SetTextTagText(texttag, text, size * 0.0023f);
            SetTextTagPos(texttag, x, y, height);
            SetTextTagAge(texttag, 0f);
            SetTextTagVelocity(texttag, 0f, 0.0899218777f);
            SetTextTagLifespan(texttag, 0.9f);
            SetTextTagFadepoint(texttag, 0.5f);
            SetTextTagPermanent(texttag, flag: false);
            SetTextTagVisibility(texttag, flag: true);
        }
    }
}
