using UnityEngine;
using System.Collections;

public class DoorButtonScript : MonoBehaviour {

	// Use this for initialization
	void OnTriggerEnter2D(Collider2D otherCollider)
	{
		Movement2D player = otherCollider.gameObject.GetComponent<Movement2D>();
		if (player != null) {
			Destroy (transform.parent.gameObject);
		}

	}

	void Start()
	{
		// 2 - Limited time to live to avoid any leak
		// Destroy(gameObject, 20); // 20sec
	}
}
