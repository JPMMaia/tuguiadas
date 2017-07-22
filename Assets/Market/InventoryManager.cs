using UnityEngine;
using System.Collections;

public class InventoryManager : MonoBehaviour
{
    GameObject selected;

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
        selected = obj;
    }

    public GameObject GetSelected()
    {
        return selected;
    }
}
