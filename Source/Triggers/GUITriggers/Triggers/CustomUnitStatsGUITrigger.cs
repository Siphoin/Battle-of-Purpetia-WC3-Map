using Source.Models;
using Source.Triggers.Base;
using System;
using WCSharp.Api;
using WCSharp.Events;
using static WCSharp.Api.Common;
namespace Source.Triggers.GUITriggers.Triggers
{
    public class CustomUnitStatsGUITrigger : TriggerInstance
    {
        private framehandle _hpBar;
        private framehandle _manaBar;
        private framehandle _xpHeroBar;
        private framehandle _xpHeroBarText;
        private framehandle _hpText;
        private framehandle _manaText;
        private framehandle _textNameUnit;
        private unit _target;
        private PeriodcUpdateStatsUnit _updateStatsUnit;
        public static PeriodicTrigger<PeriodcUpdateStatsUnit> _periodicTrigger;

        private bool _isCreated;
        private int _divideValueHealth;
        private object _lastHealth;
        private object _lastMana;
        private framehandle _portail;

        public override trigger GetTrigger()
        {
            Console.WriteLine(_portail.Alpha);
            trigger triggerListener = trigger.Create();
            triggerListener.RegisterPlayerUnitEvent(player.LocalPlayer, playerunitevent.Selected);
            triggerListener.AddAction(() =>
            {
                var unit = GetTriggerUnit();
                if (unit != null)
                {
                    if (_target != null)
                    {
                        PlayerUnitEvents.Unregister(UnitEvent.Dies, OnUnitDie, _target);
                    }
                    ShowStats(unit);
                    HandlingUnit(unit);
                }
            });

            return triggerListener;
        }

        private void HandlingUnit(unit unit)
        {
            _target = unit;
            PlayerUnitEvents.Register(UnitEvent.Dies, OnUnitDie, _target);
        }

        private void OnUnitDie()
        {
            PlayerUnitEvents.Unregister(UnitEvent.Dies, OnUnitDie, _target);
            Hide();
        }

        private void ShowStats(unit unit)
        {
            if (!_isCreated)
            {
               

                _portail = BlzGetOriginFrame(originframetype.Portrait, 0);
                BlzLoadTOCFile("war3mapimported\\myBar.toc");
                _hpBar = BlzCreateSimpleFrame("MyBarEx", BlzGetOriginFrame(ORIGIN_FRAME_GAME_UI, 0), 100); //Create Bar at createContext 1
                BlzFrameSetPoint(_hpBar, framepointtype.Center, _portail, framepointtype.Center, 0.07f, 0.015F); // pos bar4 above bar
                BlzFrameSetSize(_hpBar, 0.13f, 0.015f); // pos the ba

                _manaBar = BlzCreateSimpleFrame("MyBarEx", BlzGetOriginFrame(ORIGIN_FRAME_GAME_UI, 0), 101); //createContext 2
                BlzFrameSetPoint(_manaBar, framepointtype.Bottom, _hpBar, FRAMEPOINT_BOTTOM, 0f, -0.017f); // pos bar2 below bar
                BlzFrameSetSize(_manaBar, 0.13f, 0.015f); // pos the ba
                BlzFrameSetTexture(_manaBar, "hero_bar_fill_manaPoints.blp", 0, true); //color blue for bar2
                _xpHeroBar = BlzCreateSimpleFrame("MyBarEx", BlzGetOriginFrame(ORIGIN_FRAME_GAME_UI, 0), 102); //createContext 2
                BlzFrameSetPoint(_xpHeroBar, framepointtype.Top, _hpBar, FRAMEPOINT_TOP, 0.01f, 0.038f); // pos bar2 below bar
                BlzFrameSetSize(_xpHeroBar, 0.35f, 0.01f); // pos the ba
                BlzFrameSetTexture(_xpHeroBar, "hero_bar_fill_manaPoints.blp", 0, true); //color blue for bar2
                _hpText = BlzGetFrameByName("MyBarExText", 100);
                _manaText = BlzGetFrameByName("MyBarExText", 101);
                _xpHeroBarText = BlzGetFrameByName("MyBarExText", 102);
                _textNameUnit = BlzCreateFrameByType("TEXT", "MyTextFrame", BlzGetOriginFrame(ORIGIN_FRAME_GAME_UI, 0), "", 0);
                BlzFrameSetPoint(_textNameUnit, FRAMEPOINT_CENTER, _portail, FRAMEPOINT_CENTER, 0.045f, 0.025f);
                BlzFrameSetScale(_textNameUnit, 1.5f);
                BlzFrameSetText(_hpText, $"{unit.Life:F0}/{unit.MaxLife:F0}");
                BlzFrameSetText(_manaText, $"{unit.Mana:F0}/{unit.MaxMana:F0}");
                BlzFrameSetParent(_hpText, _hpBar);
                BlzFrameSetParent(_hpBar, _portail);
                BlzFrameSetParent(_manaBar, _portail);
                BlzFrameSetParent(_manaText, _manaBar);
                _isCreated = true;

                _periodicTrigger = new(0.03f);
                _updateStatsUnit = new PeriodcUpdateStatsUnit(_target, ShowStats);

                _periodicTrigger.Add(_updateStatsUnit);
            }
            _target = unit;
            BlzFrameSetVisible(_hpBar, true);
            if (_target.Owner == player.NeutralPassive && _target.IsInvulnerable)
            {
                BlzFrameSetVisible(_hpBar, false);
            }
            BlzFrameSetVisible(_manaBar, _target.MaxMana > 0);
            BlzFrameSetVisible(_textNameUnit, true);
            BlzFrameSetVisible(_xpHeroBar, !string.IsNullOrEmpty(_target.HeroName) && _target.Owner == player.LocalPlayer);
            BlzFrameSetText(_textNameUnit, !string.IsNullOrEmpty(_target.HeroName) ? _target.HeroName : _target.Name);
            ShowStats();
        }

