using Source.Data;
using Source.Data.Inventory;
using Source.Models;
using Source.Triggers.Base;
using Source.Triggers.GUITriggers.Triggers;
using System;
using WCSharp.Api;
using WCSharp.Events;
using static WCSharp.Api.Common;
namespace Source.Triggers.HeroTriggers.Triggers
{
    public class HeroSpawnTrigger : TriggerInstance
    {
        private const int TIME_RESPAWN = 60;
        private player PlayerOwner { get; set; }
        private string IdHeroUnit { get; set; }
        public unit Hero { get; private set; }

        private bool IsLocalHero => Hero.Owner == player.LocalPlayer;

        public HeroSpawnTrigger(player playerOwner, string idHeroUnit)
        {
            PlayerOwner = playerOwner;
            IdHeroUnit = idHeroUnit;
        }

        public override trigger GetTrigger()
        {
            trigger newTrigger = trigger.Create();
            newTrigger.AddAction(() =>
            {
                var point = Regions.HeroSpawn.GetRandomPoint();
                Hero = unit.Create(PlayerOwner, FourCC(IdHeroUnit), point.X, point.Y);
                PlayerUnitEvents.Register(UnitEvent.Dies, HeroRespawn, Hero);
                LockCamera();
                BlzFrameSetVisible(originframetype.HeroButtonIndicator.GetOriginFrame(0), false);

                if (Hero.Owner == player.LocalPlayer)
                {
                    GUIHeroWidgetTrigger heroWidgetTrigger = new(Hero);
                    heroWidgetTrigger.GetTrigger().Execute();
                }
                var t = CreateTimer();
                TimerStart(t, 0.3f, false, () =>
                {
                    PlayerHeroesList.Add(Hero);
                    DestroyTimer(t);
                });

                Hero.HeroName = Hero.Owner.Name;
                CustomInventory inventoryHero = new(Hero);
            });

            return newTrigger;
        }

        private void HeroRespawn()
        {
            trigger triggerRespawn = trigger.Create();

            triggerRespawn.AddAction(() =>
            {
                var t = CreateTimer();
                timerdialog dialog = null;
                if (IsLocalHero)
                {
                    dialog = timerdialog.Create(t);
                    dialog.SetTitle("Возрождение");
                    TimerDialogDisplay(dialog, true);
                }
                TimerStart(t, TIME_RESPAWN, false, () =>
                {
                    var region = Regions.HeroSpawn;
                    ReviveHero(Hero, region.Center.X, region.Center.Y, false);
                    LockCamera();
                    DestroyTimer(t);
                    DestroyTrigger(triggerRespawn);
                    if (IsLocalHero)
                    {
                        TimerDialogDisplay(dialog, false);
                        DestroyTimerDialog(dialog);
                    }
                });
            });

            triggerRespawn.Execute();
        }

        private void LockCamera()
        {
#if DEBUG
            return;

#else
            if (IsLocalHero)
            {
                SetCameraTargetController(Hero, 0, 0, false);
            }
#endif
        }
    }
}
