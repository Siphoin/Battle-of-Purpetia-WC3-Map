using Source.Systems;
using Source.Systems.WindowsSystems;
using System;
using System.Collections.Generic;
using System.Linq;
using WCSharp.Api;
using static WCSharp.Api.Common;

namespace Source.Data.Dungeons.Windows
{
    public class DungeonRoomWindow : WindowGUIBase
    {
        private DungeonRoomData Room {  get; set; }
        private framehandle _dungeonWindowBackrop;
        private framehandle _dungeonWindowListPlayersBackrop;
        private framehandle _dungeonWindowLabelBackrop;
        private framehandle _dungeonWindowInfoBackrop;
        private framehandle _dungeonWindowLabelBackropText;
        private framehandle _dungeonWindowIconBackrop;
        private framehandle _dungeonWindowStartButtonBackrop;
        private framehandle _backdropDungeonWindowStartButtonBackrop;
        private trigger _triggerDungeonWindowStartButtonBackrop;
        private framehandle _dungeonWindowLeaveButtonBackrop;
        private framehandle _backdropDungeonWindowLeaveButtonBackrop;
        private trigger _triggerDungeonWindowLeaveButtonBackrop;
        private framehandle _dungeonNameText;
        private framehandle _dungeonDescriptionText;
        private framehandle _dungeonWindowKickPlayerButtonBackrop;
        private framehandle _backdropDungeonWindowKickPlayerButtonBackrop;
        private trigger _triggerDungeonWindowKickPlayerButtonBackrop;
        private framehandle _dungeonWindowPlayerSlotNameText;
        private framehandle _dungeonIcon;
        private framehandle _dungeonWindowStartButtonBackropText;
        private framehandle _dungeonWindowLeaveButtonBackropText;
        private framehandle _dungeonWindowKickPlayerButtonBackropText;

        private List<PlayerSlotFrame> _playerSlotBackdrops = new();

        public DungeonRoomWindow(DungeonRoomData room)
        {
            Room = room;
        }

