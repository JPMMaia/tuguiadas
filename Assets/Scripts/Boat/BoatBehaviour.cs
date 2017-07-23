using UnityEngine;

namespace Boat
{
    public class BoatBehaviour : MonoBehaviour
    {
        //public Camera cam;
        enum speed {Slow, ABitFaster, NiceAndSteady, Fast}
        enum hull {None, Weak, Medium, Strong, Fort};
        enum nCannons {None, OneEachSide, ThreeEachSide, SixEachSide, NineEachSide};
        enum rateOfFire { TwoBPS, ThreeBPS, SixBPS, NineBPS};//BPS Bullet Per Second
        enum cannonDmg { Wooden, Copper, Heavy, Explosive};

        public void Start() {
            speed Speed = speed.Slow;
            hull Hull = hull.None;
            nCannons NCannons = nCannons.None;
            rateOfFire ROF = rateOfFire.TwoBPS;
            cannonDmg CannonBallDmg = cannonDmg.Wooden;
        }

        public void Update() {
            this.transform.Translate(new Vector3(1.0f, 0.0f, 0.0f) * (Input.GetAxis("Vertical") * 4.0f) * Time.deltaTime, Space.Self);
            if(Input.GetAxis("Vertical") > 0.0f || Input.GetAxis("Vertical") < -0.0f)
                this.transform.Rotate(0.0f, 0.0f, Input.GetAxis("Horizontal") * 40.0f * Time.deltaTime);
        }
    }
}
