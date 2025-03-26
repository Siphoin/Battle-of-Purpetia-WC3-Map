using System;
using System.Collections.Generic;
using WCSharp.Api;
using static WCSharp.Api.Common;
using static WCSharp.Api.Blizzard;
using static Source.Extensions.CommonExtensions;
using System.Collections;
using System.Linq;
namespace Source.Data
{
    public class CustomInventory : ICollection<item>, IEnumerable<item>
    {
        private unit TargetUnit {  get; set; }

        public int Count => _items.Count;

        public bool IsReadOnly => false;

        private const int POSOTION_COPY_ITEM = -30000;
        private List<item> _items;
        private trigger _triggerListenereGiveItem;
        private trigger _triggerDropItem;

        public CustomInventory(unit targetUnit)
        {
            TargetUnit = targetUnit;
            _items = new();
            _triggerListenereGiveItem = trigger.Create();
            _triggerListenereGiveItem.RegisterUnitEvent(TargetUnit, unitevent.PickupItem);
            _triggerListenereGiveItem.AddAction(AddItem);

            _triggerDropItem = trigger.Create();
            _triggerDropItem.RegisterUnitEvent(TargetUnit, unitevent.DropItem);
            _triggerDropItem.AddAction(RemoveItemFromInventory);

#if DEBUG
            Log($"created for unit {TargetUnit.Name}");
#endif

        }

        private void RemoveItemFromInventory()
        {
            var item = GetManipulatedItem();
            Remove(item);
        }

        private void AddItem()
        {
            var item = GetManipulatedItem();
            var copyItem = item.Create(item.TypeId, POSOTION_COPY_ITEM, POSOTION_COPY_ITEM);
            Add(copyItem);

            var abilityItem = BlzGetItemAbilityByIndex(item, 0);
            int id = BlzGetAbilityId(abilityItem);
            RemoveItem(item);
            bool addedA = UnitAddAbility(TargetUnit, id);
            BlzUnitHideAbility(TargetUnit, id, true);
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
            throw new NotImplementedException();
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
    }
}
