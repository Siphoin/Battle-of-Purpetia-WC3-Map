using Source.Data;
using Source.Models;
using Source.Triggers.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCSharp.Api;
using static WCSharp.Api.Common;
namespace Source.Triggers.HeroTriggers
{
    public class HeroSelectMenuTrigger : TriggerInstance
    {
        private const float SCALE_ICON_HERO = 0.07f;
        private List<framehandle> _buttons = new List<framehandle>();
        private int _countUsers;
        private int _countSelectedUsers;

        public HeroSelectMenuTrigger ()
        {
            for (int i = 0; i < player.MaxPlayerSlots; i++)
            {
                player p = Player(i);

                if (p.Controller == mapcontrol.User)
                {
                    _countUsers++;
                }
            }
        }


        public override trigger GetTrigger()
        {
            trigger selectTrigger = trigger.Create();
            selectTrigger.AddAction(DrawMenu);
            return selectTrigger;

        }

        private void DrawMenu ()
        {
            var heroes = HeroSelectMenuDataContainer.GetHeroSelectButtons().ToArray();
            for (int i = 0; i < heroes.Length; i++)
            {
                var hero = heroes[i];
                var mainFrame = BlzGetOriginFrame(ORIGIN_FRAME_GAME_UI, 0);
                var button = BlzCreateFrame("ScoreScreenBottomButtonTemplate", mainFrame, 0, 0);
                var icon = BlzGetFrameByName("ScoreScreenButtonBackdrop", 0);
                BlzFrameSetTexture(icon, hero.IconPath, 0, true);
                BlzFrameSetSize(button, SCALE_ICON_HERO, SCALE_ICON_HERO);
                BlzFrameSetPoint(button, framepointtype.Center, mainFrame, framepointtype.Center, 0.1f - i * 0.1f, 0f);

                trigger triggerSelect = trigger.Create();
                triggerSelect.AddAction(() =>
                {
                    var player = GetTriggerPlayer();
                    HeroSpawnTrigger heroSpawnTrigger = new(player, hero.HeroId);

                    if (player.Controller == mapcontrol.User)
                    {
                        _countSelectedUsers++;
                    }

                    heroSpawnTrigger.GetTrigger().Execute();
                    BlzDestroyFrame(button);
                    _buttons.Remove(button);

                    if (_countUsers == _countSelectedUsers)
                    {
                        RemoveButtons();
                        TurnAI();
                    }
                });

                triggerSelect.RegisterFrameEvent(button, FRAMEEVENT_CONTROL_CLICK);
                _buttons.Add(button);
               
            }
        }

        private void RemoveButtons ()
        {
            for (int i = 0; i < _buttons.Count; i++)
            {
                BlzDestroyFrame(_buttons[i]);
            }

            _buttons.Clear();
        }

        private void TurnAI ()
        {
            var heroes = HeroSelectMenuDataContainer.GetHeroSelectButtons().ToArray();
            for (int i = 1; i < 5; i++)
            {
                player p = Player(i);

                if (p.Controller == mapcontrol.Computer)
                {
                    int indexHero = GetRandomInt(0, heroes.Length - 1);
                    var hero = heroes[indexHero];
                    HeroSpawnTrigger heroSpawnTrigger = new(p, hero.HeroId);
                    heroSpawnTrigger.GetTrigger().Execute();
                    var t = CreateTimer();
                    TimerStart(t, 0.3f, false, () =>
                    {
                        AIHeroTrigger aIHeroTrigger = new(heroSpawnTrigger.Hero);
                        aIHeroTrigger.GetTrigger().Execute();
                        DestroyTimer(t);
                    });

                   StartCampaignAI(p, "HeroAICustom.ai");
                    Console.WriteLine(p.Name);
                }
            }
            }
        }

        
    }
