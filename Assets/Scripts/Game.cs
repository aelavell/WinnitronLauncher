using UnityEngine;
using System.Collections;

public class Game {

	public string name;
	public string description;
	public Sprite sprite;
	public GameObject label;
	
	public Game(string name, string description, GameObject label) {
		this.name = name;
		this.description = description;
		this.sprite = sprite;
		this.label = label;
	}

}
