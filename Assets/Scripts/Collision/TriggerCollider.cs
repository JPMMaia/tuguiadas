using System;
using UnityEngine;

namespace Collision
{
    public class TriggerCollider : MonoBehaviour
    {
        public class CollisionEventArgs : EventArgs
        {
            public Collider TriggerCollider { get; set; }
        }

        public event EventHandler<CollisionEventArgs> OnEnter;
        public event EventHandler<CollisionEventArgs> OnExit;

        public void OnTriggerEnter(Collider other)
        {
            if(OnEnter != null)
                OnEnter(this, new CollisionEventArgs { TriggerCollider = other });
        }
        public void OnTriggerExit(Collider other)
        {
            if (OnExit != null)
                OnExit(this, new CollisionEventArgs { TriggerCollider = other });
        }
    }
}