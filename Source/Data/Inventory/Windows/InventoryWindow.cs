using Source.Systems.WindowsSystems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCSharp.Api;
using static WCSharp.Api.Common;
using static WCSharp.Api.Blizzard;
using static Source.Extensions.CommonExtensions;
using Source.Triggers.GUITriggers.Triggers;
using System.Runtime.Intrinsics.X86;
using Source.Extensions;
namespace Source.Data.Inventory.Windows
{
    public class InventoryWindow : WindowGUIBase
    {
        private const float OFFSET_CELLS = 0.027f;
        private List<InventoryCell> _cellsNotEmpty;
        private List<InventoryCellEmpty> _cellsEmpty;
        private framehandle _inventoryFrame;
        private framehandle BackdropbuttonExit;
        private framehandle buttonExit;

        public InventoryWindow(CustomInventory targetInventory)
        {
            TargetInventory = targetInventory;
            _cellsNotEmpty = new();
            _cellsEmpty = new();
            TargetInventory.OnAddAItem += UpdateCells;
            TargetInventory.OnRemoveItem += UpdateCells;
            CustomConsoleUITrigger.OnModeChanged += OnModeConsoleUIChanged;

            TriggerUnitDied = trigger.Create();
            TriggerUnitDied.RegisterUnitEvent(TargetInventory.TargetUnit, unitevent.Death);
            TriggerUnitDied.AddAction(() => Exit());
        }

        public trigger TriggerbuttonExit { get; private set; }
        public trigger TriggerUnitDied { get; private set; }
        private CustomInventory TargetInventory { get; set; }
        public override void Destroy()
        {
            DestroyTrigger(TriggerbuttonExit);
            DestroyTrigger(TriggerUnitDied);

            foreach (var cell in _cellsNotEmpty)
            {
                cell.Destroy();
            }

            _cellsNotEmpty.Clear();
            BlzDestroyFrame(buttonExit);
            BlzDestroyFrame(BackdropbuttonExit);
            BlzDestroyFrame(_inventoryFrame);
            TargetInventory.OnAddAItem -= UpdateCells;
            TargetInventory.OnRemoveItem -= UpdateCells;
            CustomConsoleUITrigger.OnModeChanged -= OnModeConsoleUIChanged;
        }

        private void OnModeConsoleUIChanged(CustomConsoleUIMode mode)
        {
            if (mode == CustomConsoleUIMode.Normal)
            {
                SetHideState(false);
            }

            else
            {
                SetHideState(true);
            }
        }

        public override void Show()
        {
            _inventoryFrame = BlzCreateFrameByType("BACKDROP", "BACKDROP", BlzGetOriginFrame(ORIGIN_FRAME_GAME_UI, 0), "", 1);
            BlzFrameSetAbsPoint(_inventoryFrame, FRAMEPOINT_TOPLEFT, 0.492620f, 0.469720f);
            BlzFrameSetAbsPoint(_inventoryFrame, FRAMEPOINT_BOTTOMRIGHT, 0.802450f, 0.141640f);
            BlzFrameSetTexture(_inventoryFrame, "CustomConsoleUI/inventoryFrame.blp", 0, true);


            buttonExit = BlzCreateFrame("IconButtonTemplate", _inventoryFrame, 0, 0);
            BlzFrameSetAbsPoint(buttonExit, FRAMEPOINT_TOPLEFT, 0.758500f, 0.473090f);
            BlzFrameSetAbsPoint(buttonExit, FRAMEPOINT_BOTTOMRIGHT, 0.791890f, 0.434150f);

            BackdropbuttonExit = BlzCreateFrameByType("BACKDROP", "BackdropbuttonExit", buttonExit, "", 0);
            BlzFrameSetAllPoints(BackdropbuttonExit, buttonExit);
            BlzFrameSetTexture(BackdropbuttonExit, "UI/dungeonWindowSelectExitButton.blp", 0, true);
            TriggerbuttonExit = CreateTrigger();
            BlzTriggerRegisterFrameEvent(TriggerbuttonExit, buttonExit, FRAMEEVENT_CONTROL_CLICK);
            TriggerAddAction(TriggerbuttonExit, Exit);
            CreateSlots();
            CreateCells();

        }

