using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameLabel : MonoBehaviour {

    GoTween currentTween;
    Text text;

    public PlaylistNavigationManager playlistNavMan { get; set; }

	public Vector2 origSize;
	public float selectedSize = 1;

    public float tweenTime;
    
    // Properties for the tween to manipulate, regular GoKit position tween cannot be accessed with the GameLabel object so a custom property is necessary
    public int fontSize {
        get { return text.fontSize; }
        set { text.fontSize = value; }
    }    
    public Vector3 positionProperty{
        get { return transform.position; }
        set { transform.position = value; }
    }
    

	void Awake() {
		origSize = transform.localScale;

        text = GetComponent<Text>();
        //fontSize = text.fontSize;           // Try doing this with a direct reference to the text object
	}

    void Update() {

        //print(fontSize + "   " + text.fontSize);
    }

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

	public void Select() {
        //TweenScale tween = TweenScale.Begin (this.gameObject, 0.2f, transform.localScale * selectedSize) ;
        //tween.method = UITweener.Method.EaseOut;
	}

	public void Deselect() {
        //TweenScale tween = TweenScale.Begin (this.gameObject, 0.2f, origSize);
        //tween.method = UITweener.Method.EaseOut;
	}

    public void onMoveComplete() {

        playlistNavMan.moving = false;
    }
}
