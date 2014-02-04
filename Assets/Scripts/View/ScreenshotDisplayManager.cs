using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ScreenshotDisplayManager : MonoBehaviour {
	float CROSSFADE_TIME = 0.5f;
	UITexture[] screens;
	UIPanel panel;
	int currentScreenIndex = 0;
	Coroutine<_> crossfade;

	void Start() {
		panel = transform.parent.GetComponent<UIPanel>();
		screens = GetComponentsInChildren<UITexture>();
		foreach (var screen in screens) {
			screen.alpha = 0;
		}

		screens[0].alpha = 1;
		screens[0].mainTexture = GameRepository.Instance.games[0].screenshot;
	}

	float time = 0;
	bool loaded = false;
	void Update() {
		if (time > 1 && !loaded) {
			LoadScreenshot(GameRepository.Instance.games[1].screenshot);
			loaded = true;
		}
		time += Time.deltaTime;
		panel.Refresh();
	}

	public void LoadScreenshot(Texture2D screenshot) {
		if (crossfade == null) {
			screens[currentScreenIndex + 1].mainTexture = screenshot;
			crossfade = StartCoroutine<_>(Coroutines.OverTime(CROSSFADE_TIME, Funcs.Identity, t => { 
				screens[currentScreenIndex].alpha = 1 -t; 
				screens[currentScreenIndex + 1].alpha = t;
				if (t == 1) {
					currentScreenIndex = (currentScreenIndex + 1) % screens.Length;
					crossfade = null;
				}
			}));
		}
	}
}
