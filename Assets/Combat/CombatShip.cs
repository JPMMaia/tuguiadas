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
    public AudioSource audioCannon;
    public AudioSource audioWood;


    private float starboardCD = 0.0f;
    private float portCD = 0.0f;

    public GameObject cannonBall;
    public GameObject muzzleParticle;

	// Use this for initialization
	void Start () {
        audioCannon = GetComponent<AudioSource>();

    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetMouseButton(0))
            FirePort();
        else if (Input.GetMouseButton(1))
            FireStarboard();


        UpdateCooldowns();


        if (hullIntegrity < 0)
        {
            Debug.Log("MORRRRRRRRRRRRRIIIIIIIIIIIIIIIIIIIII!");
            Destroy(gameObject);
        }
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

            Vector3 firePos =
               Random.Range(-1f, 1f) * sideTransform.forward +
               Random.Range(-1f, 1f) * sideTransform.right
               + sideTransform.position;

                GameObject projectile = Instantiate(cannonBall,
                    firePos,
                    Quaternion.identity);

            projectile.GetComponent<Rigidbody>().velocity = (fireFromPort ? -1 : 1) * transform.right * Random.Range(15, 25) + transform.up * Random.Range(6, 8) + transform.forward*Random.Range(-2,2);

            projectile.GetComponent<Projectile>().projDmg = cannonBallDamage;

            audioCannon.PlayOneShot(audioCannon.clip);
            Instantiate(muzzleParticle, firePos, sideTransform.rotation);
            

            yield return new WaitForSeconds(2f/ nPortCannons);
        }

        yield return null;
    }

    public void BreakWood()
    {

        StartCoroutine(woodBreaking());
    }

    IEnumerator woodBreaking()
    {

        for (int i = 0; i < 5; i++)
        {
            audioWood.PlayOneShot(audioWood.clip);
            yield return new WaitForSeconds(0.05f);
        }

        yield return null;
    }
}
