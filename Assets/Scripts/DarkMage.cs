using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkMage : MonoBehaviour
{
    public MageStages stage;
    public float initialLife = 100f;
    public float actuaLife; 
    public float speed = 2f;
    float percentage;

    public bool shooting = false;

    public Animator darkMage;
    public Transform target;
    public Transform pos;

    public GameObject bullet;

    public List<GameObject> spawnObject;

    public float fireRate = 0.5f;
    float nextFire = 1f;

    public float timer = 10f;

    public float timeLastSpawn;
    public float delaySpawn;

    public enum MageStages
    {
        phase1,
        phase2,
        phase3,
    }

    public void Start()
    {
        actuaLife = initialLife;
    }

    public void Update()
    {
        LifePercentage();
        Phases();
    }

    void LifePercentage(){
        percentage = (actuaLife * 100) / initialLife;

        if(percentage <= 100 && percentage >= 80){
            stage = MageStages.phase1;
        }
        else if (percentage <= 80 && percentage >= 60){
            stage = MageStages.phase2;
            timer -= Time.deltaTime;
        }
        if(timer <= 0){
            stage = MageStages.phase1;
        }
    }

    void Phases(){
        switch (stage)
        {
            case MageStages.phase1:
                print("stage 1");
                transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
                if (Mathf.Floor(transform.position.z) > 2f)
                {
                    shooting = true;
                    Shoot();
                    speed = 0;
                }
                break;

            case MageStages.phase2:
                print("stage 2");
                shooting = false;
                darkMage.SetBool("Attack", false);
                speed = 2f;
                transform.position = Vector3.MoveTowards(transform.position, pos.position, speed * Time.deltaTime);
                if(Time.time - timeLastSpawn >= delaySpawn){
                    int selection = Random.Range(0, spawnObject.Count);
                    GameObject instantiateObject = Instantiate(spawnObject[selection], pos.position, Quaternion.identity) as GameObject;
                    timeLastSpawn = Time.time;
                }
                break;
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