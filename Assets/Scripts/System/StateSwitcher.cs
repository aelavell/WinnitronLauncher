using UnityEngine;
using System.Collections;

public class StateSwitcher : MonoBehaviour {

	public GM gm;

	public bool switchToIntro = false;
	public bool switchToLauncher = false;

	// Use this for initialization
	void Start () {
		gm = GameObject.Find ("GM").GetComponent<GM>() as GM;
	}
	
	void Update() {
		if(switchToIntro) gm.worldState = GM.WorldState.Intro;
		if(switchToLauncher) gm.worldState = GM.WorldState.Launcher;

		switchToIntro = false;
		switchToLauncher = false;
	}
}
