using Source.Triggers.Base;
using System;
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
            BlzHideOriginFrames(true);
                BlzFrameSetVisible(BlzGetFrameByName("ConsoleUI", 0), true);
                BlzFrameSetVisible(BlzGetOriginFrame(ORIGIN_FRAME_SYSTEM_BUTTON, 0), true);
                BlzEnableUIAutoPosition(false);

                var portait = BlzGetOriginFrame(originframetype.Portrait, 0);
                BlzFrameSetSize(portait, portait.Width / 1.2f, portait.Height / 1.2f);
                BlzFrameSetVisible(portait, true);
                BlzFrameSetVisible(BlzGetFrameByName("ConsoleUI", 0), true); // Hide Black Backdrop

                var fh = BlzFrameGetParent(BlzGetOriginFrame(originframetype.MinimapButton, 0));
                BlzFrameSetVisible(fh, true);
                
                fh = BlzGetFrameByName("MinimapSignalButton", 0);
                BlzFrameSetVisible(fh, true);

                fh = BlzGetFrameByName("MiniMapTerrainButton", 0);
                BlzFrameSetVisible(fh, false);

                fh = BlzGetFrameByName("MiniMapAllyButton", 0);
                BlzFrameSetVisible(fh, false);

                fh = BlzGetFrameByName("MiniMapCreepButton", 0);
                BlzFrameSetVisible(fh, false);

                fh = BlzGetFrameByName("FormationButton", 0);
                BlzFrameSetVisible(fh, false);

                fh = BlzGetOriginFrame(originframetype.HeroBar, 0);
                BlzFrameSetVisible(fh, true);

                fh = BlzGetOriginFrame(originframetype.Minimap, 0);
                BlzFrameSetVisible(fh, true);

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
