using UnityEngine;
using System.Collections;

public class Collide : MonoBehaviour {

	// Use this for initialization
	void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.name == "t") {
			Destroy(col.gameObject);
		}
	}
}
