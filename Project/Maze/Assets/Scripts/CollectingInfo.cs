using UnityEngine;
using System.Collections;

public class CollectingInfo : MonoBehaviour {

    public Inventory addInfo;

    void Start()
    {
        addInfo = GameObject.Find("Inventory").GetComponent<Inventory>();
    }

    void OnTriggerEnter2D(Collider2D otherCollider)
    {
        Movement2D avatar = otherCollider.gameObject.GetComponent<Movement2D>();
        if (avatar != null)
        {
            Destroy(gameObject);
            addInfo.AddItem(0);
            Debug.Log("nothing");
        }

    }
}

