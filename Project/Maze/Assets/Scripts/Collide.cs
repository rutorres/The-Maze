using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Collide : MonoBehaviour {
	public static int MaxNumbers=0;
	public Text Code;
	public GameObject KeyPad = null;
	public bool showing = false;


	// Use this for initialization
	void OnTriggerEnter2D(Collider2D otherCollider)
	{
		Movement2D player = otherCollider.gameObject.GetComponent<Movement2D> ();
			Debug.Log("ok");
			KeyPad.active = true;
			//Destroy(gameObject);
	}

//
//	public void Update()
//	{
//		if (Input.GetKeyDown (KeyCode.K) && showing == false) {
//			showing = true;
//			if (KeyPad != null) {
//				KeyPad.active = true;
//			}
//		} 	else if (Input.GetKeyDown (KeyCode.Escape) && showing == true) {
//			showing = false;
//			if (KeyPad != null && Code!= null) {
//
//				Code.text = "";
//				KeyPadSystem.MaxNumbers=0;
//				KeyPad.active = false;
//			}
//		}
//	}


}
