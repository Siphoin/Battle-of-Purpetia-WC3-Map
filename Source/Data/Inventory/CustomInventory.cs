﻿using System;
using System.Collections.Generic;
using WCSharp.Api;
using static WCSharp.Api.Common;
using static WCSharp.Api.Blizzard;
using System.Collections;
using Source.Models;
namespace Source.Data.Inventory
{
    public class CustomInventory : ICollection<item>, IEnumerable<item>
    {
        public event Action<item> OnAddAItem;
        public event Action<item> OnRemoveItem;
        public unit TargetUnit { get; private set; }
        public int Limititems { get; private set; }

        public int Count => _items.Count;

        public static CustomInventory LocalPlayerInventory {  get; private set; }

        public bool IsReadOnly => false;

        private List<item> _items;
        private trigger _triggerListenereGiveitem;
        private trigger _triggerDropitem;
        private trigger _triggerUseItem;

        public CustomInventory(unit targetUnit, int limititems = 0)
        {
            TargetUnit = targetUnit;
            if (limititems < 0)
            {
                limititems = 0;
            }

            Limititems = limititems;
            _items = new();
            _triggerListenereGiveitem = trigger.Create();
            _triggerListenereGiveitem.RegisterUnitEvent(TargetUnit, unitevent.PickupItem);
            _triggerListenereGiveitem.AddAction(Additem);

            _triggerDropitem = trigger.Create();
            _triggerDropitem.RegisterUnitEvent(TargetUnit, unitevent.DropItem);
            _triggerDropitem.AddAction(RemoveitemFromInventory);

            _triggerUseItem = trigger.Create();
            _triggerUseItem.RegisterUnitEvent(TargetUnit, unitevent.UseItem);
            _triggerUseItem.AddAction(UseItem);

#if DEBUG
            Log($"created for unit {TargetUnit.Name}");
#endif

            if (LocalPlayerInventory is null && TargetUnit.Owner == player.LocalPlayer)
            {
                LocalPlayerInventory = this;
            }
            

        }

        private void UseItem()
        {
            var item = GetManipulatedItem();
            UnitRemoveItem(TargetUnit, item);
            RemoveitemFromInventory();

#if DEBUG
            Log($"Detected use item: {item.Name}");
#endif
        }

        private void RemoveitemFromInventory()
        {
            var item = GetManipulatedItem();
            if (Contains(item) && item != null)
            {
               Remove(item);
            }

        }

        private void Additem()
        {
            var item = GetManipulatedItem();

            if (Contains(item))
            {
                return;
            }
            _triggerDropitem.Disable();

            if (Count >= Limititems && Limititems > 0)
            {
                DisplayTextToPlayer(TargetUnit.Owner, 0, 0, "Недостачно места в инвентаре");
                UnitRemoveItem(TargetUnit, item);
                return;
            }

            var abilityItem = BlzGetItemAbilityByIndex(item, 0);
            int id = BlzGetAbilityId(abilityItem);

            Add(item);
            UnitRemoveItem(TargetUnit, item);
            SetItemVisible(item, false);
            UnitAddAbility(TargetUnit, id);
            BlzUnitHideAbility(TargetUnit, id,  true);
            _triggerDropitem.Enable();
        }

#if DEBUG
        private void Log(string message)
        {
            Console.WriteLine($"Custom inventory: {message}");
        }

#endif

        public void Add(item item)
        {
            _items.Add(item);

#if DEBUG
            Log($"Added item {item.Name} to unit {TargetUnit.Name}");
#endif
            OnAddAItem?.Invoke(item);
        }

        public void Clear()
        {
            _items.Clear();

#if DEBUG
            Log($"Clear all items from unit {TargetUnit.Name}");
#endif
        }

        public bool Contains(item item)
        {
            return _items.Contains(item);
        }

        public void CopyTo(item[] array, int arrayIndex)
        {
            _items.CopyTo(array, arrayIndex);
        }

        public bool Remove(item item)
        {
            bool isRemoved = _items.Remove(item);

#if DEBUG
            if (isRemoved)
            {
                Log($"Removed item {item.Name} from unit {TargetUnit.Name}");
                OnRemoveItem?.Invoke(item);
            }
#endif

            return isRemoved;
        }

        public IEnumerator<item> GetEnumerator()
        {
            return _items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void UseItem(item Item)
        {
            if (Contains(Item))
            {
                UnitAddItem(TargetUnit, Item);
                bool used = UnitUseItem(TargetUnit, Item);

                if (!used)
                {
                    _triggerDropitem.Disable();
                    UnitRemoveItem(TargetUnit, Item);
                    SetItemVisible(Item, false);
                    _triggerDropitem.Enable();
                }
            }
        }

    }
}
