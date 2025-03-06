﻿using Source.Models;
using Source.Triggers.Base;
using Source.Triggers.MonsterAreaSystem.Categories;
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
				new MonsterTriggersCategory(),
			};

			foreach (var category in categories)
			{
				category.Init();
				category.Execute();
			}
		}
    }
}
