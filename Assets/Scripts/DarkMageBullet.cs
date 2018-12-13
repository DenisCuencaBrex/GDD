using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkMageBullet : MonoBehaviour {

    public Transform target;
    public float speed = 10f;
    public float damage = 10f;

    Player player;

    private void Start()
    {
        player = FindObjectOfType<Player>();
    }

    private void Update()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target.position, step);
    }


    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player"){
            player.Life -= damage;
            print("asfgasfa");
            Destroy(gameObject);
        }
    }
}
