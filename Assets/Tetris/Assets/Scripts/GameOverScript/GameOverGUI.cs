using UnityEngine;
using System.Collections;

public class GameOverGUI : MonoBehaviour {

	public GUISkin myGUISkin;
	public int posX;
	public int posY;
	float tapOne;
	float tapTwo;

	public Font myFont;

	// Use this for initialization
	void Start () {
	
	}

	int counter = 0;

	// Update is called once per frame
	void Update () {
		if(checkDoubleTap())
		{
			Grid.Gscore = 0;
			Application.LoadLevel(1);
		}
	}

	void OnGUI()
	{
		
		GUI.skin.font = myFont;
		GUI.skin.label.fontSize = 80;
		GUI.Label(new Rect(Screen.width/2-40,Screen.height/2-60,800,400) , "Double to retry");
		GUI.Label(new Rect(Screen.width/2-40,Screen.height/2-120,800,400) , "HScore: "+PlayerPrefs.GetInt("highScore"));


	}

	bool checkDoubleTap()
	{
		bool ret = false;




		foreach (Touch t in Input.touches) 
		{

			if(t.phase == TouchPhase.Ended  && tapOne==0)
			{
				tapOne = Time.time;
			}
		}  

		if(tapTwo  >= 0 && tapOne!=0)
		{
			foreach (Touch t in Input.touches) 
			{
				if(t.phase == TouchPhase.Ended)
				{
					ret = true;
					return ret;
				}
			}
			
		}

		if(tapOne!=0)
		{
			tapTwo+= Time.deltaTime;
		}
		// incase more than 0.5 secs
		if(tapOne-tapTwo > 1.0f)
		{
			tapOne = 0.0f;
			tapTwo = 0.0f;
		}


		return false;
	}

}
