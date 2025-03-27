﻿using Source.Data;
using Source.Data.Dungeons.Windows;
using Source.Extensions;
using Source.Systems;
using Source.Systems.WindowsSystems;
using Source.Triggers.Base;
using System;
using System.Linq;
using WCSharp.Api;
using static WCSharp.Api.Common;
using static Source.Extensions.CommonExtensions;
using Source.Data.Inventory.Windows;
using Source.Data.Inventory;
namespace Source.Triggers.GUITriggers.Triggers
{
    public class CustomConsoleUITrigger : TriggerInstance
    {
        private framehandle buttonDungeons;
        private framehandle buttonDungeonsText;
        private framehandle BackdropbuttonDungeons;

        private WindowGUIBase _currentOpenedWindow;
        private framehandle buttonMenu;
        private framehandle buttonMenuText;
        private framehandle BackdropbuttonMenu;
        private framehandle localPlayerInventoryButton;
        private framehandle BackdroplocalPlayerInventoryButton;
        private InventoryWindow _inventoryWindow;

        public trigger TriggerbuttonDungeons { get; private set; }
        public trigger TriggerbuttonMenu { get; private set; }
        public trigger TriggerlocalPlayerInventoryButton { get; private set; }

        public override trigger GetTrigger()
        {
            trigger triggerGUI = trigger.Create();
            triggerGUI.AddAction(CreateGUI);
            return triggerGUI;
        }

        private void CreateGUI()
        {

            BlzFrameSetVisible(BlzGetFrameByName("UpperButtonBarFrame", 0), true);
BlzFrameSetVisible(BlzGetFrameByName("UpperButtonBarFrame", 0), true);
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


            buttonMenu = BlzCreateFrame("IconButtonTemplate", BlzGetOriginFrame(ORIGIN_FRAME_GAME_UI, 0), 0, 0);
BlzFrameSetAbsPoint(buttonMenu, FRAMEPOINT_TOPLEFT, 0.108710f, 0.601040f);
BlzFrameSetAbsPoint(buttonMenu, FRAMEPOINT_BOTTOMRIGHT, 0.220380f, 0.560890f);

BackdropbuttonMenu = BlzCreateFrameByType("BACKDROP", "BackdropbuttonMenu", buttonMenu, "", 0);
            BlzFrameSetAllPoints(BackdropbuttonMenu, buttonMenu);
BlzFrameSetTexture(BackdropbuttonMenu, "CustomConsoleUI/buttonOpenDungeons.blp", 0, true);
            TriggerbuttonMenu = CreateTrigger();
BlzTriggerRegisterFrameEvent(TriggerbuttonMenu, buttonMenu, FRAMEEVENT_CONTROL_CLICK);
TriggerAddAction(TriggerbuttonMenu, OpenMenu);

            buttonMenuText = BlzCreateFrameByType("TEXT", "name", buttonMenu, "", 0);
BlzFrameSetAbsPoint(buttonMenuText, FRAMEPOINT_TOPLEFT, 0.127090f, 0.589270f);
BlzFrameSetAbsPoint(buttonMenuText, FRAMEPOINT_BOTTOMRIGHT, 0.197090f, 0.568270f);
            string prefixMenuHotkey = "[" + "F10".Colorize(DEFAULT_WARCRAFT_III_TEXT_HEX) + "]";
            BlzFrameSetText(buttonMenuText, $"|cffffffffМеню|r {prefixMenuHotkey}");
BlzFrameSetEnable(buttonMenuText, false);
BlzFrameSetScale(buttonMenuText, 1.00f);
            BlzFrameSetTextAlignment(buttonMenuText, TEXT_JUSTIFY_CENTER, TEXT_JUSTIFY_MIDDLE);

            #endregion

            #region Player Resources Widget
            PlayerResourcesWidget playerResourcesWidget = new(player.LocalPlayer);
            playerResourcesWidget.Create();
            #endregion

            #region Inventory Local Player




            localPlayerInventoryButton = BlzCreateFrame("IconButtonTemplate", BlzGetOriginFrame(ORIGIN_FRAME_GAME_UI, 0), 0, 0);
            BlzFrameSetAbsPoint(localPlayerInventoryButton, FRAMEPOINT_TOPLEFT, 0.738010f, 0.211870f);
BlzFrameSetAbsPoint(localPlayerInventoryButton, FRAMEPOINT_BOTTOMRIGHT, 0.795010f, 0.150890f);

BackdroplocalPlayerInventoryButton = BlzCreateFrameByType("BACKDROP", "BackdroplocalPlayerInventoryButton", localPlayerInventoryButton, "", 0);
            BlzFrameSetAllPoints(BackdroplocalPlayerInventoryButton, localPlayerInventoryButton);
            BlzFrameSetTexture(BackdroplocalPlayerInventoryButton, "UI/Icons/inventory_icon.blp", 0, true);
            TriggerlocalPlayerInventoryButton = CreateTrigger();
BlzTriggerRegisterFrameEvent(TriggerlocalPlayerInventoryButton, localPlayerInventoryButton, FRAMEEVENT_CONTROL_CLICK);
TriggerAddAction(TriggerlocalPlayerInventoryButton, OpenLocalPlayerInventory);


            #endregion


        }

