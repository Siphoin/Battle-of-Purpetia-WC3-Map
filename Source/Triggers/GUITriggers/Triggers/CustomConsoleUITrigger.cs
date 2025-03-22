using Source.Data;
using Source.Data.Dungeons.Windows;
using Source.Systems;
using Source.Systems.WindowsSystems;
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
    public class CustomConsoleUITrigger : TriggerInstance
    {
        private framehandle buttonDungeons;
        private framehandle buttonDungeonsText;
        private framehandle BackdropbuttonDungeons;

        private WindowGUIBase _currentOpenedWindow;

        public trigger TriggerbuttonDungeons { get; private set; }

        public override trigger GetTrigger()
        {
            trigger triggerGUI = trigger.Create();
            triggerGUI.AddAction(CreateGUI);
            return triggerGUI;
        }

        private void CreateGUI()
        {
            #region Buttons
            buttonDungeons = BlzCreateFrame("IconButtonTemplate", BlzGetOriginFrame(ORIGIN_FRAME_GAME_UI, 0), 0, 0);
            BlzFrameSetAbsPoint(buttonDungeons, FRAMEPOINT_TOPLEFT, 0.000220000f, 0.602230f);
            BlzFrameSetAbsPoint(buttonDungeons, FRAMEPOINT_BOTTOMRIGHT, 0.111890f, 0.562080f);

            BackdropbuttonDungeons = BlzCreateFrameByType("BACKDROP", "BackdropbuttonDungeons", buttonDungeons, "", 0);
            BlzFrameSetAllPoints(BackdropbuttonDungeons, buttonDungeons);
            BlzFrameSetTexture(BackdropbuttonDungeons, "CustomConsoleUI/buttonOpenDungeons.blp", 0, true);
            TriggerbuttonDungeons = CreateTrigger();
            BlzTriggerRegisterFrameEvent(TriggerbuttonDungeons, buttonDungeons, FRAMEEVENT_CONTROL_CLICK);
            TriggerAddAction(TriggerbuttonDungeons, OpenDungeonsWindow);

            buttonDungeonsText = BlzCreateFrameByType("TEXT", "name", buttonDungeons, "", 0);
            BlzFrameSetAbsPoint(buttonDungeonsText, FRAMEPOINT_TOPLEFT, 0.0189500f, 0.589310f);
            BlzFrameSetAbsPoint(buttonDungeonsText, FRAMEPOINT_BOTTOMRIGHT, 0.0889500f, 0.569310f);
            BlzFrameSetText(buttonDungeonsText, "|cffffffffРейды|r");
            BlzFrameSetEnable(buttonDungeonsText, false);
            BlzFrameSetScale(buttonDungeonsText, 1.00f);
            BlzFrameSetTextAlignment(buttonDungeonsText, TEXT_JUSTIFY_CENTER, TEXT_JUSTIFY_MIDDLE);
            #endregion

            #region Player Resources Widget

            #endregion


        }

        private void OpenDungeonsWindow()
        {
            var player = GetTriggerPlayer();

            if (player != player.LocalPlayer)
            {
                return;
            }
            var dungeons = DungeonsSystem.AvalableDungeons;

            if (!dungeons.Any())
            {
                DisplayTextToPlayer(player.LocalPlayer, 0, 0, "Ваш уровень героя недостаточен чтобы попасть на рейд.");
                return;
            }

            if (PlayerHeroesList.GetLocalPlayerHero() is null)
            {
                DisplayTextToPlayer(player.LocalPlayer, 0, 0, "Еще не выбран герой.");
                return;
            }
            DungeonSelectWindow dungeonSelectWindow = new();
            OpenWindow(dungeonSelectWindow);
        }

        private void OpenWindow(WindowGUIBase window)
        {
            _currentOpenedWindow?.Destroy();
            window.Show();
            _currentOpenedWindow = window;
        }
    }

    public class PlayerResourcesWidget
    {
        private player TargetPlayer { get; set; }

        public void Create ()
        {

        }
    }
}
