using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class ButtonAdd : MonoBehaviour {

	public Image button;
	public Text Code;
	public Color Hover;
	public Color Original;
	public string addNumber;
	public AudioSource Press;

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
		Press.Play ();
		if (KeyPadSystem.MaxNumbers < 5) {//cheking if typing count number is less than 4
		
			Code.text += addNumber;
			KeyPadSystem.MaxNumbers++;
		}
		//input = GameObject.Find ("textField").GetComponent <Text> ();
			
	}


}