        protected override void SetHideState(bool state)
        {
            BlzFrameSetVisible(buttonExit, !state);
            BlzFrameSetVisible(BackdropbuttonExit, !state);
            BlzFrameSetVisible(_inventoryFrame, !state);
            base.SetHideState(state);
        }

        private void CreateCells()
        {
            var _exitsItems = TargetInventory as IEnumerable<item>;
            int columnsPerRow = 8;
            float xOffset = OFFSET_CELLS;
            float yOffset = OFFSET_CELLS;
            for (int i = 0; i < _exitsItems.Count(); i++)
            {
                var item = _exitsItems.ElementAt(i);
                int column = i % columnsPerRow;
                int row = i / columnsPerRow;
                float xPos = column * xOffset;

                // Инвертируем Y, чтобы ряды шли вниз
                float yPos = row * -yOffset; // Умножаем на -1
                InventoryCell cell = new InventoryCell(
               _exitsItems.ElementAt(i),
               _inventoryFrame,
               TargetInventory.TargetUnit,
               UseItem,
               xPos,
               yPos,
               i
           );
                cell.Create();
                _cellsNotEmpty.Add(cell);
                

            }
        }

        private void CreateSlots()
        {
            int columnsPerRow = 8;
            float xOffset = OFFSET_CELLS;
            float yOffset = OFFSET_CELLS;
            for (int i = 0; i < TargetInventory.Limititems; i++)
            {
                int column = i % columnsPerRow;
                int row = i / columnsPerRow;
                float xPos = column * xOffset;

                // Инвертируем Y, чтобы ряды шли вниз
                float yPos = row * -yOffset; // Умножаем на -1
                InventoryCellEmpty cell = new InventoryCellEmpty(
                _inventoryFrame,
                xPos,
                yPos,
                i
                );

                cell.Create();
                _cellsEmpty.Add(cell);
            }
        }



        private void UseItem(item item)
        {
            TargetInventory.UseItem(item);
        }

        private void UpdateCells(item item)
        {
            foreach (var cell in _cellsEmpty)
            {
                cell.Destroy();
            }
            foreach (var cell in _cellsNotEmpty)
            {
                cell.Destroy();
            }

            _cellsNotEmpty.Clear();
            _cellsEmpty.Clear();
            CreateSlots();
            CreateCells();


        }
    }

    public class InventoryCell
    {
        private framehandle _iconFrame;
        private framehandle _button;
        private framehandle _icon;
        private framehandle _textCharges;
        private trigger _triggerUse;
        private framehandle tolltipTextNameItemDescription;
        private framehandle tolltipTextNameItem;
        private framehandle itemTolltip;
        private framehandle goldItemTolltipIconText;
        private framehandle goldItemTolltipIcon;
        private framehandle iconItemTooltip;
        private framehandle itemFrame;
        private const float SCALE_ICON_WIDTH = 0.029f;

        public item Item { get; set; }
        private framehandle Parent { get; set; }
        private int IndexCreate { get; set; }
        private float X { get; set; }
        private float Y { get; set; }
        private unit TargetUnit { get; set; }
        private Action<item> UseAction { get; set; }

        public InventoryCell(item item, framehandle parent, unit targetUnit, Action<item> useAction, float x, float y, int indexCreate)
        {
            Item = item;
            Parent = parent;
            IndexCreate = indexCreate;
            X = x;
            Y = y;
            TargetUnit = targetUnit;
            UseAction = useAction;
        }

