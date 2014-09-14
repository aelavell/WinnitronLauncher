using UnityEngine;
using System.Collections;

public class TextPulse : MonoBehaviour {

	public float zStart = 0;
	public float zEnd = 1;

	public float speed = 1;

	Vector3 vStart;
	Vector3 vEnd;

	// Use this for initialization
	void Start () {
		vStart = new Vector3(transform.localScale.x, transform.localScale.y, zStart);
		vEnd = new Vector3(transform.localScale.x, transform.localScale.y, zEnd);
	}
	
	// Update is called once per frame
	void Update () {
		//transform.localScale = Auto.Wave(1f, Vector3(1f, 1f, 0f), Vector3(1f, 1f, 1f));
		transform.localScale = Auto.Wave(speed, vStart, vEnd);
	}
}
