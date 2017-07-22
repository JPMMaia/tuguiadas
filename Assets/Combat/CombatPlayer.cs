using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatPlayer : MonoBehaviour {

    public Rigidbody rigidbody;

    CombatManager manager;

    public float fwdSpeed = 10f;
    public float turnSpeed = 2f;

    // Use this for initialization
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();

        manager = GameObject.FindGameObjectWithTag("GameController").GetComponent<CombatManager>();
        
        
    }
    public void Update()
    {
    }


    void FixedUpdate()
    {
        rigidbody.AddForce(manager.windDirection * manager.windStrength, ForceMode.Acceleration);


        rigidbody.AddForce(transform.forward * Input.GetAxis("Vertical") * fwdSpeed);

        rigidbody.AddTorque(transform.up * Input.GetAxis("Horizontal") * turnSpeed);

    }
}
