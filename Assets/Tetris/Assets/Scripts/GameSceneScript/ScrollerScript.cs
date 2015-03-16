using UnityEngine;
using System.Collections;

public class ScrollerScript : MonoBehaviour {


    Vector2 startPos;
	public float xPos ;
	public float yPos;

	// Use this for initialization
	void Start () {
		startPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () 
	{


		if(transform.position.x - startPos.x > -14.2f)
		{
		transform.position += new Vector3 (-0.01f,0.0f,0.0f);
		}
		else
		{
			transform.position += new Vector3(14.2f,0.0f,0.0f); 
		}
	}
}
