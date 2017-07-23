﻿using System.Collections.Generic;
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
        public float CrewMaxHealth = 100;
        public float CrewHealth;
        public Inventory Inventory;

        public float FoodDecrementScaler;

        public void Awake()
        {
            DontDestroyOnLoad(gameObject);

            CurrentMoney = InitialMoney;
        }

        public void FixedUpdate()
        {
            // Decrease food along time:
            Food -= FoodDecrementScaler * Time.fixedDeltaTime;
        }
    }
}
