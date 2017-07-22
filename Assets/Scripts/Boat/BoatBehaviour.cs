using UnityEngine;

namespace Boat
{
    public class BoatBehaviour : MonoBehaviour
    {
        //public Camera cam;

        public void Start() {
            
        }

        public void Update() {
            this.transform.Translate(Vector3.forward * (Input.GetAxis("Vertical") * 4.0f) * Time.deltaTime);

            if(Input.GetAxis("Vertical") > 0.0f || Input.GetAxis("Vertical") < -0.0f)
                this.transform.Rotate(0.0f, Input.GetAxis("Horizontal") * 40.0f * Time.deltaTime, 0.0f);
        }
    }
}
