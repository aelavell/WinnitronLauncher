using UnityEngine;
using System.Collections;

public class Game {

	public string name;
	public string description;
	public Sprite sprite;
	public GameObject gameObject;
	
	public Game(string name, string description, GameObject myparent) {
		this.name = name;
		this.description = description;

		//rando sprite for now
		Sprite[] sprites = Resources.LoadAll<Sprite>("Images");
		sprite = sprites[Random.Range(0, sprites.Length)];

		Dbug.Log("Loading game sprite: " + sprite);

		gameObject = GameObject.Instantiate(Resources.Load("Prefabs/GameImage")) as GameObject;
		gameObject.transform.parent = myparent.transform.Find("GameScrollView/GameGrid");

		gameObject.GetComponent<UI2DSprite>().sprite2D = sprite;

		gameObject.transform.localScale = new Vector3(1, 1, 1);
	}

	public void CursorOver ()
	{

	}

	public void CursorAway()
	{

	}
}
