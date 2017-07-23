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
        public Inventory Inventory;

        public void Awake()
        {
            DontDestroyOnLoad(gameObject);

            CurrentMoney = InitialMoney;
        }

        public void Buy(List<Item> list)
        {
            foreach (var item in list)
                CurrentMoney -= item.ValueBuy;

            //TODO: add list to the inventory
        }

        public void Sell(List<Item> list)
        {
            foreach (var item in list)
                CurrentMoney += item.ValueSell;

            //TODO: remove list to the inventory
        }
    }
}
