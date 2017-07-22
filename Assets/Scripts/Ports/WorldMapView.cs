using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ports
{
    public class WorldMapView : MonoBehaviour, IEnumerable<PortView>
    {
        public PortView[] Collection
        {
            get
            {
                return GetComponentsInChildren<PortView>();
            }
        }

        public IEnumerator<PortView> GetEnumerator()
        {
            return (IEnumerator<PortView>) Collection.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
