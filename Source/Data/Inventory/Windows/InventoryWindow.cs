using Source.Systems.WindowsSystems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCSharp.Api;
using static WCSharp.Api.Common;
namespace Source.Data.Inventory.Windows
{
    public class InventoryWindow : WindowGUIBase
    {
        private List<InventoryCell> _cells;
        private framehandle _inventoryFrame;
        private framehandle BackdropbuttonExit;
        private framehandle buttonExit;

        public InventoryWindow(CustomInventory targetInventory)
        {
            TargetInventory = targetInventory;
            _cells = new();
        }

        public trigger TriggerbuttonExit { get; private set; }
        private CustomInventory TargetInventory { get; set; }
        public override void Destroy()
        {
            DestroyTrigger(TriggerbuttonExit);
            foreach (var cell in _cells)
            {
                cell.Destroy();
            }

            _cells.Clear();
            BlzDestroyFrame(buttonExit);
            BlzDestroyFrame(BackdropbuttonExit);
            BlzDestroyFrame(_inventoryFrame);
        }

        public override void Show()
        {
            _inventoryFrame = BlzCreateFrameByType("BACKDROP", "BACKDROP", BlzGetOriginFrame(ORIGIN_FRAME_GAME_UI, 0), "", 1);
            BlzFrameSetAbsPoint(_inventoryFrame, FRAMEPOINT_TOPLEFT, 0.492620f, 0.469720f);
            BlzFrameSetAbsPoint(_inventoryFrame, FRAMEPOINT_BOTTOMRIGHT, 0.802450f, 0.141640f);
BlzFrameSetTexture(_inventoryFrame, "CustomConsoleUI/inventoryFrame.blpITEM_CON.blp", 0, true);


            buttonExit = BlzCreateFrame("IconButtonTemplate", _inventoryFrame, 0, 0);
            BlzFrameSetAbsPoint(buttonExit, FRAMEPOINT_TOPLEFT, 0.758500f, 0.473090f);
            BlzFrameSetAbsPoint(buttonExit, FRAMEPOINT_BOTTOMRIGHT, 0.791890f, 0.434150f);

            BackdropbuttonExit = BlzCreateFrameByType("BACKDROP", "BackdropbuttonExit", buttonExit, "", 0);
            BlzFrameSetAllPoints(BackdropbuttonExit, buttonExit);
BlzFrameSetTexture(BackdropbuttonExit, "dungeonWindowSelectExitButton.png", 0, true);
            TriggerbuttonExit = CreateTrigger();
            BlzTriggerRegisterFrameEvent(TriggerbuttonExit, buttonExit, FRAMEEVENT_CONTROL_CLICK);
TriggerAddAction(TriggerbuttonExit, Exit);


        }
    }

    public class InventoryCell
    {

        private framehandle _button;
        private framehandle _icon;
        private const float SCALE_ICON = 0.03f;

        public item Item { get; set; }
        private framehandle Parent { get; set; }
        private int IndexCreate { get; set; }
        private float X { get; set; }
        private float Y { get; set; }

        public InventoryCell(item item, framehandle parent, float x, float y, int indexCreate)
        {
            Item = item;
            Parent = parent;
            IndexCreate = indexCreate;
            X = x;
            Y = y;
        }

        public void Create()
        {
            _button = BlzCreateFrame("ScoreScreenBottomButtonTemplate", Parent, 0, IndexCreate);
            _icon = BlzGetFrameByName("ScoreScreenButtonBackdrop", 0);
            BlzFrameSetSize(_button, SCALE_ICON, SCALE_ICON);
            BlzFrameSetPoint(_button, framepointtype.Center, Parent, framepointtype.Center, X, Y);
        }

        public void Destroy()
        {
            BlzDestroyFrame(_button);
            BlzDestroyFrame(_icon);
        }


    }

}
