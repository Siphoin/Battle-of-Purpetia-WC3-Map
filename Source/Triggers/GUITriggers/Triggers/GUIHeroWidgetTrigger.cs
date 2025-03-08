using Source.Triggers.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCSharp.Api;
using static WCSharp.Api.Common;
namespace Source.Triggers.GUITriggers.Triggers
{
    public class GUIHeroWidgetTrigger : TriggerInstance
    {
        public unit Hero { get; private set; }
        public GUIHeroWidgetTrigger(unit hero)
        {
            Hero = hero;
        }

        public override trigger GetTrigger()
        {
            trigger triggerWidget = trigger.Create();
            triggerWidget.AddAction(CreateWidget);
            return triggerWidget;

        }

        private void CreateWidget()
        {
            BlzLoadTOCFile("war3mapimported\\myBar.toc");
            var bar = BlzCreateSimpleFrame("MyBarEx", BlzGetOriginFrame(ORIGIN_FRAME_GAME_UI, 0), 1); //Create Bar at createContext 1
   var bar2 = BlzCreateSimpleFrame("MyBarEx", BlzGetOriginFrame(ORIGIN_FRAME_GAME_UI, 0), 2); //createContext 2
  var bar4 = BlzCreateSimpleFrame("MyBar", BlzGetOriginFrame(ORIGIN_FRAME_GAME_UI, 0), 4); //createContext 4, other names so would not be needed.
    BlzFrameSetAbsPoint(bar, FRAMEPOINT_CENTER, 0.5f, 0.3f); // pos the bar
    BlzFrameSetPoint(bar2, FRAMEPOINT_TOP, bar, FRAMEPOINT_BOTTOM, 0.0f, 0.0f); // pos bar2 below bar
    BlzFrameSetPoint(bar4, FRAMEPOINT_BOTTOM, bar, FRAMEPOINT_TOP, 0.0f, 0.0f); // pos bar4 above bar
    BlzFrameSetSize(bar4, 0.04f, 0.04f); //change the size of bar4

    BlzFrameSetValue(bar4, 35); //Starting value for bar 4.

   BlzFrameSetTexture(bar, "Replaceabletextures\\Teamcolor\\Teamcolor00.blp", 0, true); //change the BarTexture of bar to color red
    BlzFrameSetTexture(bar2, "Replaceabletextures\\Teamcolor\\Teamcolor01.blp", 0, true); //color blue for bar2
    BlzFrameSetTexture(bar4, "Replaceabletextures\\CommandButtons\\BTNHeroPaladin.blp", 0, true); //bar4 to Paladin-Face
   BlzFrameSetTexture(BlzGetFrameByName("MyBarBackground", 4), "Replaceabletextures\\CommandButtonsDisabled\\DISBTNHeroPaladin.blp", 0, true); //Change the background to DisabledPaladin-Face. ("MyBarBackground", 4) belongs to Bar4. would Bar4 be a "MyBarEx" one would have to write "MyBarExBackground" cause they are named differently in fdf.

            BlzFrameSetText(BlzGetFrameByName("MyBarExText", 1), "Life");
    BlzFrameSetText(BlzGetFrameByName("MyBarExText", 2), "Mana");
    BlzFrameSetText(BlzGetFrameByName("MyBarText", 4), I2S(R2I(BlzFrameGetValue(bar4))) + "%");

    DisplayTimedTextToPlayer(GetLocalPlayer(), 0, 0, 99999, "Select an unit to update the Bars");
        }
    }
}
