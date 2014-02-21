using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ScreenshotDisplayManager : Singleton<ScreenshotDisplayManager> {
	public float CROSSFADE_TIME = 0.25f;
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

	void Update() {
		panel.Refresh();
	}

	public void LoadScreenshot(Texture2D screenshot) {
		if (crossfade == null) {
			var nextIndex = Maths.Mod((currentScreenIndex + 1), screens.Length);
			screens[nextIndex].mainTexture = screenshot;
			crossfade = StartCoroutine<_>(Coroutines.OverTime(CROSSFADE_TIME, Funcs.Identity, t => { 
				screens[currentScreenIndex].alpha = 1 -t; 
				screens[nextIndex].alpha = t;
				if (t == 1) {
					currentScreenIndex = Maths.Mod((currentScreenIndex + 1), screens.Length);
					crossfade = null;
				}
			}));
		}
	}
}
