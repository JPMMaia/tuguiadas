﻿using Collision;
using Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ports
{
    public class CombatStart : Entity
    {
        public TriggerCollider RangeArea;

        public void Awake()
        {
            RangeArea.OnEnter += RangeArea_OnEnter;
            RangeArea.OnExit += RangeArea_OnExit;
        }

        private void RangeArea_OnEnter(object sender, TriggerCollider.CollisionEventArgs e)
        {
            Debug.Log("A wild fleet appeared!!");

            // Start combat
            UnityEngine.SceneManagement.SceneManager.LoadScene("Combat");
        }

        private void RangeArea_OnExit(object sender, TriggerCollider.CollisionEventArgs e)
        {
            Debug.Log("Exit port!");
        }
    }
}