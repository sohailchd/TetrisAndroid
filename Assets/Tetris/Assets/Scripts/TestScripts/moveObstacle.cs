using UnityEngine;
using System.Collections;

public class moveObstacle : MonoBehaviour {

	public Rigidbody rdg;

	// Use this for initialization
	void Start () {
		rdg = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey("up"))
		{
			rdg.AddForce(transform.up*10.0f);
		}
	}

	void FixedUpdate()
	{
       
	}
}
