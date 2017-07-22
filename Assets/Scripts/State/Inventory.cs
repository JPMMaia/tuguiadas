using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace State
{
    public class Inventory : MonoBehaviour, IEnumerable<Currency.Item>
    {
        private readonly List<Currency.Item> _inventory = new List<Currency.Item>();

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
