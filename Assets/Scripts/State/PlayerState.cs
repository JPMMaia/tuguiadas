using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace State
{
    public class PlayerState : MonoBehaviour
    {
        public float InitialMoney = 500.0f;
        public float CurrentMoney;
        public int FoodCapacity = 500;
        public int Food;
        public int AmmoCapacity = 500;
        public int Ammo;
        public float CrewMaxHealth = 500;
        public float CrewHealth;
        private Inventory _inventory = new Inventory();

        public void Awake()
        {
            CurrentMoney = InitialMoney;
        }

        public void Buy(ArrayList list)
        {
            foreach (Item item in list)
                CurrentMoney -= item.ValueBuy;

            //TODO: add list to the inventory
        }

        public void Sell(ArrayList list)
        {
            foreach (Item item in list)
                CurrentMoney += item.ValueSell;

            //TODO: remove list to the inventory
        }
    }
}
