using Source.Triggers.Base;
using WCSharp.Api;
using static WCSharp.Api.Common;
namespace Source.Triggers.TownTriggers.Triggers
{
    public class NoViolanceAreaTownTriggerOn : TriggerInstance
    {

        public override trigger GetTrigger()
        {
            trigger newTrigger = trigger.Create();
            newTrigger.RegisterEnterRegion(Regions.NoViolanceArea.Region);
            newTrigger.AddAction(SetOffViolance);
            return newTrigger;
        }

        private void SetOffViolance()
        {
            var unit = GetTriggerUnit();
            unit.IsInvulnerable = true;


        }
    }
}
