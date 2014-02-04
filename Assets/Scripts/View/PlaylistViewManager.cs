using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlaylistViewManager : MonoBehaviour {
	UICenterOnChild view;
	List<Game> playlist;
	int currentGameIndex = 0;
	
	void Start() {
		view = GetComponent<UICenterOnChild>();


		MoveToGame(0);
	}

	void PopulatePlaylist() {
		playlist = new List<Game>();
		playlist.Add(new Game("Nuclear Throne", "Vlambeer", null));
		playlist.Add(new Game("Spacerace", "Thinkrad", null));
	}

	void MoveToGame(int gameNum) {
		if(playlist.Count > 1) {
			currentGameIndex = gameNum % playlist.Count;
			//view.CenterOn(playlist[currentGameIndex].gameObject.transform);
		}
	}
	
	void MoveUp() {
		MoveToGame(currentGameIndex - 1);
	}
	
	void MoveDown() {
		MoveToGame(currentGameIndex + 1);
	}

	void Update() {
		if(Input.GetKeyDown(KeyCode.DownArrow)) MoveDown();
		if(Input.GetKeyDown(KeyCode.UpArrow)) MoveUp();
	}
	
	//gameObject.GetComponent<UI2DSprite>().sprite2D = sprite;
	// for NGUI's auto-scaling
	//gameObject.transform.localScale = new Vector3(1, 1, 1);
}