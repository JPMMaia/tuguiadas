using System;
using Ports;

namespace Currency
{
    public class Item
    {
        public uint ID
        {
            get { return _id; }
        }
        public String Name { get; set; }
        public String Material { get; set; }
        public uint Quantity { get; set; }
        public float OriginalPrice { get; set; }
        public Culture Culture { get; set; }

        private readonly uint _id;
        private static uint _count;

        public Item()
        {
            _id = _count++;
        }

        public float CalculateSellPrice(Culture portCulture)
        {
            return OriginalPrice * (Culture == portCulture ? 0.8f : 1.2f);
        }
    }
}
