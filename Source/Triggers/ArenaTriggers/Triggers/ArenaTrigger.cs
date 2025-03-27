using Source.Data;
using Source.Triggers.Base;
using Source.Triggers.GUITriggers.Triggers;
using System;
using System.Linq;
using WCSharp.Api;
using WCSharp.Events;
using static WCSharp.Api.Common;
using static Source.Extensions.CommonExtensions;
using Source.Triggers.HeroTriggers.Triggers;
namespace Source.Triggers.ArenaTriggers.Triggers
{
    public class ArenaTrigger : TriggerInstance
    {
        private trigger _timerTrigger;
        private static timer _timerStartArena;
        private timerdialog _dialogWaitArena;
        private GUIHeroWidgetTrigger[] _widgetsTriggers;
        private const int ARENA_TIMER_TURN_SECONDS = 300;
        public override trigger GetTrigger()
        {
            _timerTrigger = trigger.Create();

            _timerTrigger.AddAction(TurnTimerArena);

            return _timerTrigger;
        }

        private void TurnTimerArena()
        {
            if (HeroSelectMenuTrigger.AllUsersSelectedHero)
            {
                _timerStartArena = timer.Create();

                _timerStartArena.Start(ARENA_TIMER_TURN_SECONDS, false, TurnArena);
                _dialogWaitArena = timerdialog.Create(_timerStartArena);
                _dialogWaitArena.SetTitle("Дуэль");
                TimerDialogDisplay(_dialogWaitArena, true);
            }
        }

        private void TurnArena()
        {
            TimerDialogDisplay(_dialogWaitArena, false);
            DestroyTimerDialog(_dialogWaitArena);
            DestroyTimer(_timerStartArena);

            // start arena logic

           var allHeroes = PlayerHeroesList.Heroes.Where(h => h.Alive).ToArray();
            if (allHeroes.Length < 2)
            {
                TurnTimerArena();
                Console.WriteLine("Дуэль отменена, недостаточно живых игроков.");
            }

            else
            {
                trigger triggerArenaLogic = trigger.Create();
                triggerArenaLogic.AddAction(() => StartBattle(triggerArenaLogic));
                triggerArenaLogic.Execute();
            }
        }

        private void StartBattle(trigger calledTrigger)
        {
            DestroyTrigger(calledTrigger);
            var pointLeft = Regions.ArenaSpawnLeftPlayer.Center;
            var pointRight = Regions.ArenaSpawnRightPlayer.Center;
            var allHeroes = PlayerHeroesList.Heroes.Where(h => h.Alive).ToList();

            int indexFirstPlayer = GetRandomInt(0, allHeroes.Count - 1);

            var firstSelectedHero = allHeroes[indexFirstPlayer];

            var othersHeroes = allHeroes;

            othersHeroes.Remove(firstSelectedHero);

            var indexEnemyPlayer = GetRandomInt(0, othersHeroes.Count - 1);
            var enemyPlayer = othersHeroes[indexEnemyPlayer];
            enemyPlayer.X = pointRight.X;
            enemyPlayer.Y = pointRight.Y;
            firstSelectedHero.X = pointLeft.X;
            firstSelectedHero.Y = pointLeft.Y;

            PauseUnitWithStand(enemyPlayer);
            PauseUnitWithStand(firstSelectedHero);

            timer timerBeginBattle = timer.Create();
            timerBeginBattle.Start(5, false, () => BeginBattle(firstSelectedHero, enemyPlayer, timerBeginBattle));
            _dialogWaitArena = timerdialog.Create(timerBeginBattle);
            _dialogWaitArena.SetTitle("Дуэль начнется через");
            TimerDialogDisplay(_dialogWaitArena, true);
            Console.WriteLine($"Новая дуэль: {firstSelectedHero.Owner.Name} VS {enemyPlayer.Owner.Name}");
        }

