using Source.Models;
using Source.Triggers.Base;
using System.Collections.Generic;
using WCSharp.Api;
using static WCSharp.Api.Common;
namespace Source.Triggers.HeroTriggers.Categories
{
    public class HeroTriggersCategory : TriggerCategory
    {
        protected override IEnumerable<TriggerInstance> GetAllTriggers()
        {
            List<TriggerInstance> triggers = new List<TriggerInstance>();
            for (int i = 0; i < 2; i++)
            {
                var p = Player(i);
                if (p == player.NeutralPassive || p == player.NeutralAggressive || p == MapConfig.MonsterPlayer)
                {
                    continue;
                }
                HeroSpawnTrigger heroSpawnTrigger = new(player.Create(i), "H000:Harf");
                triggers.Add(heroSpawnTrigger);

                if (p.Controller == mapcontrol.Computer)
                {
                    StartMeleeAI(p, "map.ai");
                    var t = CreateTimer();
                    TimerStart(t, 0.3f, false, () =>
                    {
                        AIHeroTrigger aIHeroTrigger = new(heroSpawnTrigger.Hero);
                        aIHeroTrigger.GetTrigger().Execute();
                        DestroyTimer(t);
                    });

                    p.Name = $"AI {i + 1}";
                }

                    
                }
            

           
            return triggers;
        }
    }
}
