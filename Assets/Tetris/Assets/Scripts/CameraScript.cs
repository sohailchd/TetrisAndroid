using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {

	public GUIStyle CStyle;
	public Font myFont;
	public int score = 0;



	// Use this for initialization
	void Start () {
	    

		CStyle = new GUIStyle ();

	
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnGUI()
	{
		GUI.skin.font = myFont;
		GUI.skin.label.fontSize = 80;
		GUI.Label(new Rect(25,10,400,860) , "Score: "+ Grid.Gscore.ToString());
	}


}
