using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour {

    [SerializeField] private float velocity = 0f;
    private float offset = 0f;
    private Renderer renderer;
    private float stop = 3f;

	void Start () {
        renderer = GetComponent<Renderer>();
	}
	

	void Update () {
        if (stop < 2) { 
            if (velocity > 0 && Time.timeScale > 0)
            {
                offset += velocity;
                renderer.material.SetTextureOffset("_MainTex", new Vector2 (0,offset));
            }
            
        }

        if (stop <= 0) { stop = 3f; }
        else { stop -= 0.1f; }

    }

    public float Velocity
    {
        get { return velocity; }
        set
        {
            if (value < 0)
                velocity = 0;
            else
                velocity = value;
        }
    }
}
