using UnityEngine;
using System.Collections;

public class GUIHandler : MonoBehaviour {

	float elapsedTime;
	float elapsedCounter;

	bool loaded = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	   
		if(Application.loadedLevelName=="GameOver" && !loaded)
		{
			elapsedTime = Time.time;
			loaded = true;
			elapsedCounter = elapsedTime;
		}
		elapsedCounter += Time.deltaTime;


		if((elapsedCounter - elapsedTime) > 5.0f)
		{
			loaded = false;
			Application.LoadLevel(4);
		}

	}



}
