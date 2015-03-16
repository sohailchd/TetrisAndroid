using UnityEngine;
using System.Collections;

public class moveSpot : MonoBehaviour {


	public float posX;
	public float posY;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	 
		transform.position += new Vector3 (Mathf.Sin(Time.time)/100.0f*posX,Mathf.Cos(Time.time)/100.0f*posY,0.0f);

	}
}
