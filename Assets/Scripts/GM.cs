using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GM : MonoBehaviour {

	public List<Game> games;

	public GameObject gameImage;
	public GameObject gameImageLocator;
	public UIGrid gameImageGrid;
	public UIPanel gameScrollView;
	public UIGrid gameScrollViewGrid;
	public GameObject gameTitle;
	
	private GameObject[] temp;

	public Sprite[] sprites;

	//Where in the array the game selection is
	public int position = 0;

	// Use this for initialization
	void Start () 
	{
		CreateGameList();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetKeyDown(KeyCode.DownArrow)) ListMove(1);
		if(Input.GetKeyDown(KeyCode.UpArrow)) ListMove(-1);
	}

	void CreateGameList() 
	{
		games = new List<Game>();
		
		games.Add(AddNewGame("Nuclear Throne", "Vlambeer"));
		games.Add(AddNewGame("Nidhogg", "Mark Essen"));
		games.Add(AddNewGame("Super Crate Box", "Vlambeer"));
		games.Add(AddNewGame("Sumo Topplers", "Marlon Wiebe"));

		gameScrollViewGrid.Reposition();
		gameImageGrid.Reposition();

		ListMoveToPosition (0);
	}

	Game AddNewGame(string n, string d) 
	{
		GameObject listname = Instantiate(gameTitle, gameScrollViewGrid.transform.position, gameScrollViewGrid.transform.rotation) as GameObject;
		listname.transform.parent = gameScrollViewGrid.transform;
		listname.GetComponent<UILabel>().text = n;

		GameObject img = Instantiate(gameImage, gameImageGrid.transform.position, gameImageGrid.transform.rotation) as GameObject;
		img.transform.parent = gameImageGrid.transform;

		return new Game(n, d, listname);
	}

	void ListMove(int dir)
	{
		Deselect(position);

		position += dir;

		if (position < 0) position = games.Count - 1;
		else if (position > games.Count - 1) position = 0;

		ListMoveToPosition (position);
	}

	void ListMoveToPosition(int pos)
	{
		gameScrollViewGrid.GetComponent<UICenterOnChild>().CenterOn(games[pos].label.transform);
		Select(pos);
	}

	void Select(int g)
	{
		games[g].label.GetComponent<GameLabel>().Select();
	}

	void Deselect(int g)
	{
		games[g].label.GetComponent<GameLabel>().Deselect();
	}
}