        private void OpenLocalPlayerInventory()
        {
            var localPlayer = PlayerHeroesList.GetLocalPlayerHero();

            _inventoryWindow = new InventoryWindow(CustomInventory.LocalPlayerInventory);
            _inventoryWindow.Show();
            SetStateEnabledLocalPlayerInventoryButton(false);
            _inventoryWindow.OnExit += OnExitInventoryWindow;
        }

        private void OnExitInventoryWindow()
        {
            _inventoryWindow.OnExit -= OnExitInventoryWindow;
            SetStateEnabledLocalPlayerInventoryButton(true);
        }

        private void SetStateEnabledLocalPlayerInventoryButton(bool state)
        {
            BlzFrameSetVisible(BackdroplocalPlayerInventoryButton, state);
            BlzFrameSetVisible(localPlayerInventoryButton, state);
            BlzFrameSetEnable(BackdroplocalPlayerInventoryButton, state);
            BlzFrameSetEnable(localPlayerInventoryButton, state);
        }

        private void OpenMenu()
        {
            var menuButton = BlzGetFrameByName("UpperButtonBarMenuButton", 0);

            BlzFrameClick(menuButton);
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
        private framehandle playerResourcesBackrop;
        private framehandle goldResourcesPlayerText;
        private framehandle woodResourcesPlayerText;

        private player TargetPlayer { get; set; }

        public PlayerResourcesWidget(player targetPlayer)
        {
            TargetPlayer = targetPlayer;
            PlayerResourcesSystem.OnWoodChanged += OnWoodChanged;
            PlayerResourcesSystem.OnGoldChanged += OnGoldChanged;
        }

        private void OnGoldChanged(player player, int amount)
        {
            if (player == TargetPlayer)
            {
                goldResourcesPlayerText.Text = amount.ToString();
            }
        }

        private void OnWoodChanged(player player, int amount)
        {
            if (player == TargetPlayer)
            {
                woodResourcesPlayerText.Text = amount.ToString();
            }
        }

        public void Create ()
        {


            playerResourcesBackrop = BlzCreateFrameByType("BACKDROP", "BACKDROP", BlzGetOriginFrame(ORIGIN_FRAME_GAME_UI, 0), "", 1);
BlzFrameSetAbsPoint(playerResourcesBackrop, FRAMEPOINT_TOPLEFT, 0.319220f, 0.580140f);
            BlzFrameSetAbsPoint(playerResourcesBackrop, FRAMEPOINT_BOTTOMRIGHT, 0.476590f, 0.534110f);
BlzFrameSetTexture(playerResourcesBackrop, "UI/resources_player_backrop.blp", 0, true);

goldResourcesPlayerText = BlzCreateFrameByType("TEXT", "name", playerResourcesBackrop, "", 0);
            BlzFrameSetPoint(goldResourcesPlayerText, FRAMEPOINT_TOPLEFT, playerResourcesBackrop, FRAMEPOINT_TOPLEFT, 0.035300f, -0.0092900f);
            BlzFrameSetPoint(goldResourcesPlayerText, FRAMEPOINT_BOTTOMRIGHT, playerResourcesBackrop, FRAMEPOINT_BOTTOMRIGHT, -0.018070f, 0.0067400f);
            BlzFrameSetTextAlignment(goldResourcesPlayerText, TEXT_JUSTIFY_CENTER, TEXT_JUSTIFY_LEFT);
            BlzFrameSetEnable(goldResourcesPlayerText, false);
            BlzFrameSetScale(goldResourcesPlayerText, 1.0f);

woodResourcesPlayerText = BlzCreateFrameByType("TEXT", "name", playerResourcesBackrop, "", 0);
            BlzFrameSetPoint(woodResourcesPlayerText, FRAMEPOINT_TOPRIGHT, playerResourcesBackrop, FRAMEPOINT_TOPRIGHT, -0.035300f, -0.0092900f);
BlzFrameSetPoint(woodResourcesPlayerText, FRAMEPOINT_BOTTOMLEFT, playerResourcesBackrop, FRAMEPOINT_BOTTOMLEFT, 0.018070f, 0.0067400f);
BlzFrameSetTextAlignment(woodResourcesPlayerText, TEXT_JUSTIFY_CENTER, TEXT_JUSTIFY_RIGHT);
BlzFrameSetEnable(woodResourcesPlayerText, false);
            BlzFrameSetScale(woodResourcesPlayerText, 1.0f);

            var currentGold = GetPlayerState(TargetPlayer, playerstate.ResourceGold);
            var currentWood = GetPlayerState(TargetPlayer, playerstate.ResourceLumber);
            OnGoldChanged(TargetPlayer, currentGold);
            OnWoodChanged(TargetPlayer, currentWood);


        }
    }
}
