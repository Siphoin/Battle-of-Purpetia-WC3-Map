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
        private framehandle _hpText;
        private framehandle _manaText;
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
            _updateStatsUnit.Active = true;
        }

        private void OnUnitDie()
        {
            _updateStatsUnit.Active = false;
            _updateStatsUnit = null;
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
                _hpText = BlzGetFrameByName("MyBarExText", 100);
                _manaText = BlzGetFrameByName("MyBarExText", 101);
                BlzFrameSetText(_hpText, $"{unit.Life:F0}/{unit.MaxLife:F0}");
                BlzFrameSetText(_manaText, $"{unit.Mana:F0}/{unit.MaxMana:F0}");
                BlzFrameSetParent(_hpText, _hpBar);
                BlzFrameSetParent(_hpBar, _portail);
                BlzFrameSetParent(_manaBar, _portail);
                BlzFrameSetParent(_manaText, _manaBar);
                _isCreated = true;
            }


            if (_updateStatsUnit is null)
            {
                _periodicTrigger = new(0.03f);
                _updateStatsUnit = new PeriodcUpdateStatsUnit(_target, ShowStats);

                _periodicTrigger.Add(_updateStatsUnit);
            }

            else
            {
                _updateStatsUnit.Target = _target;
            }
            _target = unit;
            BlzFrameSetVisible(_hpBar, true);
            BlzFrameSetVisible(_manaBar, _target.MaxMana > 0);
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
            }

            if (_target.IsInvisibleTo(player.LocalPlayer))
            {
                Console.WriteLine(432323);
                Hide();
            }
        }

        private void Hide ()
        {
            BlzFrameSetVisible(_hpBar, false);
            BlzFrameSetVisible(_manaBar, false);
            _updateStatsUnit.Active = false;
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
