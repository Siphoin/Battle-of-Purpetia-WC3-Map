using Source.Triggers.Base;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCSharp.Api;
using static System.Formats.Asn1.AsnWriter;
using static System.Net.Mime.MediaTypeNames;
using static WCSharp.Api.Common;
namespace Source.Triggers.GUITriggers.Triggers
{
    public class GUIHeroWidgetTrigger : TriggerInstance
    {
        private static Dictionary<player, HeroWidget> _widgets = new();
        private const float OFFSET_WIDGETS = 0.03f;

        public unit TargetHero { get; }

        public GUIHeroWidgetTrigger(unit hero)
        {
            TargetHero = hero;
        }

        private void CreateWidget()
        {
            if (_widgets.ContainsKey(TargetHero.Owner))
            {
                return;
            }
            float offset = 0;

            if (_widgets.Count > 0)
            {
                for (int i = 0; i < _widgets.Count; i++)
                {
                    offset -= OFFSET_WIDGETS;
                }
            }

            HeroWidget newWidget = new(TargetHero, offset);
            _widgets.Add(TargetHero.Owner, newWidget);
        }

        public static void DestroyWidget(player player)
        {
            if (_widgets.TryGetValue(player, out HeroWidget widget))
            {
                widget.Destroy();
                _widgets.Remove(player);
            }
        }

        public override trigger GetTrigger()
        {
            trigger triggerWidget = trigger.Create();
            triggerWidget.AddAction(CreateWidget);
            return triggerWidget;

        }
    }

    public class HeroWidget
    {
        private const float TIME_UPDATE = 0.47f;
        private const string DEFAULT_PATH_TEXTURE_FULL_HEALTH = "hero_bar_fill_hitPoints.blp";
        private framehandle _hpBar;
        private framehandle _manaBar;
        private framehandle _iconHero;
        private framehandle _hpText;
        private framehandle _manaText;
        private float _lastHealth;

        private float _lastMana;

        private float _divideValueHealth;
        private framehandle _frameTextNameHero;



        public unit Hero { get; private set; }

        private float _offset;
        private timer _timerUpdate;

        public HeroWidget(unit hero, float offset)
        {
            Hero = hero;
            _offset = offset;
            CreateWidget();


        }
        private void CreateWidget()
        {
            var heroBar = BlzGetOriginFrame(originframetype.HeroBar, 0);
            BlzFrameSetSize(heroBar, heroBar.Width * 2f, heroBar.Height * 2f);
            BlzLoadTOCFile("war3mapimported\\myBar.toc");
            _hpBar = BlzCreateSimpleFrame("MyBarEx", BlzGetOriginFrame(ORIGIN_FRAME_GAME_UI, 0), Hero.Owner.Id); //Create Bar at createContext 1
            _manaBar = BlzCreateSimpleFrame("MyBarEx", BlzGetOriginFrame(ORIGIN_FRAME_GAME_UI, 0), Hero.Owner.Id + 1); //createContext 2
            _iconHero = BlzCreateSimpleFrame($"MyBar", BlzGetOriginFrame(ORIGIN_FRAME_GAME_UI, 0),  Hero.Owner.Id + 2); //createContext 4, other names so would not be needed.
            _hpText = BlzGetFrameByName("MyBarExText", Hero.Owner.Id);
            _manaText = BlzGetFrameByName("MyBarExText", Hero.Owner.Id + 1);

            BlzFrameSetAbsPoint(_hpBar, framepointtype.Top, -0.035f, 0.56f + _offset); // pos the bar
            BlzFrameSetSize(_hpBar, 0.1f, 0.01f); // pos the ba
            BlzFrameSetPoint(_manaBar, framepointtype.Bottom, _hpBar, FRAMEPOINT_BOTTOM, 0f, -0.012f); // pos bar2 below bar
            BlzFrameSetSize(_manaBar, 0.1f, 0.01f); // pos the ba
            BlzFrameSetPoint(_iconHero, framepointtype.Top, _hpBar, FRAMEPOINT_TOP, 0.0f, 0.0f); // pos bar4 above bar
            BlzFrameSetSize(_iconHero, 0.08f, 0.08f); //change the size of bar4

            BlzFrameSetTexture(_hpBar, DEFAULT_PATH_TEXTURE_FULL_HEALTH, 0, true); //change the BarTexture of bar to color red
            BlzFrameSetTexture(_manaBar, "hero_bar_fill_manaPoints.blp", 0, true); //color blue for bar2
            BlzFrameSetTexture(_iconHero, "Replaceabletextures\\CommandButtons\\BTNHeroPaladin.blp", 0, true); //bar4 to Paladin-Face
            BlzFrameSetAlpha(_iconHero, 0);

            BlzFrameSetText(BlzGetFrameByName("MyBarExText", Hero.Owner.Id), string.Empty);
            BlzFrameSetText(BlzGetFrameByName("MyBarExText", Hero.Owner.Id + 1), string.Empty);
            BlzFrameSetValue(_iconHero, 100);


            UpdateWidget();

            _timerUpdate = CreateTimer();
            _timerUpdate.Start(TIME_UPDATE, TRUE, UpdateWidget);
        }

        private void UpdateWidget()
        {
            if (!Hero.Alive)
            {

                BlzFrameSetText(_hpText, "Мертв");
                BlzFrameSetText(_manaText, "Мертв");
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


            BlzFrameSetText(_hpText, $"{Hero.Life:F0}/{Hero.MaxLife:F0}");
            BlzFrameSetText(_manaText, $"{Hero.Mana:F0}/{Hero.MaxMana:F0}");

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

        public void Destroy ()
        {
            DestroyTimer(_timerUpdate);
            BlzDestroyFrame(_iconHero);
            BlzDestroyFrame(_hpBar);
            BlzDestroyFrame (_manaBar);
        }
    }




}
