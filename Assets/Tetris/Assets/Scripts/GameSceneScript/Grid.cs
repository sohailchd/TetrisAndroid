﻿using UnityEngine;
using System.Collections;

public class Grid : MonoBehaviour {


	public static int w = 10;
	public static int h = 20;
	public static Transform[,] grid = new Transform[w,h];

	public static int Gscore = 0;


	public static Vector2 roundVec2(Vector2 v)
	{
		return new Vector2( Mathf.Round(v.x ), Mathf.Round(v.y));
	}

	public static bool insideBorder(Vector2 v)
	{
		return ( v.x >= 0 &&
		         v.x < w &&
		         v.y >= 0
			    );
	}

	public static void deleteRow(int y)
	{
		for(int i=0;i<w;i++)
		{
			Destroy(grid[i,y].gameObject);
			grid[i,y] =  null;
		}
	}


	public static void decreaseRow(int y)
	{
		for(int x=0;x<w;++x)
		{
			if(grid[x,y]!=null)
			{
				grid[x,y-1] = grid[x,y];
				grid[x,y]   = null;

				grid[x,y-1].position += new Vector3(0,-1,0);
			}
		}
	}


	public static void decreaseRowsAbove(int y)
	{
		for(int i = y ; i<h ; ++i)
		{
			decreaseRow(i);
		}
	}

	public static bool isRowFull(int y)
	{
		for(int i=0; i<w;i++)
		{
			if(grid[i,y] == null)
			{
				return false;
			}
		}
		Gscore += 10;
		return true;
	}



	public static void deleteFullRows()
	{
		for (int y = 0; y < h; ++y) {
			if (isRowFull(y)) {
				deleteRow(y);
				decreaseRowsAbove(y+1);
				--y;
			}
		}
	}




}
