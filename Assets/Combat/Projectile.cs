using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    public float ttl = 5;

    public float projDmg;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        ttl -= Time.deltaTime;
        if (ttl<0)
        {
            Destroy(gameObject);
        }
	}

    private void OnCollisionEnter(UnityEngine.Collision collision)
    {
        if (collision.gameObject.GetComponent<CombatShip>())
        {
            collision.gameObject.GetComponent<CombatShip>().hullIntegrity -= projDmg;
            collision.gameObject.GetComponent<CombatShip>().BreakWood();
        }

        if (collision.gameObject.GetComponent<CombatAI>())
        {
            collision.gameObject.GetComponent<CombatAI>().hullIntegrity -= projDmg;
        }

        Destroy(gameObject);
    }


}