        public void Create()
        {
            itemFrame = BlzCreateFrame("ScoreScreenBottomButtonTemplate", Parent, 0, IndexCreate);
            BlzFrameSetPoint(itemFrame, framepointtype.TopLeft, Parent, framepointtype.TopLeft, 0.04f + X, -0.065f + Y);
            _iconFrame = BlzGetFrameByName("ScoreScreenButtonBackdrop", IndexCreate);
            BlzFrameSetTexture(_iconFrame, "CustomConsoleUI/inventory_cell.blp", 0, true);
            BlzFrameSetSize(itemFrame, SCALE_ICON_WIDTH, SCALE_ICON_WIDTH);

            if (Item is null)
            {
                return;
            }

            _button = BlzCreateFrame("ScoreScreenBottomButtonTemplate", itemFrame, 1, IndexCreate + 1);
            _icon = BlzGetFrameByName("ScoreScreenButtonBackdrop", IndexCreate + 1);
            _textCharges = BlzCreateFrameByType("TEXT", "name", _button, "", IndexCreate + 1);
            _textCharges.Text = Item.Charges > 0 ? Item.Charges.ToString() : string.Empty;
            BlzFrameSetPoint(_textCharges, framepointtype.BottomRight, _button, framepointtype.BottomRight, 0, 0);
            BlzFrameSetScale(_textCharges, 1.3f);
            BlzFrameSetSize(_button, SCALE_ICON_WIDTH, SCALE_ICON_WIDTH);
            BlzFrameSetEnable(_textCharges, false);
            BlzFrameSetPoint(_button, framepointtype.Center, itemFrame, framepointtype.Center, 0, 0);;
            BlzFrameSetTexture(_icon, Item.Icon, 0, true);

            _triggerUse = trigger.Create();
            _triggerUse.AddAction(() => UseAction?.Invoke(Item));
            BlzTriggerRegisterFrameEvent(_triggerUse, _button, frameeventtype.Click);
            CreateTooltip();
            BlzFrameSetTooltip(_button, itemTolltip);

            if (Item.Charges > 0 && TargetUnit.Owner == player.LocalPlayer)
            {
               var localInventory = CustomInventory.LocalPlayerInventory;
                localInventory.OnUseItem += OnUseItem;
            }
        }

        private void OnUseItem(item item)
        {
            if (item == Item)
            {
                _textCharges.Text = Item.Charges > 0 ? Item.Charges.ToString() : string.Empty;
            }
        }

        private void CreateTooltip ()
        {


            itemTolltip = BlzCreateFrameByType("BACKDROP", "BACKDROP", BlzGetOriginFrame(ORIGIN_FRAME_GAME_UI, 0), "", IndexCreate);
            BlzFrameSetAbsPoint(itemTolltip, FRAMEPOINT_TOPLEFT, 0.304250F, 0.415730F);
            BlzFrameSetAbsPoint(itemTolltip, FRAMEPOINT_BOTTOMRIGHT, 0.519790F, 0.193180F);
            BlzFrameSetTexture(itemTolltip, "CustomConsoleUI/itemTolltip.blp", 0, true);

            tolltipTextNameItem = BlzCreateFrameByType("TEXT", "name", itemTolltip, "", IndexCreate);
            BlzFrameSetAbsPoint(tolltipTextNameItem, FRAMEPOINT_TOPLEFT, 0.374570f, 0.379420f);
            BlzFrameSetAbsPoint(tolltipTextNameItem, FRAMEPOINT_BOTTOMRIGHT, 0.489970f, 0.352410f);
            BlzFrameSetText(tolltipTextNameItem, Item.ColorizeByLevel());
            BlzFrameSetEnable(tolltipTextNameItem, false);
            BlzFrameSetScale(tolltipTextNameItem, 0.8f);
            BlzFrameSetTextAlignment(tolltipTextNameItem, TEXT_JUSTIFY_TOP, TEXT_JUSTIFY_LEFT);
            tolltipTextNameItemDescription = BlzCreateFrameByType("TEXT", "name", itemTolltip, "", IndexCreate);
            BlzFrameSetAbsPoint(tolltipTextNameItemDescription, FRAMEPOINT_TOPLEFT, 0.335780F, 0.345130F);
            BlzFrameSetAbsPoint(tolltipTextNameItemDescription, FRAMEPOINT_BOTTOMRIGHT, 0.490600F, 0.225640F);
            BlzFrameSetText(tolltipTextNameItemDescription, BlzGetItemExtendedTooltip(Item));
            BlzFrameSetEnable(tolltipTextNameItemDescription, false);
            BlzFrameSetScale(tolltipTextNameItemDescription, 0.9f);
            BlzFrameSetTextAlignment(tolltipTextNameItemDescription, TEXT_JUSTIFY_TOP, TEXT_JUSTIFY_LEFT);

            iconItemTooltip = BlzCreateFrameByType("BACKDROP", "BACKDROP", itemTolltip, "", IndexCreate);
            BlzFrameSetAbsPoint(iconItemTooltip, FRAMEPOINT_TOPLEFT, 0.341010F, 0.383410F);
            BlzFrameSetAbsPoint(iconItemTooltip, FRAMEPOINT_BOTTOMRIGHT, 0.362950F, 0.359260F);
            BlzFrameSetTexture(iconItemTooltip, Item.Icon, 0, true);

            goldItemTolltipIcon = BlzCreateFrameByType("BACKDROP", "BACKDROP", itemTolltip, "", IndexCreate);
            BlzFrameSetAbsPoint(goldItemTolltipIcon, FRAMEPOINT_TOPLEFT, 0.377070F, 0.364750F);
            BlzFrameSetAbsPoint(goldItemTolltipIcon, FRAMEPOINT_BOTTOMRIGHT, 0.387070F, 0.354750F);
            BlzFrameSetTexture(goldItemTolltipIcon, "UI\\Widgets\\Console\\Human\\infocard-gold.blp", 0, true);

            goldItemTolltipIconText = BlzCreateFrameByType("TEXT", "name", itemTolltip, "", IndexCreate);
            // Измененные координаты для лучшего выравнивания (подняли текст немного выше)
            BlzFrameSetAbsPoint(goldItemTolltipIconText, FRAMEPOINT_TOPLEFT, 0.389100F, 0.36400F);  // Было 0.36220F
            BlzFrameSetAbsPoint(goldItemTolltipIconText, FRAMEPOINT_BOTTOMRIGHT, 0.430700F, 0);
            BlzFrameSetText(goldItemTolltipIconText, GetItemGoldCost(Item).ToString().Colorize(DEFAULT_WARCRAFT_III_TEXT_HEX));
            BlzFrameSetEnable(goldItemTolltipIconText, false);
            BlzFrameSetScale(goldItemTolltipIconText, 1f);
            BlzFrameSetTextAlignment(goldItemTolltipIconText, TEXT_JUSTIFY_TOP, TEXT_JUSTIFY_LEFT);

        }

