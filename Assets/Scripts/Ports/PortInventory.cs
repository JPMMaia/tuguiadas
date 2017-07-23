using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ports
{
    public class PortInventory : IEnumerable<Currency.Item>
    {
        private readonly List<Currency.Item> _items = new List<Currency.Item>();

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        public IEnumerator<Currency.Item> GetEnumerator()
        {
            return _items.GetEnumerator();
        }
    }
}
