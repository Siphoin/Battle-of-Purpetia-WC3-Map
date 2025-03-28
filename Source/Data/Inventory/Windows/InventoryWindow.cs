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
        private const float OFFSET_CELLS = 0.0253f;
        private List<InventoryCell> _cells;
        private framehandle _inventoryFrame;
        private framehandle BackdropbuttonExit;
        private framehandle buttonExit;

        public InventoryWindow(CustomInventory targetInventory)
        {
            TargetInventory = targetInventory;
            _cells = new();
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

            foreach (var cell in _cells)
            {
                cell.Destroy();
            }

            _cells.Clear();
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
            var items = TargetInventory as IEnumerable<item>;
            int columnsPerRow = 8;
            float xOffset = OFFSET_CELLS;
            float yOffset = OFFSET_CELLS;

            for (int i = 0; i < items.Count(); i++)
            {
                int column = i % columnsPerRow;
                int row = i / columnsPerRow;
                float xPos = column * xOffset;

                // Инвертируем Y, чтобы ряды шли вниз
                float yPos = row * -yOffset; // Умножаем на -1

                InventoryCell cell = new InventoryCell(
                    items.ElementAt(i),
                    _inventoryFrame,
                    TargetInventory.TargetUnit,
                    UseItem,
                    xPos,
                    yPos,
                    i
                );

                cell.Create();
                _cells.Add(cell);
            }
        }

        private void UseItem(item item)
        {
            TargetInventory.UseItem(item);
        }

        private void UpdateCells(item item)
        {
            foreach (var cell in _cells)
            {
                cell.Destroy();
            }

            _cells.Clear();
            CreateCells();


        }
    }

    public class InventoryCell
    {

        private framehandle _button;
        private framehandle _icon;
        private trigger _triggerUse;
        private framehandle tolltipTextNameItemDescription;
        private framehandle tolltipTextNameItem;
        private framehandle itemTolltip;
        private framehandle goldItemTolltipIconText;
        private framehandle goldItemTolltipIcon;
        private framehandle iconItemTooltip;
        private const float SCALE_ICON_WIDTH = 0.029f;
        private const float DELAY_REMOVE_ITEM = 0.3f;

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
            _button = BlzCreateFrame("ScoreScreenBottomButtonTemplate", Parent, 0, IndexCreate);
            _icon = BlzGetFrameByName("ScoreScreenButtonBackdrop", IndexCreate);
            
            BlzFrameSetSize(_button, SCALE_ICON_WIDTH, SCALE_ICON_WIDTH);
            BlzFrameSetPoint(_button, framepointtype.TopLeft, Parent, framepointtype.TopLeft, 0.046410f + X, -0.068880f + Y);
            var iconItem = BlzGetAbilityIcon(Item.TypeId);
            BlzFrameSetTexture(_icon, iconItem, 0, true);

            _triggerUse = trigger.Create();
            _triggerUse.AddAction(() => UseAction?.Invoke(Item));
            BlzTriggerRegisterFrameEvent(_triggerUse, _button, frameeventtype.Click);
            CreateTooltip();
            BlzFrameSetTooltip(_button, itemTolltip);
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
            BlzFrameSetTexture(iconItemTooltip, BlzGetAbilityIcon(Item.TypeId), 0, true);

            goldItemTolltipIcon = BlzCreateFrameByType("BACKDROP", "BACKDROP", itemTolltip, "", IndexCreate);
            BlzFrameSetAbsPoint(goldItemTolltipIcon, FRAMEPOINT_TOPLEFT, 0.377070F, 0.364750F);
            BlzFrameSetAbsPoint(goldItemTolltipIcon, FRAMEPOINT_BOTTOMRIGHT, 0.387070F, 0.354750F);
            BlzFrameSetTexture(goldItemTolltipIcon, "UI\\Widgets\\Console\\Human\\infocard-gold.blp", 0, true);
            goldItemTolltipIconText = BlzCreateFrameByType("TEXT", "name", itemTolltip, "", IndexCreate);
            BlzFrameSetAbsPoint(goldItemTolltipIconText, FRAMEPOINT_TOPLEFT, 0.389100F, 0.362720F);
            BlzFrameSetAbsPoint(goldItemTolltipIconText, FRAMEPOINT_BOTTOMRIGHT, 0.430700F, 0.352710F);
            BlzFrameSetText(goldItemTolltipIconText, string.Empty);
            BlzFrameSetEnable(goldItemTolltipIconText, false);
            BlzFrameSetScale(goldItemTolltipIconText, 0.000571F);
            BlzFrameSetTextAlignment(goldItemTolltipIconText, TEXT_JUSTIFY_TOP, TEXT_JUSTIFY_LEFT);

        }
        private void RemoveUsedItemFromSlot(trigger trggerClick)
        {
            var item = GetManipulatedItem();
            UnitRemoveItem(TargetUnit, item);
            DestroyTrigger(trggerClick);
        }

        public void Destroy()
        {
            BlzDestroyFrame(_button);
            BlzDestroyFrame(_icon);
            DestroyTrigger(_triggerUse);
        }

        


    }

}
