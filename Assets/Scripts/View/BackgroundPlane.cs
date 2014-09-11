using UnityEngine;//
using System.Collections;

public class BackgroundPlane : MonoBehaviour {
    
    public GameObject currentPlane;
    public  GameObject otherPlane;

    public float tweenTime;


    Vector3 startPos;                       // Position to move the plane too when its out of view

    public float speed = 5;

    bool tweening;

    void Start() {
        
        startPos = currentPlane.transform.position;        
    }

	void Update () {

        // Create a new plane when the current one has gone far enough
        if (otherPlane.transform.localPosition.z > 600) {

            otherPlane.transform.position = startPos;

            var temp = otherPlane;
            otherPlane = currentPlane;
            currentPlane = temp;
        }

        currentPlane.rigidbody.velocity = Vector3.forward * speed;
        otherPlane.rigidbody.velocity = Vector3.forward * speed;


        if ((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow))) {

            animation.Stop();
            animation.Play();
        }        
	}     
}
