using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GM : MonoBehaviour {

	public List<Playlist> playlists;

	public GameObject imageGrid;

	//Where in the array the game selection is
	public int playlistSelected = 0;

	// Use this for initialization
	void Start () 
	{
		CreateGameList();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetKeyDown(KeyCode.RightArrow)) MoveList(1);
		if(Input.GetKeyDown(KeyCode.LeftArrow)) MoveList(-1);
	}

	void CreateGameList() 
	{
		playlists = new List<Playlist>();

		AddPlaylist();

		playlists[0].AddNewGame("Nuclear Throne", "Vlambeer");
		playlists[0].AddNewGame("Nidhogg", "Mark Essen");
		playlists[0].AddNewGame("Super Crate Box", "Vlambeer");
		playlists[0].AddNewGame("Sumo Topplers", "Marlon Wiebe");

		RefreshGrid();

		MoveToPlaylist(0);
	}

	void AddPlaylist()
	{
		playlists.Add(new Playlist());
	}

	void MoveList(int dir)
	{
		playlistSelected += dir;

		if(playlists.Count > 0)
		{
			if(playlistSelected < 0) playlistSelected = playlists.Count - 1;
			if(playlistSelected > playlists.Count) playlistSelected = 0;
		}

		MoveToPlaylist(playlistSelected);
	}

	void RefreshGrid()
	{
		imageGrid.GetComponent<UIGrid>().Reposition();
		imageGrid.GetComponentInChildren<UIGrid>().Reposition();
	}

	void MoveToPlaylist(int lst)
	{

	}

	void CursorOver(int g)
	{

	}

	void CursorAway(int g)
	{

	}
}