        public override void Show()
        {
            _dungeonWindowBackrop = BlzCreateFrameByType("BACKDROP", "BACKDROP", BlzGetOriginFrame(ORIGIN_FRAME_GAME_UI, 0), "", 1);
            BlzFrameSetAbsPoint(_dungeonWindowBackrop, FRAMEPOINT_TOPLEFT, 0.00409000f, 0.574980f);
            BlzFrameSetAbsPoint(_dungeonWindowBackrop, FRAMEPOINT_BOTTOMRIGHT, 0.801420f, 0.000630000f);
            BlzFrameSetTexture(_dungeonWindowBackrop, "UI/dungeonWindowBackrop", 0, true);

            _dungeonWindowListPlayersBackrop = BlzCreateFrameByType("BACKDROP", "BACKDROP", _dungeonWindowBackrop, "", 1);
            BlzFrameSetPoint(_dungeonWindowListPlayersBackrop, FRAMEPOINT_TOPLEFT, _dungeonWindowBackrop, FRAMEPOINT_TOPLEFT, 0.042690f, -0.066510f);
            BlzFrameSetPoint(_dungeonWindowListPlayersBackrop, FRAMEPOINT_BOTTOMRIGHT, _dungeonWindowBackrop, FRAMEPOINT_BOTTOMRIGHT, -0.33464f, 0.089430f);
            BlzFrameSetTexture(_dungeonWindowListPlayersBackrop, "UI/dungeonWindowListPlayersBackrop", 0, true);

            _dungeonWindowLabelBackrop = BlzCreateFrameByType("BACKDROP", "BACKDROP", _dungeonWindowBackrop, "", 1);
            BlzFrameSetPoint(_dungeonWindowLabelBackrop, FRAMEPOINT_TOPLEFT, _dungeonWindowBackrop, FRAMEPOINT_TOPLEFT, 0.036000f, -0.014740f);
            BlzFrameSetPoint(_dungeonWindowLabelBackrop, FRAMEPOINT_BOTTOMRIGHT, _dungeonWindowBackrop, FRAMEPOINT_BOTTOMRIGHT, -0.55133f, 0.51961f);
            BlzFrameSetTexture(_dungeonWindowLabelBackrop, "UI/dungeonWindowLabelBackrop.blp", 0, true);

            _dungeonWindowInfoBackrop = BlzCreateFrameByType("BACKDROP", "BACKDROP", _dungeonWindowBackrop, "", 1);
            BlzFrameSetPoint(_dungeonWindowInfoBackrop, FRAMEPOINT_TOPLEFT, _dungeonWindowBackrop, FRAMEPOINT_TOPLEFT, 0.45788f, -0.070770f);
            BlzFrameSetPoint(_dungeonWindowInfoBackrop, FRAMEPOINT_BOTTOMRIGHT, _dungeonWindowBackrop, FRAMEPOINT_BOTTOMRIGHT, -0.057360f, 0.070110f);
            BlzFrameSetTexture(_dungeonWindowInfoBackrop, "UI/dungeonWindowInfoBackrop.blp", 0, true);

            _dungeonWindowLabelBackropText = BlzCreateFrameByType("TEXT", "name", _dungeonWindowLabelBackrop, "", 0);
            BlzFrameSetPoint(_dungeonWindowLabelBackropText, FRAMEPOINT_TOPLEFT, _dungeonWindowLabelBackrop, FRAMEPOINT_TOPLEFT, 0.0075300f, 0.0030500f);
            BlzFrameSetPoint(_dungeonWindowLabelBackropText, FRAMEPOINT_BOTTOMRIGHT, _dungeonWindowLabelBackrop, FRAMEPOINT_BOTTOMRIGHT, -0.012470f, 0.0030500f);
            BlzFrameSetText(_dungeonWindowLabelBackropText, "|cffffffffРейд|r");
            BlzFrameSetEnable(_dungeonWindowLabelBackropText, false);
            BlzFrameSetScale(_dungeonWindowLabelBackropText, 1.5f);
            BlzFrameSetTextAlignment(_dungeonWindowLabelBackropText, TEXT_JUSTIFY_CENTER, TEXT_JUSTIFY_MIDDLE);

            _dungeonWindowIconBackrop = BlzCreateFrameByType("BACKDROP", "BACKDROP", _dungeonWindowInfoBackrop, "", 1);
            BlzFrameSetPoint(_dungeonWindowIconBackrop, FRAMEPOINT_TOPLEFT, _dungeonWindowInfoBackrop, FRAMEPOINT_TOPLEFT, 0.080360f, -0.039260f);
            BlzFrameSetPoint(_dungeonWindowIconBackrop, FRAMEPOINT_BOTTOMRIGHT, _dungeonWindowInfoBackrop, FRAMEPOINT_BOTTOMRIGHT, -0.081730f, 0.28459f);
            BlzFrameSetTexture(_dungeonWindowIconBackrop, "UI/dungeonWindowIconBackrop.blp", 0, true);

            _dungeonWindowStartButtonBackrop = BlzCreateFrame("IconButtonTemplate", _dungeonWindowInfoBackrop, 0, 0);
            BlzFrameSetPoint(_dungeonWindowStartButtonBackrop, FRAMEPOINT_TOPLEFT, _dungeonWindowInfoBackrop, FRAMEPOINT_TOPLEFT, 0.023440f, -0.32683f);
            BlzFrameSetPoint(_dungeonWindowStartButtonBackrop, FRAMEPOINT_BOTTOMRIGHT, _dungeonWindowInfoBackrop, FRAMEPOINT_BOTTOMRIGHT, -0.12865f, 0.026640f);

            _backdropDungeonWindowStartButtonBackrop = BlzCreateFrameByType("BACKDROP", "BackdropdungeonWindowStartButtonBackrop", _dungeonWindowStartButtonBackrop, "", 0);
            BlzFrameSetAllPoints(_backdropDungeonWindowStartButtonBackrop, _dungeonWindowStartButtonBackrop);
            BlzFrameSetTexture(_backdropDungeonWindowStartButtonBackrop, "UI/dungeonWindowStartButtonBackrop.blp", 0, true);
            _triggerDungeonWindowStartButtonBackrop = CreateTrigger();
            BlzTriggerRegisterFrameEvent(_triggerDungeonWindowStartButtonBackrop, _dungeonWindowStartButtonBackrop, FRAMEEVENT_CONTROL_CLICK);
            TriggerAddAction(_triggerDungeonWindowStartButtonBackrop, StartDungeon);

            _dungeonWindowLeaveButtonBackrop = BlzCreateFrame("IconButtonTemplate", _dungeonWindowInfoBackrop, 0, 0);
            BlzFrameSetPoint(_dungeonWindowLeaveButtonBackrop, FRAMEPOINT_TOPLEFT, _dungeonWindowInfoBackrop, FRAMEPOINT_TOPLEFT, 0.13477f, -0.32683f);
            BlzFrameSetPoint(_dungeonWindowLeaveButtonBackrop, FRAMEPOINT_BOTTOMRIGHT, _dungeonWindowInfoBackrop, FRAMEPOINT_BOTTOMRIGHT, -0.017320f, 0.026640f);

            _backdropDungeonWindowLeaveButtonBackrop = BlzCreateFrameByType("BACKDROP", "BackdropdungeonWindowLeaveButtonBackrop", _dungeonWindowLeaveButtonBackrop, "", 0);
            BlzFrameSetAllPoints(_backdropDungeonWindowLeaveButtonBackrop, _dungeonWindowLeaveButtonBackrop);
            BlzFrameSetTexture(_backdropDungeonWindowLeaveButtonBackrop, "UI/dungeonWindowLeaveBackrop.blp", 0, true);
            _triggerDungeonWindowLeaveButtonBackrop = CreateTrigger();
            BlzTriggerRegisterFrameEvent(_triggerDungeonWindowLeaveButtonBackrop, _dungeonWindowLeaveButtonBackrop, FRAMEEVENT_CONTROL_CLICK);
            TriggerAddAction(_triggerDungeonWindowLeaveButtonBackrop, LeaveRoom);

            _dungeonNameText = BlzCreateFrameByType("TEXT", "name", _dungeonWindowInfoBackrop, "", 0);
            BlzFrameSetAbsPoint(_dungeonNameText, FRAMEPOINT_TOPLEFT, 0.543160f, 0.348250f);
            BlzFrameSetAbsPoint(_dungeonNameText, FRAMEPOINT_BOTTOMRIGHT, 0.663160f, 0.318250f);
            BlzFrameSetText(_dungeonNameText, $"|cffFFCC00{Room.TargetDungeon.GetDungeonName()}|r");
            BlzFrameSetEnable(_dungeonNameText, false);
            BlzFrameSetScale(_dungeonNameText, 1.57f);
            BlzFrameSetTextAlignment(_dungeonNameText, TEXT_JUSTIFY_CENTER, TEXT_JUSTIFY_MIDDLE);

            _dungeonDescriptionText = BlzCreateFrameByType("TEXT", "name", _dungeonWindowInfoBackrop, "", 0);
            BlzFrameSetPoint(_dungeonDescriptionText, FRAMEPOINT_TOPLEFT, _dungeonWindowInfoBackrop, FRAMEPOINT_TOPLEFT, 0.027620f, -0.16969f);
            BlzFrameSetPoint(_dungeonDescriptionText, FRAMEPOINT_BOTTOMRIGHT, _dungeonWindowInfoBackrop, FRAMEPOINT_BOTTOMRIGHT, -0.034470f, 0.12378f);
            BlzFrameSetText(_dungeonDescriptionText, $"|cffffffff{Room.TargetDungeon.GetDungeonDescription()}|r");
            BlzFrameSetEnable(_dungeonDescriptionText, false);
            BlzFrameSetScale(_dungeonDescriptionText, 1.00f);
            BlzFrameSetTextAlignment(_dungeonDescriptionText, TEXT_JUSTIFY_CENTER, TEXT_JUSTIFY_MIDDLE);

            _backdropDungeonWindowKickPlayerButtonBackrop = BlzCreateFrameByType("BACKDROP", "BackdropdungeonWindowKickPlayerButtonBackrop", _dungeonWindowKickPlayerButtonBackrop, "", 0);
            BlzFrameSetAllPoints(_backdropDungeonWindowKickPlayerButtonBackrop, _dungeonWindowKickPlayerButtonBackrop);
            BlzFrameSetTexture(_backdropDungeonWindowKickPlayerButtonBackrop, "UI/dungeonWindowKickPlayerButtonBackrop.blp", 0, true);
            _triggerDungeonWindowKickPlayerButtonBackrop = CreateTrigger();
            BlzTriggerRegisterFrameEvent(_triggerDungeonWindowKickPlayerButtonBackrop, _dungeonWindowKickPlayerButtonBackrop, FRAMEEVENT_CONTROL_CLICK);
            TriggerAddAction(_triggerDungeonWindowKickPlayerButtonBackrop, KickPlayer);


            _dungeonIcon = BlzCreateFrameByType("BACKDROP", "BACKDROP", _dungeonWindowIconBackrop, "", 1);
            BlzFrameSetPoint(_dungeonIcon, FRAMEPOINT_TOPLEFT, _dungeonWindowIconBackrop, FRAMEPOINT_TOPLEFT, 0.010880f, -0.0039500f);
            BlzFrameSetPoint(_dungeonIcon, FRAMEPOINT_BOTTOMRIGHT, _dungeonWindowIconBackrop, FRAMEPOINT_BOTTOMRIGHT, -0.0091200f, 0.0056700f);
            BlzFrameSetTexture(_dungeonIcon, Room.TargetDungeon.GetPathIconDungeon(), 0, true);

            _dungeonWindowStartButtonBackropText = BlzCreateFrameByType("TEXT", "name", _dungeonWindowStartButtonBackrop, "", 0);
            BlzFrameSetPoint(_dungeonWindowStartButtonBackropText, FRAMEPOINT_TOPLEFT, _dungeonWindowStartButtonBackrop, FRAMEPOINT_TOPLEFT, 0, 0);
            BlzFrameSetPoint(_dungeonWindowStartButtonBackropText, FRAMEPOINT_BOTTOMRIGHT, _dungeonWindowStartButtonBackrop, FRAMEPOINT_BOTTOMRIGHT, 0, 0);
            BlzFrameSetText(_dungeonWindowStartButtonBackropText, "|cffffffffСтарт|r");
            BlzFrameSetEnable(_dungeonWindowStartButtonBackropText, false);
            BlzFrameSetScale(_dungeonWindowStartButtonBackropText, 1.86f);
            BlzFrameSetTextAlignment(_dungeonWindowStartButtonBackropText, TEXT_JUSTIFY_CENTER, TEXT_JUSTIFY_MIDDLE);

            _dungeonWindowLeaveButtonBackropText = BlzCreateFrameByType("TEXT", "name", _dungeonWindowLeaveButtonBackrop, "", 0);
            BlzFrameSetPoint(_dungeonWindowLeaveButtonBackropText, FRAMEPOINT_TOPLEFT, _dungeonWindowLeaveButtonBackrop, FRAMEPOINT_TOPLEFT, 0, 0);
            BlzFrameSetPoint(_dungeonWindowLeaveButtonBackropText, FRAMEPOINT_BOTTOMRIGHT, _dungeonWindowLeaveButtonBackrop, FRAMEPOINT_BOTTOMRIGHT, -0, 0);
            BlzFrameSetText(_dungeonWindowLeaveButtonBackropText, "|cffffffffВыйти|r");
            BlzFrameSetEnable(_dungeonWindowLeaveButtonBackropText, false);
            BlzFrameSetScale(_dungeonWindowLeaveButtonBackropText, 1.86f);
            BlzFrameSetTextAlignment(_dungeonWindowLeaveButtonBackropText, TEXT_JUSTIFY_CENTER, TEXT_JUSTIFY_MIDDLE);

            _dungeonWindowKickPlayerButtonBackropText = BlzCreateFrameByType("TEXT", "name", _dungeonWindowKickPlayerButtonBackrop, "", 0);
            BlzFrameSetPoint(_dungeonWindowKickPlayerButtonBackropText, FRAMEPOINT_TOPLEFT, _dungeonWindowKickPlayerButtonBackrop, FRAMEPOINT_TOPLEFT, 0.041850f, -0.014950f);
            BlzFrameSetPoint(_dungeonWindowKickPlayerButtonBackropText, FRAMEPOINT_BOTTOMRIGHT, _dungeonWindowKickPlayerButtonBackrop, FRAMEPOINT_BOTTOMRIGHT, -0.038150f, 0.014170f);
            BlzFrameSetText(_dungeonWindowKickPlayerButtonBackropText, "|cffffffffX|r");
            BlzFrameSetEnable(_dungeonWindowKickPlayerButtonBackropText, false);
            BlzFrameSetScale(_dungeonWindowKickPlayerButtonBackropText, 1.00f);
            BlzFrameSetTextAlignment(_dungeonWindowKickPlayerButtonBackropText, TEXT_JUSTIFY_CENTER, TEXT_JUSTIFY_MIDDLE);

            UpdateSlotsPlayers();
        }

