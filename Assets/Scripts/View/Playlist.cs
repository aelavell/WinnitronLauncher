using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

public class Playlist : MonoBehaviour {

    public List<Game> gamesList;
    public string gamesDirectory;

    public PlaylistNavigationManager playlistNavMan { get; set; }		
    public float tweenTime;

    public float fadeOutAlpha;
    
    public GameObject gameNavigationManagerPrefab;


    GoTween currentTween;
    

    public Vector3 positionProp {
        get { return transform.position; }
        set { transform.position = value; }
    }
    public Vector3 scaleProp {
        get { return transform.localScale; }
        set { transform.localScale = value; }
    }
    public float alphaProp { get; set; }

    // Builds a list of Game objects based on the game directory inside its main directory. Then instantiates the GameNavigationManager, which then instantiates the ScreenShotDisplayManager
    public void buildList() {
        
        var gamesDir = new DirectoryInfo(gamesDirectory);
        
        foreach (var dir in gamesDir.GetDirectories()) {

            gamesList.Add(CreateRepresentation(dir));
        }

        GameObject gameNavMan = Instantiate(gameNavigationManagerPrefab) as GameObject;
        gameNavMan.transform.position = transform.position;
        gameNavMan.transform.parent = transform;        
    }

    Game CreateRepresentation(DirectoryInfo gameDirectory) {
        
        var directoryName = gameDirectory.Name;
        var name = directoryName.Replace('_', ' ');
        
        string author = null;

        // Load the screenshot from the games directory as a Texture2D
        var screenshot = new Texture2D(1024, 768);
        screenshot.LoadImage(File.ReadAllBytes(Path.Combine(gameDirectory.FullName, gameDirectory.Name + ".png")));

        // Turn the Texture2D into a sprite
        var screenshotSprite = Sprite.Create(screenshot, new Rect(0, 0, screenshot.width, screenshot.height), new Vector2(0.5f, 0.5f));

        var executablePath = Path.Combine(gameDirectory.FullName, gameDirectory.Name + ".exe");

        return new Game(name, author, screenshotSprite, executablePath);
    }

    public void move(Vector3 pos, Vector3 scale) {

        if (playlistNavMan.moving) {

            currentTween.destroy();
        }

        currentTween = Go.to(this, tweenTime, new GoTweenConfig()
            .vector3Prop("positionProp", pos)
            .vector3Prop("scaleProp", scale)
            .floatProp("alphaProp", fadeOutAlpha)
            .setEaseType(GoEaseType.ExpoOut));

        currentTween.setOnCompleteHandler(c => { onMoveComplete(); });
    }

    public void onMoveComplete() {

        playlistNavMan.moving = false;
    }
}
