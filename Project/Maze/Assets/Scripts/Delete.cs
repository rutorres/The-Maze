using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Delete : MonoBehaviour {

	public Image button;
	public Text Code;
	public Color Hover;
	public Color Original;


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
		if (KeyPadSystem.MaxNumbers < 6) {//cheking if typing count number is less than 6

			Code.text = "";
			KeyPadSystem.MaxNumbers=0;
		}
		//input = GameObject.Find ("textField").GetComponent <Text> ();			
	}
}
