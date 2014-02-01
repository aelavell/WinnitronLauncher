using UnityEngine;
using System.Collections;

public class Game {

	public string name;
	public string description;
	public Sprite sprite;
	public GameObject gameImgObj;
	
	public Game(string name, string description, GameObject myparent) {
		this.name = name;
		this.description = description;
		this.sprite = sprite;

		gameImgObj = GameObject.Instantiate(Resources.Load("GameImage")) as GameObject;
		gameImgObj.transform.parent = myparent.transform;

		gameImgObj.transform.localScale = new Vector3(1, 1, 1);
	}

	public void CursorOver ()
	{

	}

	public void CursorAway()
	{

	}
}
