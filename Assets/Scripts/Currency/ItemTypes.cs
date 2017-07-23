using System;
using System.Collections.Generic;
using Ports;

namespace Currency
{
    public class ItemTypes
    {
        public String Name { get; set; }
        public String Material { get; set; }
        public uint MinimunQuantity { get; set; }
        public uint MaximunQuantity { get; set; }
        public float MinimunPrice { get; set; }
        public float MaximunPrice { get; set; }
    }

    public class ItemTypesByCulture
    {
        public static readonly Dictionary<Culture, List<ItemTypes>> Collection = new Dictionary<Culture, List<ItemTypes>>
        {
            {
                Culture.European, new List<ItemTypes>
                {
                    new ItemTypes { Name = "Ring", Material = "Gold", MinimunQuantity = 0, MaximunQuantity = 4, MinimunPrice = 100.0f, MaximunPrice = 300.0f },
                    new ItemTypes { Name = "Ring", Material = "Silver", MinimunQuantity = 0, MaximunQuantity = 7, MinimunPrice = 30.0f, MaximunPrice = 180.0f },
                }
            },
            {
                Culture.African, new List<ItemTypes>
                {
                    new ItemTypes { Name = "Spoon", Material = "Ivory", MinimunQuantity = 3, MaximunQuantity = 7, MinimunPrice = 10.0f, MaximunPrice = 25.0f },
                    new ItemTypes { Name = "Salt-cellar", Material = "Ivory", MinimunQuantity = 1, MaximunQuantity = 2, MinimunPrice = 80.0f, MaximunPrice = 200.0f },
                    new ItemTypes { Name = "Aquamanile Leopard", Material = "Bronze", MinimunQuantity = 0, MaximunQuantity = 1, MinimunPrice = 700.0f, MaximunPrice = 1000.0f },
                    new ItemTypes { Name = "Cushion Cover", Material = "Raffia Fiber", MinimunQuantity = 1, MaximunQuantity = 2, MinimunPrice = 400.0f, MaximunPrice = 600.0f },
                    new ItemTypes { Name = "Oliphant", Material = "Ivory", MinimunQuantity = 0, MaximunQuantity = 3, MinimunPrice = 100.0f, MaximunPrice = 200.0f },
                    new ItemTypes { Name = "Horn", Material = "Ivory", MinimunQuantity = 0, MaximunQuantity = 2, MinimunPrice = 150.0f, MaximunPrice = 250.0f },
                    new ItemTypes { Name = "Pyx", Material = "Ivory", MinimunQuantity = 0, MaximunQuantity = 2, MinimunPrice = 100.0f, MaximunPrice = 150.0f },
                    new ItemTypes { Name = "European Soldier", Material = "Ivory", MinimunQuantity = 0, MaximunQuantity = 1, MinimunPrice = 100.0f, MaximunPrice = 200.0f },
                    new ItemTypes { Name = "Crucifix", Material = "Brass", MinimunQuantity = 0, MaximunQuantity = 1, MinimunPrice = 100.0f, MaximunPrice = 200.0f },
                }
            },
            {
                Culture.Indian, new List<ItemTypes>
                {
                    new ItemTypes { Name = "Spoon", Material = "Ivory", MinimunQuantity = 3, MaximunQuantity = 7, MinimunPrice = 10.0f, MaximunPrice = 25.0f },
                }
            },
            {
                Culture.Asian, new List<ItemTypes>
                {
                    new ItemTypes { Name = "Spoon", Material = "Ivory", MinimunQuantity = 3, MaximunQuantity = 7, MinimunPrice = 10.0f, MaximunPrice = 25.0f },
                }
            },

        };
    }
}
