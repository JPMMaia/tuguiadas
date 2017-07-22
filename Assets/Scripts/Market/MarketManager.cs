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
        foreach(GameObject item in inv.GetComponent<InventoryManager>().GetSelected())
            item.transform.SetParent(mark.transform);
    }

    void GoRight()
    {
        foreach(GameObject item in mark.GetComponent<InventoryManager>().GetSelected())
            item.transform.SetParent(inv.transform);
    }
}
