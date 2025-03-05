using Source.Models;
using System;
using System.Linq;
using WCSharp.Api;
using WCSharp.Events;
using WCSharp.Shared;
using WCSharp.Shared.Extensions;
using WCSharp.Sync;
using static WCSharp.Api.Common;

namespace Source
{
	public static class Program
	{
		public static bool Debug { get; private set; } = false;
		private static timer _currentTimerWave;
		private static int _currentIndexWave = -1;
		private static bool _waveEnded;
		private static EnemyWave[] _waves;
        private static EnemyWave _currentWave;
		private static group _enemyGroup;

        public static void Main()
		{
			// Delay a little since some stuff can break otherwise
			var timer = CreateTimer();
			TimerStart(timer, 0.01f, false, () =>
			{
				DestroyTimer(timer);
				Start();
			});
		}

		private static void Start()
		{
			try
            {
#if DEBUG
                // This part of the code will only run if the map is compiled in Debug mode
                Debug = true;
                Console.WriteLine("This map is in debug mode. The map may not function as expected.");
                // By calling these methods, whenever these systems call external code (i.e. your code),
                // they will wrap the call in a try-catch and output any errors to the chat for easier debugging
                PeriodicEvents.EnableDebug();
                PlayerUnitEvents.EnableDebug();
                SyncSystem.EnableDebug();
                Delay.EnableDebug();
#endif

                EnemyInit();
                InitWaves();
				ListenDiePortal();

            }
            catch (Exception ex)
			{
				DisplayTextToPlayer(GetLocalPlayer(), 0, 0, ex.Message);
			}
		}

        private static void EnemyInit()
        {
			player enemyPlayer = MapConfig.EnemyPlayerWave;
            enemyPlayer.Controller = mapcontrol.Computer;
			enemyPlayer.SetState(PLAYER_STATE_GIVES_BOUNTY, 1);
        }

		private static void InitWaves ()
		{
			_enemyGroup = group.Create();
			_waves = WavesList.GetAllWaves().ToArray();
			StartNextWave();
		}

		private static void ListenDiePortal ()
		{
			PlayerUnitEvents.Register(UnitEvent.Dies, GameOver, Portal.GetPortal());
        }

		private static void ListenDieEnemy(unit unit)
		{
            PlayerUnitEvents.Register(UnitEvent.Dies, EnemyDie, unit);
        }

		private static void ListenEnterPortal ()
		{
		}

        private static void EnemyDie()
        {
			var unit = _enemyGroup.ToList().Last();
            PlayerUnitEvents.Unregister(UnitEvent.Dies, EnemyDie, unit);

			_enemyGroup.Remove(unit);

			if (_enemyGroup.Count == 0)
			{
				StartNextWave();
			}
        }

        private static void GameOver ()
		{
			if (!Portal.GetPortal().Alive)
			{
                Console.WriteLine("45456");
                player p = Player(0);
                p.SetState(PLAYER_STATE_GAME_RESULT, PLAYER_GAME_RESULT_DEFEAT.HandleId);
            }
		}

		private static void StartNextWave ()
		{
		    
			if (_currentIndexWave < _waves.Length - 1)
			{
				_currentIndexWave++;
				_currentWave = _waves[_currentIndexWave];

				_currentTimerWave = timer.Create();
				_currentTimerWave.Start(0.5f, true, () =>
				{
					var unit = _currentWave.Turn();
					_enemyGroup.Add(unit);
                    ListenDieEnemy(unit);
                    if (_currentWave.Count == 0)
					{
						DestroyTimer(_currentTimerWave);
					}
				});
			}
		}
    }
}
