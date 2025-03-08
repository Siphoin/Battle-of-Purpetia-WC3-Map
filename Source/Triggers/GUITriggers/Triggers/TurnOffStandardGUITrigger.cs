using Source.Triggers.Base;
using WCSharp.Api;
using static WCSharp.Api.Common;
namespace Source.Triggers.GUITriggers.Triggers
{
    public class TurnOffStandardGUITrigger : TriggerInstance
    {

        private static originframetype[] _targeHideFrames = new originframetype[]
        {
          originframetype.HeroLifeBar,
          originframetype.HeroManaBar,

        };
        public override trigger GetTrigger()
        {
            trigger newTrigger = trigger.Create();
            newTrigger.AddAction(() =>
            {
                foreach (var frame in _targeHideFrames)
                {
                    BlzFrameSetAlpha(frame.GetOriginFrame(0), 0);
                    BlzFrameSetVisible(frame.GetOriginFrame(0), false);

                }


            });
            return newTrigger;
        }
    }
}
