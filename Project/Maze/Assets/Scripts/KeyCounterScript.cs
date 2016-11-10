using UnityEngine;
using System.Collections;

public class KeyCounterScript : MonoBehaviour {

	public static int score=0;

	private GUIStyle guiStyle=new GUIStyle();

	private void OnGUI()
	{
		guiStyle.fontSize = 40;
		guiStyle.normal.textColor = Color.white;
		GUI.Label (new Rect (10, 50, 1000, 200), ("Keys: " + score), guiStyle);
	}
}
