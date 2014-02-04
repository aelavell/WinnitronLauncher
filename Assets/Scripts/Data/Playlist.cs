using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Playlist {
	public List<Game> games;
	

	public void AddNewGame(string n, string d)
	{	
		games.Add(new Game(n, d, null));
	}
}
