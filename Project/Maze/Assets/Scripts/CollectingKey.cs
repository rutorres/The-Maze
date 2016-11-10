using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class CollectingKey : MonoBehaviour
{
    ItemDatabase database;
    GameObject inventoryPanel;
    GameObject keyPanel;
    public GameObject inventorySlot;
    public GameObject inventoryItem;

    public List<Item> items = new List<Item>();
    public List<GameObject> slots = new List<GameObject>();
    public static int numberofKey = 0;

    void Start()
    {
        database = GetComponent<ItemDatabase>();
        inventoryPanel = GameObject.Find("Inventory Panel");
        keyPanel = inventoryPanel.transform.FindChild("Key Panel").gameObject;
        
            items.Add(new Item());
            slots.Add(Instantiate(inventorySlot));
            slots[0].GetComponent<Slot>().id = 0;
            slots[0].transform.SetParent(keyPanel.transform);
    }

    public void AddKey(int id)
    {
        numberofKey += 1;
        Item itemToAdd = database.FetchItemByID(id);
            if (items[0].ID == -1)
            {
                items[0] = itemToAdd;
                GameObject itemObj = Instantiate(inventoryItem);
                itemObj.GetComponent<KeyData>().item = itemToAdd;
                itemObj.GetComponent<KeyData>().slot = 0;
                itemObj.transform.SetParent(slots[0].transform);
                itemObj.transform.position = slots[0].transform.position;// Vector2.zero;
                itemObj.GetComponent<Image>().sprite = itemToAdd.Sprite;
                itemObj.name = itemToAdd.Title;
            }
    }
}
