using System.Collections.Generic;

namespace Ports
{
    public class PortsByCulture
    {
        public Dictionary<Culture, PortView> Ports = new Dictionary<Culture, PortView>
        {
            { Culture.European, new PortView { Name = "Lisbon" } },

            { Culture.African, new PortView { Name = "Sierra Leone" } },
            { Culture.African, new PortView { Name = "Benin" } },
            { Culture.African, new PortView { Name = "Kingdom of Kongo" } },

            { Culture.Indian, new PortView { Name = "Goa" } },
            { Culture.Indian, new PortView { Name = "Bengala" } },
            { Culture.Indian, new PortView { Name = "Portuguese Indian" } },

            { Culture.Asian, new PortView { Name = "China" } },
            { Culture.Asian, new PortView { Name = "Japan" } }
        };
    }
}
