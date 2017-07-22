using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarketManager : MonoBehaviour {

    GameObject inv;
    GameObject mark;

	// Use this for initialization
	void Start ()
    {
        inv = GameObject.Find("Inventory");
        mark = GameObject.Find("Market");
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    void GoLeft()
    {
        inv.GetComponent<InventoryManager>().GetSelected().transform.SetParent(mark.transform);
    }

    void GoRight()
    {
        mark.GetComponent<InventoryManager>().GetSelected().transform.SetParent(inv.transform);
    }
}
