using UnityEngine;
using System.Collections;

[System.Serializable]
public class Game {
	public string name;
	public string author;
	public Texture2D screenshot;
	public string executablePath;
	
	public Game(string name, string author, Texture2D screenshot, string executablePath) {
		this.name = name;
		this.author = author;
		this.screenshot = screenshot;
		this.executablePath = executablePath;
	}
}
