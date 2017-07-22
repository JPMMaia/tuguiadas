using UnityEngine;

namespace State
{
    public class PlayerState : MonoBehaviour
    {
        public float InitialMoney = 500.0f;
        public float CurrentMoney;

        public void Awake()
        {
            CurrentMoney = InitialMoney;
        }
    }
}
