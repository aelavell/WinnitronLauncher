using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GM : MonoBehaviour {

	public List<Playlist> playlists;

	public GameObject playlistScrollView;

	//Where in the array the game selection is
	public int viewingPlaylist = 0;

	// Use this for initialization
	void Start () 
	{
		Dbug.On();
		
		CreateGameList();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetKeyDown(KeyCode.RightArrow)) MovePlaylistRight();
		if(Input.GetKeyDown(KeyCode.LeftArrow)) MovePlaylistLeft();
		if(Input.GetKeyDown(KeyCode.DownArrow)) MoveGameDown();
		if(Input.GetKeyDown(KeyCode.UpArrow)) MoveGameUp();
	}

	void CreateGameList() 
	{
		playlists = new List<Playlist>();

		AddPlaylist();

		playlists[0].AddNewGame("Nuclear Throne", "Vlambeer");
		playlists[0].AddNewGame("Nidhogg", "Mark Essen");
		playlists[0].AddNewGame("Super Crate Box", "Vlambeer");
		playlists[0].AddNewGame("Sumo Topplers", "Marlon Wiebe");

		AddPlaylist();
		
		playlists[1].AddNewGame("Nuclear Throne", "Vlambeer");
		playlists[1].AddNewGame("Nidhogg", "Mark Essen");
		playlists[1].AddNewGame("Super Crate Box", "Vlambeer");
		playlists[1].AddNewGame("Sumo Topplers", "Marlon Wiebe");

		RefreshGrid();

		ViewPlaylist(0);
	}

	void AddPlaylist()
	{
		playlists.Add(new Playlist());
	}

	void MovePlaylistRight()
	{
		ViewPlaylist(viewingPlaylist + 1);
	}

	void MovePlaylistLeft()
	{
		ViewPlaylist(viewingPlaylist - 1);
	}

	void ViewPlaylist(int lst)
	{
		if(playlists.Count > 1)
		{
			if(lst < 0) viewingPlaylist = playlists.Count - 1;
			else if(lst > playlists.Count - 1) viewingPlaylist = 0;
			else viewingPlaylist = lst;
			
			Dbug.Log("Calling ViewPlaylist, trying to view game " + viewingPlaylist);
			playlistScrollView.GetComponent<UICenterOnChild>().CenterOn(playlists[viewingPlaylist].gameObject.transform);
		}
	}

	void MoveGameUp()
	{
		playlists[viewingPlaylist].MoveUp();
	}

	void MoveGameDown()
	{
		playlists[viewingPlaylist].MoveDown();
	}

	void RefreshGrid()
	{
		playlistScrollView.GetComponentInChildren<UIGrid>().Reposition();
	}
	
	void CursorOver(int g)
	{

	}

	void CursorAway(int g)
	{

	}
}