using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GM : MonoBehaviour {

	public List<Playlist> playlists;

	public GameObject playlistScrollView;
	public GameObject playlistNameOverlay;

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

		AddPlaylist("Cool Games");

		playlists[0].AddNewGame("Nuclear Throne", "Vlambeer");
		playlists[0].AddNewGame("Nidhogg", "Mark Essen");
		playlists[0].AddNewGame("Super Crate Box", "Vlambeer");
		playlists[0].AddNewGame("Sumo Topplers", "Marlon Wiebe");

		AddPlaylist("Super Bros");
		
		playlists[1].AddNewGame("Nuclear Throne", "Vlambeer");
		playlists[1].AddNewGame("Nidhogg", "Mark Essen");
		playlists[1].AddNewGame("Super Crate Box", "Vlambeer");
		playlists[1].AddNewGame("Sumo Topplers", "Marlon Wiebe");

		AddPlaylist("Hans Yolo's Pix");
		
		playlists[2].AddNewGame("Nuclear Throne", "Vlambeer");
		playlists[2].AddNewGame("Nidhogg", "Mark Essen");
		playlists[2].AddNewGame("Super Crate Box", "Vlambeer");
		playlists[2].AddNewGame("Sumo Topplers", "Marlon Wiebe");
		playlists[2].AddNewGame("Nuclear Throne", "Vlambeer");
		playlists[2].AddNewGame("Nidhogg", "Mark Essen");
		playlists[2].AddNewGame("Super Crate Box", "Vlambeer");
		playlists[2].AddNewGame("Sumo Topplers", "Marlon Wiebe");

		AddPlaylist("bAd gaMez");
		
		playlists[3].AddNewGame("Nuclear Throne", "Vlambeer");

		RefreshGrid();

		ViewPlaylist(0);
	}

	void AddPlaylist(string listname)
	{
		playlists.Add(new Playlist(listname));
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

			playlistScrollView.GetComponent<UICenterOnChild>().CenterOn(playlists[viewingPlaylist].gameObject.transform);
			playlistNameOverlay.GetComponent<UICenterOnChild>().CenterOn(playlists[viewingPlaylist].playlistLabel.transform);
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
		playlistNameOverlay.GetComponentInChildren<UIGrid>().Reposition();
	}
	
	void CursorOver(int g)
	{

	}

	void CursorAway(int g)
	{

	}
}