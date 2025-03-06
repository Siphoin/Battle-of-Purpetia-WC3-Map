using Source.Triggers.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCSharp.Api;
using WCSharp.Events;
using static WCSharp.Api.Common;
namespace Source.Triggers.HeroTriggers
{
    public class HeroSpawnTrigger : TriggerInstance
    {
        private player PlayerOwner { get; set; }
        private string IdHeroUnit { get; set; }
        public unit Hero { get;  private set; }

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
                Hero = unit.Create(PlayerOwner, FourCC(IdHeroUnit), 0, 0);
                PlayerUnitEvents.Register(UnitEvent.Dies, HeroRespawn, Hero);
                LockCamera();
            });

            return newTrigger;
        }

        private void HeroRespawn()
        {
            var region = Regions.HeroSpawn;
            ReviveHero(Hero, region.Center.X, region.Center.Y, false);
            LockCamera();
        }

        private void LockCamera()
        {
            if (Hero.Owner == player.LocalPlayer)
            {
                SetCameraTargetController(Hero, 0, 0, false);
            }
        }
    }
}
