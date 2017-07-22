using UnityEngine;
using System.Collections;
using System;

public class InventoryManager : MonoBehaviour
{
    ArrayList selectedItems;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetSelected(GameObject obj)
    {
        selectedItems.Add(obj);
    }

    public void UnsetSelected(GameObject obj)
    {
        foreach(GameObject gameObject in selectedItems)
            if(obj == gameObject)
                selectedItems.Remove(obj);
    }

    public ArrayList GetSelected()
    {
        return selectedItems;
    }

}
