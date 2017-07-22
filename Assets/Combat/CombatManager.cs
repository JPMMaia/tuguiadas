using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatManager : MonoBehaviour {

    public Vector3 windDirection;
    public float windStrength;

	// Use this for initialization
	void Start () {

        windDirection = Random.insideUnitCircle;
        windDirection = new Vector3(windDirection.x, 0, windDirection.y);
        windStrength = Random.Range(0f, .5f);


        Debug.Log("Wind is " + windStrength * windDirection);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
