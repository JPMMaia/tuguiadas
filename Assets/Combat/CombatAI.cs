using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CombatAI : MonoBehaviour {

    public Transform target;
    public NavMeshAgent agent;
    public Rigidbody rigidbody;

    public float ShootingDist;

    CombatManager manager;


    public float hullIntegrity;
    public int nCannons;
    public float cannonBallDamage;
    public float cannonRof;

    public Transform starboard;
    public Transform port;
    AudioSource audioSrc;

    private float starboardCD = 0.0f;
    private float portCD = 0.0f;

    private float ang;
    private float distToTarget;

    public GameObject cannonBall;
    public GameObject muzzleParticle;

    private int targettingLayerMask;


    public enum AIState
    {
       
        Chase,
        Engaged,
        Flee
    }

    public AIState currentState;

    // Use this for initialization
    void Start () {
        agent = GetComponent<NavMeshAgent>();
        rigidbody = GetComponent<Rigidbody>();
        audioSrc = GetComponent<AudioSource>();

        manager = GameObject.FindGameObjectWithTag("GameController").GetComponent<CombatManager>();
        agent.stoppingDistance = ShootingDist * .8f;

        if (Vector3.Distance(transform.position, target.transform.position) < ShootingDist)
            currentState = AIState.Engaged;
        else
            currentState = AIState.Chase;

        targettingLayerMask = 1 << 8;

	}
	
	// Update is called once per frame
	void Update () {

        distToTarget = Vector3.Distance(target.position, transform.position);
        switch (currentState)
        {
            case AIState.Chase:
                NavMeshPath p = new NavMeshPath() ;
                agent.CalculatePath(target.position, p);
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(p.corners[1] - transform.position, transform.up),.5f*Time.deltaTime);

                

                agent.destination = target.position;

                if (distToTarget < ShootingDist)
                    currentState = AIState.Engaged;
                break;
            case AIState.Engaged:

                if (distToTarget > ShootingDist)
                    currentState = AIState.Chase;

                // Allign ship's broadside
                Vector3 toTarget = target.position - transform.position;
                ang = Vector3.Angle(toTarget, transform.forward);
                if (ang < 90)
                {
                    if (Mathf.Abs(AngleSigned( toTarget, -transform.right, transform.up))
                        < Mathf.Abs(AngleSigned(toTarget, transform.right, transform.up)))
                    {
                        ang = 1;
                        //Debug.Log("Turning Right");
                    }
                    else
                    {
                        ang = -1;
                        //Debug.Log("Turning Left");
                    }
                } else
                {
                    if (Mathf.Abs(AngleSigned(toTarget, -transform.right, transform.up))
                        < Mathf.Abs(AngleSigned(toTarget, transform.right, transform.up)))
                    {
                        ang = -1;
                        //Debug.Log("Turning Left");
                    }
                    else
                    {
                        ang = 1;
                        //Debug.Log("Turning Right");
                    }
                }
                
                break;

        }

        UpdateCooldowns();

        if (hullIntegrity < 0)
        {
            Debug.Log("MORRRRRRRRRRRRRIIIIIIIIIIIIIIIIIIIII!");
            Destroy(gameObject);
        }
	}


    void FixedUpdate()
    {
        rigidbody.AddForce(manager.windDirection * manager.windStrength, ForceMode.Acceleration);
        rigidbody.AddTorque(transform.up * ang * 1.5f);


        if (Physics.Raycast(transform.position, transform.right, ShootingDist, targettingLayerMask))
        {
            FireStarboard();
        }
        else if (Physics.Raycast(transform.position, -transform.right, ShootingDist, targettingLayerMask))
        {
            FirePort();
        }
    }

    public static float AngleSigned(Vector3 v1, Vector3 v2, Vector3 n)
    {
        return Mathf.Atan2(
            Vector3.Dot(n, Vector3.Cross(v1, v2)),
            Vector3.Dot(v1, v2)) * Mathf.Rad2Deg;
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

    IEnumerator firePortSide(bool fireFromPort)
    {
        int nPortCannons = nCannons / 2;

        for (int i = 0; i < nPortCannons; i++)
        {
            var sideTransform = (fireFromPort ? port : starboard);

            Vector3 firePos =
               Random.Range(-.5f, .5f) * sideTransform.forward +
               Random.Range(-3f, 3f) * sideTransform.right
               + sideTransform.position;

            GameObject projectile = Instantiate(cannonBall,
                firePos,
                Quaternion.identity);

            projectile.GetComponent<Rigidbody>().velocity =
                (fireFromPort ? -1 : 1) * transform.right * Random.Range(15, 25)
                + transform.up * Random.Range(6, 8) * (distToTarget/ShootingDist)
                + transform.forward * Random.Range(-2, 2);

            audioSrc.PlayOneShot(audioSrc.clip, 1);
            Instantiate(muzzleParticle, firePos, sideTransform.rotation);

            yield return new WaitForSeconds(0.05f);
        }

        yield return null;
    }
}
