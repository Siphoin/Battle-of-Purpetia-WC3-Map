using Source.Triggers.Base;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Drawing;
using WCSharp.Api;
using static System.Formats.Asn1.AsnWriter;
using static System.Net.Mime.MediaTypeNames;
using static WCSharp.Api.Common;
namespace Source.Triggers.GUITriggers.Triggers
{
    public class TurnOffStandardGUITrigger : TriggerInstance
    {

        private static originframetype[] _targeHideFrames = new originframetype[]
        {
          originframetype.HeroBar,

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
