using UnityEngine;
using System.Collections;

public class Key : MonoBehaviour {

	public int worth = 1;
    public CollectingKey addKey;

    void Start()
    {
        addKey = GameObject.Find("Collecting Key").GetComponent<CollectingKey>();
    }

    void OnTriggerEnter2D(Collider2D otherCollider)
	{
        string keyName = gameObject.name;
        Movement2D player = otherCollider.gameObject.GetComponent<Movement2D>();
        Debug.Log("Test11111");
        if (player != null && CollectingKey.numberofKey<1) {
            Debug.Log("Test22222");
            if (keyName == "testKey")
            {
                Debug.Log("Test3333");
                addingTheKey(1001);
            }

            KeyCounterScript.score += worth;
			//Destroy (gameObject);


		}

	}

    void addingTheKey(int id)
    {
        addKey.AddKey(id);
        Destroy(gameObject);
    }
}
