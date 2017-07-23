using UnityEngine;

namespace Boat
{
    public class BoatBehaviour : MonoBehaviour
    {
        public GameObject map;
        public GameObject fogSample;
        public int fogSampleSize;
        public int fogSize;

        public void Start() {
            for(int i = 0; i < fogSize; i++) {
                for(int j = 0; j < fogSize; j++) {
                    Quaternion rotation = Quaternion.identity;
                    rotation.eulerAngles = new Vector3(90.0f, Random.Range(-20.0f, 20.0f), 0.0f);
                    Instantiate(fogSample, new Vector3(fogSampleSize * j - fogSize/2, Random.Range(0.0f, 2.0f), (fogSampleSize - 1) * i - fogSize/2), rotation, map.transform);
                }
            }
        }

        public void Update() {
            this.transform.Translate(new Vector3(1.0f, 0.0f, 0.0f) * (Input.GetAxis("Vertical") * 4.0f) * Time.deltaTime, Space.Self);
            if(Input.GetAxis("Vertical") > 0.0f || Input.GetAxis("Vertical") < -0.0f)
                this.transform.Rotate(0.0f, 0.0f, Input.GetAxis("Horizontal") * 40.0f * Time.deltaTime);

            //mantain cloud rotation in relation to camera
            for(int i = 0; i < map.transform.childCount; i++) {
                map.transform.GetChild(i).Rotate(0.0f, 0.0f, Input.GetAxis("Horizontal") * -40.0f * Time.deltaTime);
            }

            //move away and destroy close clouds
            for(int i = 0; i < map.transform.childCount; i++) {
                if(Vector3.Distance(this.transform.position, map.transform.GetChild(i).transform.position) < 7.0f) {
                    Destroy(map.transform.GetChild(i).gameObject, 1.0f);
                    map.transform.GetChild(i).GetComponent<Rigidbody>().velocity = (map.transform.GetChild(i).transform.position - this.transform.position).normalized * 5.0f;
                }
            }
        }
    }
}
