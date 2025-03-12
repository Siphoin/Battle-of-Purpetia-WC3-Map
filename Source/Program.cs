using Source.Triggers.ArenaTriggers.Categories;
using Source.Triggers.Base;
using Source.Triggers.CameraTriggers.Categories;
using Source.Triggers.DebugTriggers.Category;
using Source.Triggers.DungeonsTriggers.Categories;
using Source.Triggers.GUITriggers.Categories;
using Source.Triggers.HeroTriggers.Categories;
using Source.Triggers.MonsterAreaSystem.Categories;
using Source.Triggers.TownTriggers.Categories;
using System;
using WCSharp.Events;
using WCSharp.Shared;
using WCSharp.Sync;
using static WCSharp.Api.Common;

namespace Source
{
    public static class Program
	{
		public static bool Debug { get; private set; } = false;

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
                Debug = true;
                PeriodicEvents.EnableDebug();
                PlayerUnitEvents.EnableDebug();
                SyncSystem.EnableDebug();
                Delay.EnableDebug();
#endif
				InitTriggers();
            }
            catch (Exception ex)
			{
				DisplayTextToPlayer(GetLocalPlayer(), 0, 0, ex.Message);
			}
		}

		private static void InitTriggers ()
		{
			var categories = new TriggerCategory[]
			{
				new GUITriggersCategory(),
				new HeroTriggersCategory(),
				new CameraTriggersCategory(),
				new MonsterTriggersCategory(),
				new TownTriggersCategory(),
				new ArenaTriggersCategory(),
				new DungeonTriggersCategory(),
#if DEBUG
				new DebugTriggersCategory(),
	#endif
			};

			foreach (var category in categories)
			{
				category.Init();
				if (category.IsExecutedOnStart())
				{
                    category.Execute();
                }
			}
		}
    }
}
