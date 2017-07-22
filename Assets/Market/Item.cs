using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    string Name = "Apple";
    string Culture = "Japan";
    int ValueBuy = 50;
    int ValueSell = 40;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.GetChild(0).GetComponent<Text>().text = Name;
        if (transform.parent.name == "Inventory")
            transform.GetChild(1).GetComponent<Text>().text = ValueSell.ToString();
        else if (transform.parent.name == "Market")
            transform.GetChild(1).GetComponent<Text>().text = ValueBuy.ToString();
    }

    void TaskOnClick()
    {
        transform.parent.GetComponent<InventoryManager>().SetSelected(this.gameObject);
    }
}
