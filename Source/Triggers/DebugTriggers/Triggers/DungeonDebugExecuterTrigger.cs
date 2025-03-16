using Source.Data;
using Source.Systems;
using Source.Triggers.Base;
using System;
using System.Collections.Generic;
using WCSharp.Api;
using WCSharp.Shared;
using static WCSharp.Api.Common;
namespace Source.Triggers.DebugTriggers.Triggers
{
    public class DungeonDebugExecuterTrigger : TriggerInstance
    {
        public override trigger GetTrigger()
        {
            trigger debugTrigger = trigger.Create();
            debugTrigger.RegisterPlayerChatEvent(Player(0), "StartDungeon", false);
            debugTrigger.AddAction(() =>
            {
                var message = GetEventPlayerChatString();
                var parts = message.Split(' '); // Разделяем строку по пробелам

                if (parts.Length > 1 && int.TryParse(parts[1], out int dungeonNumber))
                {
                    List<player> players = new List<player>();

                    var heroes = PlayerHeroesList.Heroes;

                    foreach (var hero in heroes)
                    {
                        players.Add(hero.Owner);
                    }
                    DungeonsSystem.TurnDungeon(dungeonNumber - 1, players);
                }
            });
            return debugTrigger;
        }
    }
}
