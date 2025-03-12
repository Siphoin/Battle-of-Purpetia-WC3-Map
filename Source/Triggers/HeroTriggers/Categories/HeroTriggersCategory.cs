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
            HeroSelectMenuTrigger heroSelectMenuTrigger = new HeroSelectMenuTrigger();
          triggers.Add(heroSelectMenuTrigger);
            

           
            return triggers;
        }
    }
}
