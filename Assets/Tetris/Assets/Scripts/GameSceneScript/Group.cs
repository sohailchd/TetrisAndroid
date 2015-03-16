using UnityEngine;
using System.Collections;

public class Group : MonoBehaviour {

	float lastFall = 0.0f;


	float xStart = 0.0f;
	float xEnd = 0.0f;
	float yStart = 0.0f;
	float yEnd = 0.0f;
	bool sendCall = true;

	public int score = 0;
	public bool paused = false;

	bool isValidGridPos()
	{        
		foreach (Transform child in transform) {
			Vector2 v = Grid.roundVec2(child.position);
			
			// Not inside Border?
			if (!Grid.insideBorder(v))
				return false;
			
			// Block in grid cell (and not part of same group)?
			if (Grid.grid[(int)v.x, (int)v.y] != null &&
			    Grid.grid[(int)v.x, (int)v.y].parent != transform)
				return false;
		}
		return true;
	}
	
	
	public void updateGrid()
	{
		for(int y=0;y<Grid.h;++y)
		{
			for(int x=0;x<Grid.w;++x)
			{
				if(Grid.grid[x,y]!=null)
				{
					if(Grid.grid[x,y].parent == transform)
					{
						Grid.grid[x,y] = null;
					}
				}
			}
		}
		
		// Add new children to grid
		foreach (Transform child in transform) {
			Vector2 v = Grid.roundVec2(child.position);
			Grid.grid[(int)v.x, (int)v.y] = child;
		} 
	}
	//**********

	// Use this for initialization
	void Start () {

		score = 0;

		if (!isValidGridPos()) {

			if(Grid.Gscore > PlayerPrefs.GetInt("highScore"))
			{
				PlayerPrefs.SetInt("highScore" , Grid.Gscore);
				PlayerPrefs.Save();
			}

			Debug.Log("GAME OVER");
			Destroy(gameObject);
			Application.LoadLevel(2);
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
	

	
				score = Grid.Gscore;
				//Touch _touch = Input.GetTouch (0);
				// Move Left
				if (Input.GetKeyDown (KeyCode.LeftArrow) || checkSwipe ('L'))
		     {
						// Modify position
						transform.position += new Vector3 (-1, 0, 0);
			
						// See if valid
						if (isValidGridPos ())
				// It's valid. Update grid.
								updateGrid ();
						else
				// It's not valid. revert.
								transform.position += new Vector3 (1, 0, 0);
				}
		
		// Move Right
		else if (Input.GetKeyDown (KeyCode.RightArrow) || checkSwipe ('R')) {
						// Modify position
						transform.position += new Vector3 (1, 0, 0);
			
						// See if valid
						if (isValidGridPos ())
				// It's valid. Update grid.
								updateGrid ();
						else
				// It's not valid. revert.
								transform.position += new Vector3 (-1, 0, 0);
				}
		
		// Rotate || _touch.phase == TouchPhase.Ended
		else if (Input.GetKeyDown (KeyCode.UpArrow)) {
						transform.Rotate (0, 0, -90);
			
						// See if valid
						if (isValidGridPos ())
				// It's valid. Update grid.
								updateGrid ();
						else
				// It's not valid. revert.
								transform.Rotate (0, 0, 90);
				}
		
		// Move Downwards and Fall
		else if (Input.GetKeyDown (KeyCode.DownArrow) ||
						Time.time - lastFall >= 0.5) {
						// Modify position
						transform.position += new Vector3 (0, -1, 0);
			
						// See if valid
						if (isValidGridPos ()) {
								// It's valid. Update grid.
								updateGrid ();
						} else {
								// It's not valid. revert.
								transform.position += new Vector3 (0, 1, 0);
				
								// Clear filled horizontal lines
								Grid.deleteFullRows ();
				
								// Spawn next Group
								FindObjectOfType<SpawnerScript> ().spawnerNext ();
				
								// Disable script
								enabled = false;
						}
			
						lastFall = Time.time;
				}

				//*************************************
				//foreach (Touch t in Input.touches) {

						if (checkSwipe ('U')) 
			            {
								transform.Rotate (0, 0, -90);
				
								// See if valid
								if (isValidGridPos ())
					// It's valid. Update grid.
										updateGrid ();
								else
					// It's not valid. revert.
										transform.Rotate (0, 0, 90);
						} 
			            else if (checkSwipe ('D') ||
								Time.time - lastFall >= 1)
			            {
								// Modify position
								transform.position += new Vector3 (0, -1, 0);
				
								// See if valid
								if (isValidGridPos ()) {
										// It's valid. Update grid.
										updateGrid ();
								} else {
										// It's not valid. revert.
										transform.position += new Vector3 (0, 1, 0);
					
										// Clear filled horizontal lines
										Grid.deleteFullRows ();
					
										// Spawn next Group
										FindObjectOfType<SpawnerScript> ().spawnerNext ();
					
										// Disable script
										enabled = false;
								}


								lastFall = Time.time;
						}

		        
		if(Input.GetKeyDown(KeyCode.Escape) )
		{
			paused = true;
			Application.LoadLevel(0);
		}

				}

		//}

	bool checkSwipe (char d)
	{
		bool dir = false;

		foreach (Touch touch in Input.touches)
		{
			
			if (touch.phase == TouchPhase.Began) {
				xStart = touch.position.x;
				yStart = touch.position.y;
			}
			if (touch.phase == TouchPhase.Moved) {
				xEnd = touch.position.x;
				yEnd = touch.position.y;
				
				if ((xStart - xEnd < -15) && sendCall && d=='R') {
					dir = true;
					sendCall = false;
				}
				if ((xStart - xEnd > 15) && sendCall && d=='L') {
					dir = true;
					sendCall = false;
				}
				if ((yStart - yEnd < -15) && sendCall && d=='U') {
					dir = true;
					sendCall = false;
				}
				if ((yStart - yEnd > 15) && sendCall && d=='D') {
					dir = true;
					sendCall = false;
				}
				
			}
			
			if (touch.phase == TouchPhase.Ended) {
				xStart = 0.0f;    // resetting start and end x position.
				xEnd = 0.0f;
				sendCall = true;      //Reset to send call again after touch has been completed.
				//couldBeSwipe = true;
			}


		}


		return dir;
	}




}
