using Source.Triggers.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCSharp.Api;
using static WCSharp.Api.Common;
namespace Source.Triggers.GUITriggers.Triggers
{
    public class GUIHeroWidgetTrigger : TriggerInstance
    {
        private const float TIME_UPDATE = 0.47f;
        private const string DEFAULT_PATH_TEXTURE_FULL_HEALTH = "hero_bar_fill_hitPoints.blp";
        private framehandle _hpBar;
        private framehandle _manaBar;
        private framehandle _iconHero;

        private float _lastHealth;

        private float _lastMana;

        private float _divideValueHealth;

        public unit Hero { get; private set; }
        public GUIHeroWidgetTrigger(unit hero)
        {
            Hero = hero;
        }

        public override trigger GetTrigger()
        {
            trigger triggerWidget = trigger.Create();
            triggerWidget.AddAction(CreateWidget);
            return triggerWidget;

        }

        private void CreateWidget()
        {
            var heroBar = BlzGetOriginFrame(originframetype.HeroBar, 0);
            BlzFrameSetSize(heroBar, heroBar.Width * 2f, heroBar.Height * 2f);
            BlzLoadTOCFile("war3mapimported\\myBar.toc");
             _hpBar = BlzCreateSimpleFrame("MyBarEx", BlzGetOriginFrame(ORIGIN_FRAME_GAME_UI, 0), 1); //Create Bar at createContext 1
            _manaBar = BlzCreateSimpleFrame("MyBarEx", BlzGetOriginFrame(ORIGIN_FRAME_GAME_UI, 0), 2); //createContext 2ro = BlzCreateSimpleFrame("MyBar", BlzGetOriginFrame(ORIGIN_FRAME_GAME_UI, 0), 4); //createContext 4, other names so would not be needed.
            BlzFrameSetAbsPoint(_hpBar, FRAMEPOINT_CENTER, -0.035f, 0.56f); // pos the bar
            BlzFrameSetSize(_hpBar, 0.1f, 0.01f); // pos the ba
            BlzFrameSetPoint(_manaBar, FRAMEPOINT_TOP, _hpBar, FRAMEPOINT_BOTTOM, 0f, -0.005f); // pos bar2 below bar
            BlzFrameSetSize(_manaBar, 0.1f, 0.01f); // pos the ba
            BlzFrameSetPoint(_iconHero, FRAMEPOINT_BOTTOM, _hpBar, FRAMEPOINT_TOP, 0.0f, 0.0f); // pos bar4 above bar
            BlzFrameSetSize(_iconHero, 0.08f, 0.08f); //change the size of bar4

            BlzFrameSetTexture(_hpBar, DEFAULT_PATH_TEXTURE_FULL_HEALTH, 0, true); //change the BarTexture of bar to color red
            BlzFrameSetTexture(_manaBar, "hero_bar_fill_manaPoints.blp", 0, true); //color blue for bar2
            BlzFrameSetTexture(_iconHero, "Replaceabletextures\\CommandButtons\\BTNHeroPaladin.blp", 0, true); //bar4 to Paladin-Face
            BlzFrameSetAlpha(_iconHero, 0);

            BlzFrameSetText(BlzGetFrameByName("MyBarExText", 1), string.Empty);
            BlzFrameSetText(BlzGetFrameByName("MyBarExText", 2), string.Empty);
            BlzFrameSetText(BlzGetFrameByName("MyBarText", 4), string.Empty);
            BlzFrameSetValue(_iconHero, 100);

            UpdateWidget();

            timer timerUpdate = CreateTimer();
            timerUpdate.Start(TIME_UPDATE, TRUE, UpdateWidget);
        }

        private void UpdateWidget ()
        {
            if (!Hero.Alive)
            {

                BlzFrameSetText(BlzGetFrameByName("MyBarExText", 1), "Мертв");
                BlzFrameSetText(BlzGetFrameByName("MyBarExText", 2), "Мертв");
                BlzFrameSetValue(_hpBar, 0);
                BlzFrameSetValue(_manaBar, 0);
                return;
            }
            if (_lastHealth == Hero.Life && _lastMana == Hero.Mana)
            {
                return;
            }
            _divideValueHealth = Hero.MaxLife / 2;
            _lastHealth = Hero.Life;
            _lastMana = Hero.Mana;
            // text update


            BlzFrameSetText(BlzGetFrameByName("MyBarExText", 1), $"{Hero.Life:F0}/{Hero.MaxLife:F0}");
            BlzFrameSetText(BlzGetFrameByName("MyBarExText", 2), $"{Hero.Mana:F0}/{Hero.MaxMana:F0}");

            string targetTextureHealth = DEFAULT_PATH_TEXTURE_FULL_HEALTH;

            if (Hero.Life <= _divideValueHealth)
            {
                targetTextureHealth = "hero_bar_fill_hitPoints_divide.blp";
            }

            if (Hero.Life <= 50)
            {
                targetTextureHealth = "hero_bar_fill_hitPoints_low.blp";
            }

            BlzFrameSetTexture(_hpBar, targetTextureHealth, 0, true); //change the BarTexture of bar to color red


            // bars update

            var currentHealth = Hero.Life;
            var maxHealth = Hero.MaxLife;

            var healthPercentage = (currentHealth / maxHealth) * 100;

            BlzFrameSetValue(_hpBar, healthPercentage);

            var currentMana = Hero.Mana;
            var maxMana = Hero.MaxMana;

            var manaPercentage = (currentMana / maxMana) * 100;

            BlzFrameSetValue(_manaBar, manaPercentage);
        }
    }
}
