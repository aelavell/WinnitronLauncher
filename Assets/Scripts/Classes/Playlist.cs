using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Playlist {

	public List<Game> games;
	public GameObject gameObject;
	private Transform gameScrollView;

	public int viewingGame = 0;

	public Playlist()
	{
		games = new List<Game>();

		gameObject = GameObject.Instantiate(Resources.Load("Prefabs/Playlist")) as GameObject;
		gameObject.transform.parent = GameObject.Find("PlaylistGrid").transform;

		gameScrollView = gameObject.transform.Find("GameScrollView");
		Dbug.Log("Found game grid for playlist: " + gameScrollView);
	}

	public void AddNewGame(string n, string d)
	{	
		games.Add(new Game(n, d, gameObject));
	}

	public void ViewGame(int gameNum)
	{
		if(games.Count > 1)
		{
			if(gameNum < 0) viewingGame = games.Count - 1;
			else if(gameNum > games.Count - 1) viewingGame = 0;
			else viewingGame = gameNum;

			Dbug.Log("Calling ViewGame, trying to view game " + viewingGame);
			gameScrollView.GetComponent<UICenterOnChild>().CenterOn(games[viewingGame].gameObject.transform);
		}
	}

	public void MoveUp()
	{
		ViewGame(viewingGame - 1);
	}

	public void MoveDown()
	{
		ViewGame(viewingGame + 1);
	}

	public void CursorOver()
	{

	}

	public void CursorAway()
	{

	}
}
