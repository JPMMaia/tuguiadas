using UnityEngine;

namespace Boat
{
    public class BoatBehaviour : MonoBehaviour
    {
        public int speed;

        public void Start() {
            
        }

        public void Update() {
            this.transform.Translate(Vector3.forward * (Input.GetAxis("Vertical") * 4.0f) * Time.deltaTime);
            if(Input.GetAxis("Vertical") > 0.5 || Input.GetAxis("Vertical") < -0.5)
                this.transform.Rotate(0.0f, Input.GetAxis("Horizontal"), 0.0f);
        }
    }
}
