using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeCamera : MonoBehaviour {

    public bool isShaking = false;
    float timeShaking = .5f;
    float timePrevious = 0f;
    Vector3 cameraPosition;
	
	void Start () {
        cameraPosition = transform.position;	
	}
	
	// Update is called once per frame
	void Update () {
        if (isShaking == true)
        {
            Shake();
        }
    }

    void Shake() {

            transform.position = cameraPosition;
            if (timePrevious == 0) {
                timePrevious = Time.time;
            }
            if (Time.time > timePrevious + timeShaking)
            {
                isShaking = false;
                timePrevious = 0;
                transform.position = cameraPosition;
            }
            else
            {
                transform.position = new Vector3(transform.position.x+Random.Range(-.05f,.05f), transform.position.y+Random.Range(-.05f, .05f), transform.position.z);
            }

        

    }
}
