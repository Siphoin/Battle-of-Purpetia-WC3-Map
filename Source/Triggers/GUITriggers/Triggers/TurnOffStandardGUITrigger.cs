using Source.Triggers.Base;
using System;
using System.Reflection;
using WCSharp.Api;
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
            BlzHideOriginFrames(true);

                var portait = BlzGetOriginFrame(originframetype.Portrait, 0);
                BlzFrameSetSize(portait, portait.Width / 1.2f, portait.Height / 1.2f);
                BlzFrameSetVisible(portait, true);

                var fh = BlzFrameGetParent(BlzGetOriginFrame(originframetype.MinimapButton, 0));
                BlzFrameSetVisible(fh, true);
                
                fh = BlzGetFrameByName("MinimapSignalButton", 0);
                BlzFrameSetVisible(fh, true);

                fh = BlzGetOriginFrame(originframetype.ItemButton, 0);
                BlzFrameSetVisible(fh, true);
                fh = BlzGetOriginFrame(originframetype.HeroBar, 0);

                BlzFrameSetParent(fh, BlzGetOriginFrame(ORIGIN_FRAME_GAME_UI, 0));

                fh = BlzGetOriginFrame(originframetype.HeroButton, 0);

                BlzFrameSetParent(fh, BlzGetOriginFrame(originframetype.HeroBar, 0));

                fh = BlzGetFrameByName("MiniMapTerrainButton", 0);
                BlzFrameSetVisible(fh, false);

                fh = BlzGetFrameByName("MiniMapAllyButton", 0);
                BlzFrameSetVisible(fh, false);

                fh = BlzGetFrameByName("MiniMapCreepButton", 0);
                BlzFrameSetVisible(fh, false);

                fh = BlzGetFrameByName("FormationButton", 0);
                BlzFrameSetVisible(fh, false);

                BlzFrameSetVisible(BlzGetFrameByName("ConsoleTopBarBackrop", 0), false);

                for (int i = 0; i < 6; i++)
                {
                    fh = BlzGetFrameByName($"InventoryButton_{i}", 0);
                    BlzFrameSetParent(fh, BlzGetOriginFrame(ORIGIN_FRAME_GAME_UI, 0));
                    BlzFrameSetVisible(fh, true);
                    Console.WriteLine(fh.Alpha);

                }

                fh = BlzGetOriginFrame(originframetype.HeroBar, 0);

                fh = BlzGetOriginFrame(originframetype.Minimap, 0);
                BlzFrameSetVisible(fh, true);

                fh = BlzGetOriginFrame(originframetype.UnitPanelBuffBar, 0);
                BlzFrameSetVisible(fh, true);

                fh = BlzGetFrameByName("UpperButtonBarQuestsButton", 0);

                foreach (var frame in _targeHideFrames)
                {
                    BlzFrameSetAlpha(frame.GetOriginFrame(0), 0);
                    BlzFrameSetVisible(frame.GetOriginFrame(0), true);

                }
            });
            return newTrigger;
        }
    }
}
