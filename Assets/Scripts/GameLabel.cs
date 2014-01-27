using UnityEngine;
using System.Collections;

public class GameLabel : MonoBehaviour {

	public Vector2 origSize;
	public float selectedSize = 1;

	void Awake() {
		origSize = transform.localScale;
	}

	public void Select() {
		TweenScale tween = TweenScale.Begin (this.gameObject, 0.2f, transform.localScale * selectedSize) ;
		tween.method = UITweener.Method.EaseOut;
	}

	public void Deselect() {
		TweenScale tween = TweenScale.Begin (this.gameObject, 0.2f, origSize);
		tween.method = UITweener.Method.EaseOut;
	}
}
