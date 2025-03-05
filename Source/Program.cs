using Source.Models;
using System;
using System.Linq;
using WCSharp.Api;
using WCSharp.Events;
using WCSharp.Shared;
using WCSharp.Sync;
using static WCSharp.Api.Common;

namespace Source
{
	public static class Program
	{
		public static bool Debug { get; private set; } = false;
		private static timer _currentTimerWave;
		private static int _currentIndexWave;
		private static bool _waveEnded;
		private static EnemyWave[] _waves;
        private static EnemyWave _currentWave;

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

                EnemyInit();
				InitWaves();
#endif

            }
            catch (Exception ex)
			{
				DisplayTextToPlayer(GetLocalPlayer(), 0, 0, ex.Message);
			}
		}

        private static void EnemyInit()
        {
            player enemyPlayer = player.Create(11);
            enemyPlayer.Controller = mapcontrol.Computer;
            enemyPlayer.Name = "Monsters";
        }

		private static void InitWaves ()
		{
			_waves = WavesList.GetAllWaves().ToArray();
			StartNextWave();
		}

		private static void StartNextWave ()
		{
			if (_currentIndexWave < _waves.Length - 1)
			{
				_currentWave = _waves[_currentIndexWave];

				_currentTimerWave = timer.Create();
				_currentTimerWave.Start(0.5f, true, () =>
				{
					_currentWave.Turn();
					if (_currentWave.Count == 0)
					{
						DestroyTimer(_currentTimerWave);
					}
				});
			}
		}
    }
}
