using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatShip : MonoBehaviour {

    public float hullIntegrity;
    public int nCannons;
    public float cannonBallDamage;
    public float cannonRof;

    public Transform starboard;
    public Transform port;

    private float starboardCD = 0.0f;
    private float portCD = 0.0f;

    public GameObject cannonBall;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetMouseButton(0))
            FirePort();
        else if (Input.GetMouseButton(1))
            FireStarboard();


        UpdateCooldowns();
	}
    void UpdateCooldowns()
    {
        starboardCD -= Time.deltaTime;
        portCD -= Time.deltaTime;

    }
    void FirePort()
    {
        if (portCD <= 0)
        {
            StartCoroutine(firePortSide(true));
            portCD = 1 / cannonRof;
        }
    }
    void FireStarboard()
    {
        if (starboardCD <= 0)
        {
            StartCoroutine(firePortSide(false));
            starboardCD = 1 / cannonRof;
        }

    }

    IEnumerator firePortSide (bool fireFromPort)
    {
        int nPortCannons = nCannons / 2;

        for (int i = 0; i < nPortCannons; i++)
        {
            var sideTransform = (fireFromPort ? port : starboard);
                GameObject projectile = Instantiate(cannonBall,
               Random.Range(-1f, 1f) * sideTransform.forward +
               Random.Range(-1f, 1f) * sideTransform.right
               + sideTransform.position,
               Quaternion.identity);

                projectile.GetComponent<Rigidbody>().velocity = (fireFromPort ? -1 : 1) * transform.right * Random.Range(10, 15) + transform.up * Random.Range(6, 8) + transform.forward*Random.Range(-2,2);
            

            yield return new WaitForSeconds(0.05f);
        }

        yield return null;
    }
}
