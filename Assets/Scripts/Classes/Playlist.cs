using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Playlist {

	public string name;

	public List<Game> games;
	public GameObject gameObject;
	private Transform gameScrollView;
	public GameObject playlistLabel;

	public int viewingGame = 0;

	public Playlist(string listname)
	{
		name = listname;

		games = new List<Game>();

		gameObject = GameObject.Instantiate(Resources.Load("Prefabs/Playlist")) as GameObject;
		gameObject.transform.parent = GameObject.Find("PlaylistGrid").transform;

		gameScrollView = gameObject.transform.Find("GameScrollView");

		//Make the playlist label that will appear at top of screen
		playlistLabel = GameObject.Instantiate(Resources.Load("Prefabs/PlaylistLabel")) as GameObject;
		playlistLabel.transform.parent = GameObject.Find("PlaylistNamesGrid").transform;
		playlistLabel.transform.localScale = new Vector3(1.174516f, 1.174516f, 1.174516f);
		playlistLabel.GetComponent<UILabel>().text = name;
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
