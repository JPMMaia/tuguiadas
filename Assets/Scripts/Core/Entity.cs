using UnityEngine;

namespace Core
{
    public class Entity : MonoBehaviour
    {
        public Application Application
        {
            get { return FindObjectOfType<Application>(); }
        }
    }
}
