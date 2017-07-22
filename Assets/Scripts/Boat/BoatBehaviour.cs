using UnityEngine;

namespace Boat
{
    public class BoatBehaviour : MonoBehaviour
    {
        //public Camera cam;

        public void Start() {
            
        }

        public void Update() {
            this.transform.Translate(new Vector3(1.0f, 0.0f, 0.0f) * (Input.GetAxis("Vertical") * 4.0f) * Time.deltaTime, Space.Self);
            if(Input.GetAxis("Vertical") > 0.0f || Input.GetAxis("Vertical") < -0.0f)
                this.transform.Rotate(0.0f, 0.0f, Input.GetAxis("Horizontal") * 40.0f * Time.deltaTime);
        }
    }
}
