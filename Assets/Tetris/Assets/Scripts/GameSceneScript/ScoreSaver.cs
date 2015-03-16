using UnityEngine;
using System.Collections;

public class ScoreSaver : MonoBehaviour {



	static int highScoreInt;
	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
	    
		highScoreInt = PlayerPrefs.GetInt ("highScore" , 0);
	}


}
