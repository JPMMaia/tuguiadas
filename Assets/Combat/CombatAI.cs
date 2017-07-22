using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CombatAI : MonoBehaviour {

    public Transform target;
    public NavMeshAgent agent;
    public Rigidbody rigidbody;

    CombatManager manager;

    // Use this for initialization
    void Start () {
        agent = GetComponent<NavMeshAgent>();
        rigidbody = GetComponent<Rigidbody>();

        manager = GameObject.FindGameObjectWithTag("GameController").GetComponent<CombatManager>();

	}
	
	// Update is called once per frame
	void Update () {
       agent.destination = target.position;
	}


    void FixedUpdate()
    {
        rigidbody.AddForce(manager.windDirection * manager.windStrength, ForceMode.Acceleration);
    }
}
