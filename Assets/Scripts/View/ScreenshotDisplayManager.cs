using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ScreenshotDisplayManager : Singleton<ScreenshotDisplayManager> {

    public float CROSSFADE_TIME = 0.25f;
    Image[] screens;
    //UIPanel panel;
    int currentScreenIndex = 0;
    Coroutine<_> crossfade;

    void Start() {

        //panel = transform.parent.GetComponent<UIPanel>();
        screens = GetComponentsInChildren<Image>();
        
        foreach (var screen in screens) {
            
            //screen.color = new Color(1, 1, 1, 0);     
        }

        //screens[0].color = new Color(screens[0].color.r, screens[0].color.g, screens[0].color.b, 1);             
        screens[0].sprite = GameRepository.Instance.games[0].screenshot;
    }

    //void Update() {
    //    panel.Refresh();
    //}

    //public void LoadScreenshot(Texture2D screenshot) {
    //    if (crossfade == null) {
    //        var nextIndex = Maths.Mod((currentScreenIndex + 1), screens.Length);
    //        screens[nextIndex].mainTexture = screenshot;
    //        crossfade = StartCoroutine<_>(Coroutines.OverTime(CROSSFADE_TIME, Funcs.Identity, t => {
    //            screens[currentScreenIndex].alpha = 1 - t;
    //            screens[nextIndex].alpha = t;
    //            if (t == 1) {
    //                currentScreenIndex = Maths.Mod((currentScreenIndex + 1), screens.Length);
    //                crossfade = null;
    //            }
    //        }));
    //    }
    //}
}
