using UnityEngine;
using UnityEngine.SceneManagement;

namespace State
{
    public class PlayerState : MonoBehaviour
    {
        public Vector3 PositionBeforeBattle;

        public float InitialMoney = 500.0f;
        public float CurrentMoney;
        public float FoodCapacity = 500.0f;
        public float Food;
        public int AmmoCapacity = 500;
        public int Ammo;
        public float CrewMaxHealth = 100;
        public float CrewHealth;
        public Inventory Inventory;

        public float FoodDecrementScaler = 0.1f;

        public void Awake()
        {
            DontDestroyOnLoad(gameObject);

            CurrentMoney = InitialMoney;
        }

        public void FixedUpdate()
        {
            if (SceneManager.GetActiveScene().name == "Default")
            {
                HandleFood();
                HandleCrewHealth();
            }
        }

        private void HandleFood()
        {
            // Decrease food along time:
            Food -= FoodDecrementScaler * Time.fixedDeltaTime;

            // Check for game over condition:
            if (Food <= 0.0f)
                SceneManager.LoadScene("Game Over");
        }

        private void HandleCrewHealth()
        {
            // Check for game over condition:
            if (CrewHealth <= 0.0f)
                SceneManager.LoadScene("Game Over");
        }
    }
}
