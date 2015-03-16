using UnityEngine;
using System.Collections;

public class SpawnerScript : MonoBehaviour {


	//Groups
	public GameObject[] groups;


	public void spawnerNext()
	{
		int i = Random.Range (0,groups.Length);
		Instantiate (groups[i],transform.position,Quaternion.identity);
	}


	// Use this for initialization
	void Start () {
		spawnerNext ();
	}
	
	// Update is called once per frame
	void Update () {
	   



	}

}
