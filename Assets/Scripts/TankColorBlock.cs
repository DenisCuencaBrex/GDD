using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankColorBlock : MonoBehaviour {

    float speed = 1f;
    int damage = 2;
    int health = 3;

    public int type = 0; //     0 = red     1 = blue    2 = green
    Player player;

    private void Update()
    {
        player = FindObjectOfType<Player>();

        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "Wall")
        {
            player.Life =-damage;
            Destroy(gameObject);
        }

        if (other.tag == "RedBullet")   // si la bala es roja y el tipo de enemigo tambien destruye al enemigo y a la bala. Si la bala es roja pero el enemigo no, destruye la bala
        {
            if (type == 0)
            {
                GameManager.score += 10;
                Destroy(other.gameObject);
                Destroy(gameObject);
            }
            else { Destroy(other.gameObject); }

        }

        else if (other.tag == "BlueBullet")
        {
            if (type == 1)
            {
                GameManager.score += 10;
                Destroy(other.gameObject);
                Destroy(gameObject);
            }
            else { Destroy(other.gameObject); }
        }
        else if (other.tag == "GreenBullet")
        {
            if (type == 2)
            {
                GameManager.score += 10;
                Destroy(other.gameObject);
                Destroy(gameObject);
            }
            else { Destroy(other.gameObject); }

        }

        //Aumento de danio o de vida
        if (other.tag == "BlueBullet" || other.tag == "GreenBullet")
        {
            if (type == 0)
            {
                health += 1;
                damage += 1;
            }
        }

        if (other.tag == "RedBullet" || other.tag == "GreenBullet")
        {
            if (type == 1)
            {
                health += 1;
                damage += 1;
            }
        }

        if (other.tag == "RedBullet" || other.tag == "BlueBullet")
        {
            health += 1;
            damage += 1;
        }
    }
}
