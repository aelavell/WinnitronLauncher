using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameLabel : MonoBehaviour {

    public GameNavigationManager gameNavMan { get; set; }    
    public float tweenTime;

	public float alpha = 1;

    GoTween currentTween;


    public void move(Vector3 pos, Vector3 scale) {

        if (gameNavMan.moving) {

            currentTween.destroy();
        }

        currentTween = Go.to(transform, tweenTime, new GoTweenConfig()
            .position(pos)            
            .scale(scale)            
            .setEaseType(GoEaseType.ExpoOut));


        currentTween.setOnCompleteHandler(c => { onMoveComplete(); });
    }

    public void onMoveComplete() {

        gameNavMan.moving = false;
    }

	public void setAlpha(float newAlpha) {
		GetComponent<Text>().color = new Color(1, 1, 1, newAlpha);
	}
}
