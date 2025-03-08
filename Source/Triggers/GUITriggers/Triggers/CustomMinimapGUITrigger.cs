using Source.Triggers.Base;
using System;
using WCSharp.Api;
using static WCSharp.Api.Common;
namespace Source.Triggers.GUITriggers.Triggers
{
    public class CustomMinimapGUITrigger : TriggerInstance
    {
        public override trigger GetTrigger()
        {
            trigger newTrigger = trigger.Create();

            newTrigger.AddAction(() =>
            {
            });

            return newTrigger;
        }
    }
}
