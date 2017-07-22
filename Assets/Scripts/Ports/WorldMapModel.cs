using System;
using System.Collections.Generic;
using UnityEngine;

namespace Ports
{
    public class WorldMapModel
    {
        private readonly List<PortModel> _ports = new List<PortModel>();

        public PortModel CreatePort()
        {
            var port = new PortModel();

            _ports.Add(port);

            return port;
        }
    }
}