        public void Destroy()
        {

            BlzDestroyFrame(itemFrame);
            BlzDestroyFrame(_iconFrame);
            if (Item is null)
            {
                return;
            }
            BlzDestroyFrame(_textCharges);
            BlzDestroyFrame(_button);
            BlzDestroyFrame(_icon);
            DestroyTrigger(_triggerUse);
            BlzDestroyFrame(itemTolltip);
            BlzDestroyFrame(iconItemTooltip);
            BlzDestroyFrame(goldItemTolltipIcon);
            BlzDestroyFrame(goldItemTolltipIconText);
            BlzDestroyFrame(tolltipTextNameItemDescription);
            BlzDestroyFrame(tolltipTextNameItem);
            if (TargetUnit.Owner == player.LocalPlayer)
            {
                var localInventory = CustomInventory.LocalPlayerInventory;
                localInventory.OnUseItem -= OnUseItem;
            }
        }

        


    }

    public class InventoryCellEmpty
    {
        private framehandle _iconFrame;
        private framehandle itemFrame;
        private const float SCALE_ICON_WIDTH = 0.029f;

        private framehandle Parent { get; set; }
        private int IndexCreate { get; set; }
        private float X { get; set; }
        private float Y { get; set; }


        public InventoryCellEmpty(framehandle parent, float x, float y, int indexCreate)
        {
            Parent = parent;
            IndexCreate = indexCreate;
            X = x;
            Y = y;
        }

        public void Create()
        {
            itemFrame = BlzCreateFrame("ScoreScreenBottomButtonTemplate", Parent, 0, IndexCreate);
            BlzFrameSetPoint(itemFrame, framepointtype.TopLeft, Parent, framepointtype.TopLeft, 0.04f + X, -0.065f + Y);
            _iconFrame = BlzGetFrameByName("ScoreScreenButtonBackdrop", IndexCreate);
            BlzFrameSetTexture(_iconFrame, "CustomConsoleUI/inventory_cell.blp", 0, true);
            BlzFrameSetSize(itemFrame, SCALE_ICON_WIDTH, SCALE_ICON_WIDTH);
            BlzFrameSetEnable(itemFrame, false);
        }

        public void Destroy()
        {
            BlzDestroyFrame(itemFrame);
            BlzDestroyFrame(_iconFrame);
        }




    }

}
