using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StateManager : MonoBehaviour {

	public List<GameObject> gameObjectsToToggleActivation;
	public List<Canvas> canvasesToToggleActivation;

	//On Activate
	public List<Animation> animationsToPlayOnStart;

	//On deactivate
	public List<Animation> animationsToRewind;

	public void Deactivate() {
		foreach(GameObject gameObject in gameObjectsToToggleActivation) gameObject.SetActive(false);
		foreach(Canvas canvas in canvasesToToggleActivation) canvas.enabled = false;
		foreach(Animation anim in animationsToRewind) {
			anim.Stop();
			anim.Rewind();
			Debug.Log ("rewinding: " + anim.name);
		}
	}

	public void Activate() {
		foreach(Animation anim in animationsToPlayOnStart) anim.Play();
		foreach(Canvas canvas in canvasesToToggleActivation) canvas.enabled = true;
		foreach(GameObject gameObject in gameObjectsToToggleActivation) gameObject.SetActive(true);
	}
}
