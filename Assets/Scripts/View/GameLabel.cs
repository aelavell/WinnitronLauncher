using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameLabel : MonoBehaviour {

    public PlaylistNavigationManager playlistNavMan { get; set; }    
    public float tweenTime;

    GoTween currentTween;


    public void move(Vector3 pos, Vector3 scale) {

        if (playlistNavMan.moving) {

            currentTween.destroy();
        }

        currentTween = Go.to(transform, tweenTime, new GoTweenConfig()
            .position(pos)            
            .scale(scale)            
            .setEaseType(GoEaseType.ExpoOut));


        currentTween.setOnCompleteHandler(c => { onMoveComplete(); });
    }

    public void onMoveComplete() {

        playlistNavMan.moving = false;
    }
}
