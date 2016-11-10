using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;

public class KeyData : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerDownHandler
{
    public Item item;
    public int slot;
    private CollectingKey cKey;
    private Vector2 _offset;
    Transform originalParent;

    void Start()
    {
        cKey = GameObject.Find("Collecting Key").GetComponent<CollectingKey>();
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        if (item != null)
        {
            originalParent = this.transform.parent;
            _offset = eventData.position - new Vector2(this.transform.position.x, this.transform.position.y);
            this.transform.SetParent(this.transform.parent.parent);
            this.transform.position = eventData.position - _offset;
           // GetComponent<CanvasGroup>().blocksRaycasts = false;

        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (item != null)
        {
            this.transform.position = eventData.position - _offset;

        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        this.transform.SetParent(originalParent);
        this.transform.position = cKey.slots[slot].transform.position;
      //  GetComponent<CanvasGroup>().blocksRaycasts = true;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (item != null)
        {
            _offset = eventData.position - new Vector2(this.transform.position.x, this.transform.position.y);
        }
    }
}

