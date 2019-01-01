using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shielder : MonoBehaviour {

    public int life = 1;
    public int shield = 0; // 0 = no escudo -- 1 = escudo
    public float speed = 1f;
    public float timer = 2;

    bool shieldDown = true;

    bool dead = false;

    public void Start()
    {
        FindObjectOfType<Bullet>();
    }

    public void FixedUpdate()
    {
        timer -= Time.deltaTime;
        ShieldUp();
    }

    void ShieldUp(){
        if (shield == 0 && timer <= 0)
        {
            shieldDown = false;
            shield = 1;
            timer = 2;
        }

        else if(shield == 1 && timer <= 0)
        {
                shieldDown = true;
                shield = 0;
                timer = 2;                 
        }  
                    }

}
