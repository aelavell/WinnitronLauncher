using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Playlist {

	public List<Game> games;
	public GameObject playlistObj;

	public Playlist()
	{
		games = new List<Game>();

		playlistObj = GameObject.Instantiate(Resources.Load("Playlist")) as GameObject;
		playlistObj.transform.parent = GameObject.Find("ImageGrid").transform;
	}

	public void AddNewGame(string n, string d)
	{	
		games.Add(new Game(n, d, playlistObj));
	}

	public void CursorOver()
	{

	}

	public void CursorAway()
	{

	}
}
