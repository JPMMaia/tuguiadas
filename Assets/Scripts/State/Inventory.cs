using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace State
{
    public class Inventory : MonoBehaviour, IEnumerable<Currency.Item>
    {
        private readonly List<Currency.Item> _inventory = new List<Currency.Item>();

        public uint AddItem(Currency.Item item)
        {
            _inventory.Add(item);

            return item.ID;
        }
        public void DeleteItem(uint itemID)
        {
            _inventory.RemoveAll(e => e.ID == itemID);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        public IEnumerator<Currency.Item> GetEnumerator()
        {
            return _inventory.GetEnumerator();
        }
    }
}
