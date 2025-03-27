using WCSharp.Api;
using WCSharp.Shared.Data;
namespace Source.Triggers.TownTriggers.Triggers
{
    public class NoViolanceAreaTownTriggernteraction : NoViolanceAreaTownTrigger
    {
        public NoViolanceAreaTownTriggernteraction(Rectangle rectangle) : base(rectangle)
        {
        }

        protected override void OnEnterTown(unit unit)
        {
            unit.IsInvulnerable = false;
        }

        protected override void OnLeaveTown(unit unit)
        {
            unit.IsInvulnerable = true;
        }
    }
}
