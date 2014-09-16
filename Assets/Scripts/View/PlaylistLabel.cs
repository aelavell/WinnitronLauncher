using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlaylistLabel : MonoBehaviour {
         

    GoTween currentTween;

    public PlaylistNavigationManager playlistNavigationManager { get; set; }   


    public void move(Vector3 pos, Vector3 scale, float tweenTime) {

        if (playlistNavigationManager.moving) {

            currentTween.destroy();
        }

        currentTween = Go.to(transform, tweenTime, new GoTweenConfig()
            .position(pos)            
            .scale(scale)            
            .setEaseType(GoEaseType.ExpoOut));


        currentTween.setOnCompleteHandler(c => { onMoveComplete(); });
    }

    public void onMoveComplete() {

        playlistNavigationManager.moving = false;
    }

	public void setAlpha(float newAlpha) {
		GetComponent<Text>().color = new Color(1, 1, 1, newAlpha);
	}

    public void initializeName(string name) {

        foreach (Text text in GetComponentsInChildren<Text>()) {

            text.text = name;
        }

    }
}
