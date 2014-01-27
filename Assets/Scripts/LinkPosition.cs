using UnityEngine;
using System.Collections;

public class LinkPosition : MonoBehaviour {

	public Transform target;

	public bool linkX = false;
	public bool linkY = false;
	public bool linkZ = false;

	public float offsetX = 0;
	public float offsetY = 0;
	public float offsetZ = 0;

	// Update is called once per frame
	void Update () {
		float x = transform.position.x;
		float y = transform.position.y;
		float z = transform.position.z;

		if(linkX) x = target.transform.position.x + offsetX;
		if(linkY) y = target.transform.position.y + offsetY;
		if(linkZ) z = target.transform.position.z + offsetZ;

		transform.position = new Vector3(x, y, z);
	}
}
