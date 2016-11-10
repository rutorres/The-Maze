using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class KeyPadSystem : MonoBehaviour {


	public static int MaxNumbers=0;
	public Text Code;
	public GameObject KeyPad;
	private bool showing = false;

	public void Update()
	{
			if (Input.GetKeyDown (KeyCode.K) && showing == false) {
			showing = true;
			if (KeyPad != null) {
				KeyPad.active = true;
			}
		} 	else if (Input.GetKeyDown (KeyCode.Escape) && showing == true) {
			showing = false;
			if (KeyPad != null && Code!= null) {
				
				Code.text = "";
				KeyPadSystem.MaxNumbers=0;
				KeyPad.active = false;
			}
		}
	}


}
