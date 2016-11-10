using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;

public class SlotKey : MonoBehaviour, IDropHandler
{
    public int id;
    private CollectingKey cKey;

    void Start()
    {
        cKey = GameObject.Find("Collecting Key").GetComponent<CollectingKey>();
    }

    public void OnDrop(PointerEventData eventData)
    {
        KeyData droppedItem = eventData.pointerDrag.GetComponent<KeyData>();
        if (cKey.items[id].ID == -1)
        {
            cKey.items[droppedItem.slot] = new Item();
            cKey.items[id] = droppedItem.item;
            droppedItem.slot = id;
        }

        else if (droppedItem.slot != id)
        {
            Transform item = this.transform.GetChild(0);
            item.GetComponent<KeyData>().slot = droppedItem.slot;
            item.transform.SetParent(cKey.slots[droppedItem.slot].transform);
            item.transform.position = cKey.slots[droppedItem.slot].transform.position;

            droppedItem.slot = id;
            droppedItem.transform.SetParent(this.transform);
            droppedItem.transform.position = this.transform.position;

            cKey.items[droppedItem.slot] = item.GetComponent<KeyData>().item;
            cKey.items[id] = droppedItem.item;
        }

    }
}
