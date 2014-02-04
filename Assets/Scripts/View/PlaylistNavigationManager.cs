using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlaylistNavigationManager : Singleton<PlaylistNavigationManager> {
	float GRID_Y_OFFSET = 60;
	List<Game> playlist;
	int currentGameIndex = 0;
	public GameObject gameLabelPrefab;
	Coroutine<_> moveThroughList;
	UIGrid titleGrid;
	
	void Start() {
		playlist = GameRepository.Instance.games;
		titleGrid = GetComponentInChildren<UIGrid>();
	}

	void CreateLabels() { 
		foreach (var game in playlist) {

		}
	}

	void Update() {
		if(Input.GetKeyDown(KeyCode.UpArrow)) Move(-1);
		else if(Input.GetKeyDown(KeyCode.DownArrow)) Move(1);
	}

	void Move(int direction) {
		if (moveThroughList == null) {
			int nextGameIndex = Maths.Mod((currentGameIndex + direction), playlist.Count);
			Debug.Log (nextGameIndex);
			ScreenshotDisplayManager.Instance.LoadScreenshot(playlist[nextGameIndex].screenshot);

			var startY = titleGrid.transform.localPosition.y;
			moveThroughList = StartCoroutine<_>(Coroutines.OverTime(ScreenshotDisplayManager.Instance.CROSSFADE_TIME, Funcs.Identity, t => { 
				var lp = titleGrid.transform.localPosition;
				titleGrid.transform.localPosition = new Vector3(lp.x, Mathf.SmoothStep(startY, startY + direction * GRID_Y_OFFSET, t), lp.z);
				if (t == 1) {
					currentGameIndex = Maths.Mod(currentGameIndex + direction, playlist.Count);
					moveThroughList = null;
				}
			}));
		}

	}
}