using UnityEngine;
using System.Collections;

public class DestoryOnStart : MonoBehaviour {

	// Use this for initialization
	void Awake () {
		Destroy(gameObject);
	}
}
