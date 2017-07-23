﻿using System;
using Collision;
using Core;
using UnityEngine;

namespace Ports
{
    public class PortView : Entity
    {
        public TriggerCollider RangeArea;
        public String Name;
        public Culture Culture;

        public void Awake()
        {
            RangeArea.OnEnter += RangeArea_OnEnter;
            RangeArea.OnExit += RangeArea_OnExit;
        }

        private void RangeArea_OnEnter(object sender, TriggerCollider.CollisionEventArgs e)
        {
            Debug.Log("Enter port!");

            // TODO Generate port inventory based on the culture:

            // TODO Present merchant view:
        }
        private void RangeArea_OnExit(object sender, TriggerCollider.CollisionEventArgs e)
        {
            Debug.Log("Exit port!");
        }
    }
}
