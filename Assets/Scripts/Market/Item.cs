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
        transform.GetComponent<Button>().onClick.AddListener(TaskOnClick);
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

    public void TaskOnClick()
    {
        if (transform.GetChild(0).GetComponent<Text>().fontSize == 18)
        {
            transform.parent.GetComponent<InventoryManager>().SetSelected(this.gameObject);
            transform.GetChild(0).GetComponent<Text>().fontSize = 20;
            transform.GetChild(0).GetComponent<Text>().fontStyle = FontStyle.Bold;
        }
        else if (transform.GetChild(0).GetComponent<Text>().fontSize == 20)
        {
            transform.parent.GetComponent<InventoryManager>().UnsetSelected(this.gameObject);
            transform.GetChild(0).GetComponent<Text>().fontSize = 18;
            transform.GetChild(0).GetComponent<Text>().fontStyle = FontStyle.Normal;
        }
    }
}
