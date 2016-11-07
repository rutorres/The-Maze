using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class Activate : MonoBehaviour {

	public Image button;
	public Text Code;
	public Color Hover;
	public Color Original;
	public String scene;

	public void OnMouseEnter()
	{
		button.color = Hover;
	}

	public void OnMouseExit()
	{
		button.color = Original;
	}

	public void OnMouseDown()
	{
		if (Code.text == "54321") {//cheking if typing count number is correct

			Debug.Log ("Correct");
			Application.LoadLevel (scene);

		} else { //if code is incorrect

			Code.text = "";
			KeyPadSystem.MaxNumbers = 0;
			Debug.Log ("Incorrect");
		}

	}
}
