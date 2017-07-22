using Collision;
using UnityEngine;

namespace Ports
{
    public class PortView : MonoBehaviour
    {
        public TriggerCollider RangeArea;

        public void Awake()
        {
            RangeArea.OnEnter += RangeArea_OnEnter;
            RangeArea.OnExit += RangeArea_OnExit;
        }

        private void RangeArea_OnEnter(object sender, TriggerCollider.CollisionEventArgs e)
        {
            Debug.Log("Enter port!");
        }
        private void RangeArea_OnExit(object sender, TriggerCollider.CollisionEventArgs e)
        {
            Debug.Log("Exit port!");
        }
    }
}