        private void ShowStats()
        {
            if (_target.Alive)
            {
                _divideValueHealth = _target.MaxLife / 2;
                _lastHealth = _target.Life;
                _lastMana = _target.Mana;
                BlzFrameSetText(_hpText, $"{_target.Life:F0}/{_target.MaxLife:F0}");
                BlzFrameSetText(_manaText, $"{_target.Mana:F0}/{_target.MaxMana:F0}");
                // bars update

                var currentHealth = _target.Life;
                var maxHealth = _target.MaxLife;

                var healthPercentage = (currentHealth / maxHealth) * 100;

                BlzFrameSetValue(_hpBar, healthPercentage);

                var currentMana = _target.Mana;
                var maxMana = _target.MaxMana;

                var manaPercentage = (currentMana / maxMana) * 100;

                BlzFrameSetValue(_manaBar, manaPercentage);

                string targetTextureHealth = MapConfig.DEFAULT_PATH_TEXTURE_FULL_HEALTH;

                if (_target.Life <= _divideValueHealth)
                {
                    targetTextureHealth = "hero_bar_fill_hitPoints_divide.blp";
                    
                }

                if (_target.Life < 15)
                {
                    targetTextureHealth = "hero_bar_fill_hitPoints_low.blp";
                }

                BlzFrameSetTexture(_hpBar, targetTextureHealth, 0, true); //change the BarTexture of bar to color red

                if (!string.IsNullOrEmpty(_target.HeroName))
                {
                    var currentHeroXP = GetHeroXP(_target);
                    var requireXPCount = MapConfig.NEED_HERO_XP * _target.HeroLevel;
                    float XPpercent = (float)currentHeroXP / (float)requireXPCount  * 100;

                    BlzFrameSetText(_xpHeroBarText, $"{currentHeroXP:F0} / {requireXPCount:F0}");

                    BlzFrameSetValue(_xpHeroBar, XPpercent);
                }
            }

            if (_target.IsInvisibleTo(player.LocalPlayer))
            {
                
                Hide();
            }
        }

        private void Hide ()
        {
            BlzFrameSetVisible(_hpBar, false);
            BlzFrameSetVisible(_manaBar, false);
            BlzFrameSetVisible(_textNameUnit, false);
            BlzFrameSetVisible(_xpHeroBar, false);
        }

    }
    public class PeriodcUpdateStatsUnit : IPeriodicAction
    {

        public unit Target { get; set; }
        public bool Active { get; set; } = true;
        public Action UpdateStatsAction { get; set; }

        public PeriodcUpdateStatsUnit(unit target, Action updateStatsAction)
        {
            Target = target;
            UpdateStatsAction = updateStatsAction;
        }

        public void Action()
        {
            UpdateStatsAction?.Invoke();
        }
    }

}
