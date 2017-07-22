using System.Collections.Generic;
using UnityEngine;

namespace State
{
    public class PlayerState : MonoBehaviour
    {
        public float InitialMoney = 500.0f;
        public float CurrentMoney;
        private Inventory _inventory = new Inventory();

        public void Awake()
        {
            CurrentMoney = InitialMoney;
        }
    }
}
