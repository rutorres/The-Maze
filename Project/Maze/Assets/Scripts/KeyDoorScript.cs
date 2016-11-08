using UnityEngine;
using System.Collections;

public class KeyDoorScript : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D otherCollider)
	{
		Movement2D player = otherCollider.gameObject.GetComponent<Movement2D>();
		if (player != null) {
			print(KeyCounterScript.score);
			if (KeyCounterScript.score >= 2) {
				KeyCounterScript.score -= 2;
				Destroy (gameObject);
			}
		}

	}
}
