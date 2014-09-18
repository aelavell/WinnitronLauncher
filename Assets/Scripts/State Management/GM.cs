using UnityEngine;
using System.Collections;

public class GM : Singleton<GM> {

	public enum WorldState{Intro, Launcher, Attract, Idle};

	public WorldState worldState = WorldState.Intro;
	private WorldState prevWorldState = WorldState.Launcher;

	public StateManager intro;
	public StateManager launcher;
	//public GameObject attract;

	//Ideally these wouldn't be called every frame, probably not optimized
	void Update () {

		if(worldState != prevWorldState)
		{
			switch(worldState)
			{
				case WorldState.Intro:
					intro.Activate();
					launcher.Deactivate();
					Debug.Log ("INTROOOOO");
				break;

				case WorldState.Launcher:
					intro.Deactivate();
					launcher.Activate();
					Debug.Log ("LAUNCHERRRR");
				break;
			}
		}

		prevWorldState = worldState;
	}
}
