using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkMage : MonoBehaviour
{

    public int life = 1;
    public float speed = 2f;
    public float timer = 2f;

    public bool shooting = false;

    public Animator darkMage;
    public Transform target;

    public GameObject bullet;

    public float fireRate = 0.5f;
    float nextFire = 1f;

    void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        if (Mathf.Floor(transform.position.z) > 2f)
        {
            Shoot();
            speed = 0;
            timer -= Time.deltaTime;
            shooting = true;
        }
        if (timer <= 0){
            speed = -2f;
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
            shooting = false;
            darkMage.SetBool("Attack", false);  
        }
    }

    void Shoot()
    {
        if(Time.time > nextFire && shooting == true)
        {
            nextFire = Time.time + fireRate;
            Instantiate(bullet, transform.position, transform.rotation);
            darkMage.SetBool("Attack", true);
        }
    }
}