        private void KickPlayer()
        {
            throw new NotImplementedException();
        }

        private void StartDungeon()
        {
            DungeonsSystem.TurnDungeon(Room.TargetDungeon, Room.GetPlayers());
            Exit();
        }

        private void LeaveRoom()
        {
            Room.LeavePlayer(player.LocalPlayer);
            DungeonsSystem.RemoveRoom(Room.TargetDungeon);
            var hero = PlayerHeroesList.Heroes.Where(x => x.Owner == player.LocalPlayer).First();
            PauseUnit(hero, false);
            hero.IsInvulnerable = false;
            Exit();
        }

        public override void Destroy()
        {
            Room.OnLeavePlayer -= OnLeavePlayer;
            Room.OnAddPlayer -= OnAddPlayer;
            BlzDestroyFrame(_dungeonWindowBackrop);
            BlzDestroyFrame(_dungeonWindowListPlayersBackrop);
            BlzDestroyFrame(_dungeonWindowLabelBackrop);
            BlzDestroyFrame(_dungeonWindowInfoBackrop);
            BlzDestroyFrame(_dungeonWindowLabelBackropText);
            BlzDestroyFrame(_dungeonWindowIconBackrop);
            BlzDestroyFrame(_dungeonWindowStartButtonBackrop);
            BlzDestroyFrame(_backdropDungeonWindowStartButtonBackrop);
            DestroyTrigger(_triggerDungeonWindowStartButtonBackrop);
            BlzDestroyFrame(_dungeonWindowLeaveButtonBackrop);
            BlzDestroyFrame(_backdropDungeonWindowLeaveButtonBackrop);
            DestroyTrigger(_triggerDungeonWindowLeaveButtonBackrop);
            BlzDestroyFrame(_dungeonNameText);
            BlzDestroyFrame(_dungeonDescriptionText);
            BlzDestroyFrame(_dungeonWindowKickPlayerButtonBackrop);
            BlzDestroyFrame(_backdropDungeonWindowKickPlayerButtonBackrop);
            DestroyTrigger(_triggerDungeonWindowKickPlayerButtonBackrop);
            BlzDestroyFrame(_dungeonWindowPlayerSlotNameText);
            BlzDestroyFrame(_dungeonIcon);
            BlzDestroyFrame(_dungeonWindowStartButtonBackropText);
            BlzDestroyFrame(_dungeonWindowLeaveButtonBackropText);
            BlzDestroyFrame(_dungeonWindowKickPlayerButtonBackropText);

            foreach (var playerSlot in _playerSlotBackdrops)
            {
                playerSlot.Destroy();
            }
            _playerSlotBackdrops.Clear();
        }

