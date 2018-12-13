using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour {

    [SerializeField] Player player;

	
	void Start () {
        player = GameObject.Find("Player").GetComponent<Player>();
	}
	
	
	void Update () {
		
	}

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0)) {
            player.Life += 10;
            Destroy(gameObject);
        }
    }
}
