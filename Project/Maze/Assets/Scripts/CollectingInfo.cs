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
            if(this.gameObject.name=="info1")
            {
                addingTheInfo(0);
            }
            else if(this.gameObject.name == "info2")
            {
                addingTheInfo(1);
            }
        }

    }

    void addingTheInfo(int id)
    {
        Destroy(gameObject);
        addInfo.AddItem(id);
    }
}

