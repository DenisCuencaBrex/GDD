using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public Transform target;
    public float speed= 10f;
    Player player;

    bool isFirstbullet = false;

    public int index;
    public int damage;

    void Start () {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
	}


    void Update()
    {
        /*if (player.firstBullet != null) { 
        if (player.firstBullet == gameObject)
        {*/


            if (target == null) // la bala no tiene objetivo asignado
            {
                target = player.GetClosestEnemy(player.enemiesList); // busca nuevo enemigo en base a la lista del player

                if ((target == null) || (target.gameObject.name == "Instanciator")) // si no hay ningun enemigo en la lista se destruye
                {
                    Destroy(gameObject);
                }
            }
            else // si ya tiene objetivo se mueve hacia el enemigo
            {
                float step = speed * Time.deltaTime;
                transform.position = Vector3.MoveTowards(transform.position, target.position, step);
            }
            /*
        }
    
        else if (player.firstBullet != null)
        {
            target = player.firstBullet.transform;
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target.position, step);

        }

        }*/

    }

    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }

    public int Damage
    {
        get { return damage; }
        set
        {
            if (value < 0) 
{ 
                damage = 0;
            }
            else
            {
                damage = value;
            }
                
        }
    }

}
