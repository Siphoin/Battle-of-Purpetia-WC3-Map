using Source.Triggers.Base;
using System;
using WCSharp.Api;
using WCSharp.Shared.Data;
using static WCSharp.Api.Common;
namespace Source.Triggers.TownTriggers.Triggers
{
    public abstract class NoViolanceAreaTownTrigger : TriggerInstance
    {
        protected Rectangle Rectangle { get; private set; }
        protected NoViolanceAreaTownTrigger(Rectangle rectangle)
        {
            Rectangle = rectangle;
        }

        public override trigger GetTrigger()
        {
            trigger triggerInit = trigger.Create();
            triggerInit.AddAction(Init);
            return triggerInit;
        }

        private void Init()
        {
            trigger enterTrigger = trigger.Create();
            enterTrigger.RegisterLeaveRegion(Rectangle.Region);
            enterTrigger.AddAction(() =>
            {
                var unit = GetTriggerUnit();
                OnEnterTown(unit);
            });

            trigger leaveTrigger = trigger.Create();
            leaveTrigger.RegisterLeaveRegion(Rectangle.Region);
            leaveTrigger.AddAction(() =>
            {
                var unit = GetTriggerUnit();
                OnLeaveTown(unit);
            });
        }

        protected abstract void OnEnterTown(unit unit);
        protected abstract void OnLeaveTown(unit unit);
    }
}
