using UnityEngine;
using System.Collections;

public class MenuHighScoreScript : MonoBehaviour {


	public Font myFont;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		foreach (Touch t in Input.touches) {
			if(t.phase == TouchPhase.Ended)
			{
				Application.LoadLevel(1);
			}
				}

	}

	void OnGUI()
	{
		GUI.skin.font = myFont;
	
		GUI.skin.label.fontSize = 50;

		GUI.Label(new Rect(Screen.width/2-40,Screen.height/2-220,800,400) ,"Tetris");
		GUI.Label(new Rect(Screen.width/2-100,Screen.height/2-150,800,400) , "High Score: "+PlayerPrefs.GetInt("highScore"));
		GUI.Label(new Rect(Screen.width/2-80,Screen.height/2+20,800,400) , "Tap to Play");

	}
}
