using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameLabel : MonoBehaviour {

    public GameNavigationManager gameNavMan { get; set; }    
    public float tweenTime;

	public bool selected = false;

	public string name;

	public float scale = 2;

	public float alpha = 1;

    GoTween currentTween;

	void Update() 
	{
		if(selected) 
		{
			transform.localScale = new Vector3(1, 1, scale);
		} else {
			transform.localScale = new Vector3(1, 1, 0.01f);
		}
	}

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
		/*
		GetComponent<Text>().color = new Color(1, 1, 1, newAlpha);

		alpha = newAlpha;
		
		Text[] children = gameObject.GetComponentsInChildren<Text>();
		foreach(Text child in children)
		{
			child.color = new Color(1, 1, 1, newAlpha);
		} 
		 */
	}

	//Renames all child labels
	public void renameLabel(string newName) {
		name = newName;

		Text[] children = gameObject.GetComponentsInChildren<Text>();
		foreach(Text child in children)
		{
			child.text = newName;
		}
	}
}