        private void OnAddPlayer(player player)
        {
            UpdateSlotsPlayers();
        }

        private void OnLeavePlayer(player player)
        {
            UpdateSlotsPlayers();
        }

        private void UpdateSlotsPlayers ()
        {
            foreach (var playerSlot in _playerSlotBackdrops)
            {
                playerSlot.Destroy();
            }
            _playerSlotBackdrops.Clear();

            foreach (var player in Room.GetPlayers())
            {
                PlayerSlotFrame playerSlotFrame = new PlayerSlotFrame();
                playerSlotFrame.Create(_dungeonWindowListPlayersBackrop, player, player.Id / 10);
                _playerSlotBackdrops.Add(playerSlotFrame);
            }
        }
    }

    public class PlayerSlotFrame
    {
        private framehandle _playerSlotBackdrop;
        private framehandle _dungeonWindowPlayerSlotNameText;
        private framehandle _playerHeroIcon;
        private framehandle _dungeonWindowKickPlayerButtonBackrop;

        public void Create (framehandle _dungeonWindowListPlayersBackrop, player player, float offsetY)
        {
            _playerSlotBackdrop = BlzCreateFrameByType("BACKDROP", "BACKDROP", _dungeonWindowListPlayersBackrop, "", 1);
            BlzFrameSetPoint(_playerSlotBackdrop, FRAMEPOINT_TOPLEFT, _dungeonWindowListPlayersBackrop, FRAMEPOINT_TOPLEFT, 0.028460f, -0.028720f - offsetY);
            BlzFrameSetPoint(_playerSlotBackdrop, FRAMEPOINT_BOTTOMRIGHT, _dungeonWindowListPlayersBackrop, FRAMEPOINT_BOTTOMRIGHT, -0.029090f, 0.29969f - offsetY);
            BlzFrameSetTexture(_playerSlotBackdrop, "UI/WndowPlayerSlotBackrop.blp", 0, true);

            _dungeonWindowPlayerSlotNameText = BlzCreateFrameByType("TEXT", "name", _playerSlotBackdrop, "", 0);
            BlzFrameSetPoint(_dungeonWindowPlayerSlotNameText, FRAMEPOINT_TOPLEFT, _playerSlotBackdrop, FRAMEPOINT_TOPLEFT, 0.03f, 0);
            BlzFrameSetPoint(_dungeonWindowPlayerSlotNameText, FRAMEPOINT_BOTTOMRIGHT, _playerSlotBackdrop, FRAMEPOINT_BOTTOMRIGHT, 0, 0);
            BlzFrameSetText(_dungeonWindowPlayerSlotNameText, $"|cffffffff{player.Name}|r");
            BlzFrameSetEnable(_dungeonWindowPlayerSlotNameText, false);
            BlzFrameSetScale(_dungeonWindowPlayerSlotNameText, 1.29f);
            BlzFrameSetTextAlignment(_dungeonWindowPlayerSlotNameText, TEXT_JUSTIFY_CENTER, TEXT_JUSTIFY_LEFT);

            _playerHeroIcon = BlzCreateFrameByType("BACKDROP", "BACKDROP", _playerSlotBackdrop, "", 1);
            BlzFrameSetPoint(_playerHeroIcon, FRAMEPOINT_TOPLEFT, _playerSlotBackdrop, FRAMEPOINT_TOPLEFT, 0.10799f, -0.033560f);
            BlzFrameSetPoint(_playerHeroIcon, FRAMEPOINT_BOTTOMRIGHT, _playerSlotBackdrop, FRAMEPOINT_BOTTOMRIGHT, -0.23446f, 0.036440f);
            var hero = PlayerHeroesList.Heroes.Where(x => x.Owner == player).First();
            var iconHero = BlzGetAbilityIcon(hero.UnitType);
            BlzFrameSetTexture(_playerHeroIcon, iconHero, 0, true);
            /*
            _dungeonWindowKickPlayerButtonBackrop = BlzCreateFrame("IconButtonTemplate", _dungeonWndowPlayerSlotBackrop, 0, 0);
            BlzFrameSetPoint(_dungeonWindowKickPlayerButtonBackrop, FRAMEPOINT_TOPLEFT, _dungeonWndowPlayerSlotBackrop, FRAMEPOINT_TOPLEFT, 0.26368f, -0.042820f);
            BlzFrameSetPoint(_dungeonWindowKickPlayerButtonBackrop, FRAMEPOINT_BOTTOMRIGHT, _dungeonWndowPlayerSlotBackrop, FRAMEPOINT_BOTTOMRIGHT, 0.0012300f, 0.0071800f);
            */
        }

        public void Destroy()
        {
            BlzDestroyFrame(_playerSlotBackdrop);
            BlzDestroyFrame(_dungeonWindowPlayerSlotNameText);
            BlzDestroyFrame(_playerHeroIcon);
        }
    }
}