        private void BeginBattle(unit firstSelectedHero, unit enemyPlayer, timer timerStart)
        {
            enemyPlayer.Life = enemyPlayer.MaxLife;
            enemyPlayer.Mana = enemyPlayer.MaxMana;
            firstSelectedHero.Life = firstSelectedHero.MaxLife;
            firstSelectedHero.Mana = firstSelectedHero.MaxMana;
            var pointLeft = Regions.ArenaSpawnLeftPlayer.Center;
            var pointRight = Regions.ArenaSpawnRightPlayer.Center;
            TimerDialogDisplay(_dialogWaitArena, false);
            DestroyTimerDialog(_dialogWaitArena);
            DestroyTimer(timerStart);
            PauseUnit(enemyPlayer, false);
            PauseUnit(firstSelectedHero, false);

            if (firstSelectedHero.Owner.Controller == mapcontrol.Computer)
            {
                IssuePointOrder(firstSelectedHero, "attack", pointRight.X, pointRight.Y);
            }

            if (enemyPlayer.Owner.Controller == mapcontrol.Computer)
            {
                IssuePointOrder(enemyPlayer, "attack", pointLeft.X, pointLeft.Y);
            }

            SetupWidgetsHeroes(firstSelectedHero, enemyPlayer);

            trigger triggerKillPlayer = trigger.Create();
            triggerKillPlayer.RegisterPlayerUnitEvent(enemyPlayer.Owner, playerunitevent.Death);
            triggerKillPlayer.RegisterPlayerUnitEvent(firstSelectedHero.Owner, playerunitevent.Death);

            triggerKillPlayer.AddAction(() =>
            {
                DestroyTrigger(triggerKillPlayer);
                EndBattle();
            });
        }

        private void EndBattle()
        {
            var killingPlayer = GetKillingUnit();
            var killedlayer = GetTriggerUnit();

            Console.WriteLine($"Игрок {killingPlayer.Owner.Name} победил игрока {killedlayer.Owner.Name}");
            GUIHeroWidgetTrigger.DestroyWidget(killingPlayer.Owner);
            PauseUnit(killingPlayer, true);

            timer timerRestartNewArena = timer.Create();

            timerRestartNewArena.Start(4, false, () =>
            {
                PauseUnit(killingPlayer, false);
                killingPlayer.Life = killingPlayer.MaxLife;
                killingPlayer.Mana = killingPlayer.MaxMana;
                var regionTown = Regions.HeroSpawn.GetRandomPoint();
                killingPlayer.X = regionTown.X;
                killingPlayer.Y = regionTown.Y;
                DestroyTimer(timerRestartNewArena);
                TurnTimerArena();
            });
        }

        private void SetupWidgetsHeroes(unit firstSelectedHero, unit enemyPlayer)
        {
            _widgetsTriggers = new GUIHeroWidgetTrigger[]
            {
               new(firstSelectedHero),
               new(enemyPlayer),
            };

            foreach (var trigger in _widgetsTriggers)
            {
                trigger.GetTrigger().Execute();
            }

            RegisterRemovingWidgets(firstSelectedHero, enemyPlayer);
        }

        private void RegisterRemovingWidgets(unit firstSelectedHero, unit enemyPlayer)
        {
            PlayerUnitEvents.Register(UnitEvent.Dies, () => RemoveHeroWidget(firstSelectedHero), firstSelectedHero);
            PlayerUnitEvents.Register(UnitEvent.Dies, () => RemoveHeroWidget(enemyPlayer), enemyPlayer);
        }

        private void RemoveHeroWidget(unit hero)
        {
            PlayerUnitEvents.Unregister(UnitEvent.Dies, () => RemoveHeroWidget(hero), hero);

            GUIHeroWidgetTrigger.DestroyWidget(hero.Owner);
        }

        public static void StopTickingNewArena ()
        {
            _timerStartArena.Pause();
        }

        public static void ContinueTickingNewArena()
        {
            _timerStartArena.Resume();
        }
    }
}
