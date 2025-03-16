using Source.Data;
using Source.Data.Dungeons;
using Source.Data.Dungeons.Windows;
using Source.Systems;
using Source.Triggers.Base;
using System;
using System.Linq;
using WCSharp.Api;
using WCSharp.Shared.Data;
using static WCSharp.Api.Common;
namespace Source.Triggers.DungeonsTriggers.Triggers
{
    public class DungeonRoomZoneTrigger : TriggerInstance
    {
        public DungeonRoomZoneTrigger(DungeonInstance targetDungeon, region regionEnter)
        {
            TargetDungeon = targetDungeon;
            RegionEnter = regionEnter;
        }

        public DungeonInstance TargetDungeon { get; private set; }
        public region RegionEnter { get; private set; }
        public override trigger GetTrigger()
        {
            var triggerEnter = trigger.Create();

            triggerEnter.RegisterEnterRegion(RegionEnter, null);
            triggerEnter.AddAction(EnterDungeon);

#if DEBUG
            Console.WriteLine($"created trigger zone enter for {TargetDungeon.GetDungeonName()}");
#endif
            return triggerEnter;
        }

        private void EnterDungeon ()
        {
            var unit = GetTriggerUnit();

            if (PlayerHeroesList.Contains(unit))
            {
                var requireLevelDungeon = TargetDungeon.GetRequiredLevelHero();

                if (unit.HeroLevel <  requireLevelDungeon)
                {
                    DisplayTextToPlayer(unit.Owner, 0, 0, "Уровень вашего героя меньше требуемого уровня для этого рейда.");
                    return;
                }

                else
                {
                    JoinDungeon(unit);
                }
            }
        }

        private void JoinDungeon(unit hero)
        {
           bool dungeonJoined = DungeonsSystem.TryJoinDungeon(TargetDungeon, hero.Owner, out DungeonRoomData room);

            if (!dungeonJoined)
            {
                DisplayTextToPlayer(hero.Owner, 0, 0, "Невозможно создать комнату рейда. Текущий начатый рейд не завершен либо тайм-аут, приходите когда он закончится.");
            }

            else
            {
                if (hero.Owner == player.LocalPlayer)
                {
                    DungeonRoomWindow roomWindow = new DungeonRoomWindow(room);
                    roomWindow.Show();
                    PauseUnit(hero, true);
                    hero.IsInvulnerable = true;
                }
            }
        }
    }
}
