using UnityEngine;
using System.Collections;

[System.Serializable]
public class Song {

	public string name;
	public string author;
	public Sprite screenshot;
	public string executablePath;
	
	public Song(string name, string author, Sprite screenshot, string executablePath) {
		this.name = name;
		this.author = author;
		this.screenshot = screenshot;
		this.executablePath = executablePath;
	}
}
