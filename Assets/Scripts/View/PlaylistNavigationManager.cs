using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class PlaylistNavigationManager : Singleton<PlaylistNavigationManager> {

    float GRID_Y_OFFSET = 60;
    List<Game> playlist;
    int currentGameIndex = 0;
    public Text gameLabelPrefab;
    Coroutine<_> moveThroughList;
    GameObject titleGrid;

    void Start() {

        playlist = GameRepository.Instance.games;
        titleGrid = GameObject.Find("TitleGrid");

        CreateLabels();
    }

    void CreateLabels() {

        foreach (var game in playlist) {
            var label = Instantiate(gameLabelPrefab) as Text;
            label.text = game.name;
            label.transform.parent = titleGrid.transform;
            label.transform.localScale = new Vector3(1, 1, 1);      // Why?
        }
    }

    void Update() {

        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.I)) Move(-1);

        else if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.K)) Move(1);

        if (Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.X) || Input.GetKeyDown(KeyCode.N) || Input.GetKeyDown(KeyCode.M)) {
            // only able choose the game if we're not currently moving through the game list
            if (moveThroughList == null) {
                Runner.Instance.Run(playlist[currentGameIndex]);
            }
        }
    }

    void Move(int direction) { 
        if (moveThroughList == null && (currentGameIndex + direction >= 0) && (currentGameIndex + direction < playlist.Count)) {
            int nextGameIndex = Maths.Mod((currentGameIndex + direction), playlist.Count);
            //ScreenshotDisplayManager.Instance.LoadScreenshot(playlist[nextGameIndex].screenshot);

            var startY = titleGrid.transform.localPosition.y;
            //moveThroughList = StartCoroutine<_>(Coroutines.OverTime(ScreenshotDisplayManager.Instance.CROSSFADE_TIME, Funcs.Identity, t => {
            //    var lp = titleGrid.transform.localPosition;
            //    titleGrid.transform.localPosition = new Vector3(lp.x, Mathf.SmoothStep(startY, startY + direction * GRID_Y_OFFSET, t), lp.z);
            //    if (t == 1) {
            //        currentGameIndex = Maths.Mod(currentGameIndex + direction, playlist.Count);
            //        moveThroughList = null;
            //    }
            //}));
        }
    }
}