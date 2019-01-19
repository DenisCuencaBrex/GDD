using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shielder : MonoBehaviour {

    public int shield = 0; // 0 = no escudo -- 1 = escudo
    public float timer = 2;

    Bullet bullet;
    public float velocity = 2f;

    public int type = 0;//     0 = red;      1 = blue;      2 = green;      3 = violet;     4 = orange;     5 = yellow

    enum EnemyType { BasicRed, BasicBlue, BasicGreen, BasicViolet, BasicOrange, BasicYellow };

    [SerializeField]
    EnemyType enemyType = 0;

    bool dead = false;

    public bool isFirst = false;

    public int life = 1;

    [SerializeField] Player player;

    public Animator death;
    [SerializeField] Animator heart;
    [SerializeField] Animator circle;

    public GameObject destroy;

    [SerializeField] GameObject wallDamage;
    ShakeCamera shakeCamera;

    Collider[] hitColliders;

    Instanciator inst;

    void Start()
    {
        bullet = FindObjectOfType<Bullet>();
        inst = FindObjectOfType<Instanciator>();

        //shakeCamera = GetComponent<ShakeCamera>();
        shakeCamera = FindObjectOfType<ShakeCamera>();

        player = FindObjectOfType<Player>();
        if (heart != null)
        {
            heart.SetInteger("life", -1);
        }
    }


    void Update()
    {

        timer -= Time.deltaTime;
        ShieldUp();

        transform.Translate(Vector3.forward * velocity * Time.deltaTime);

        if (heart != null && isFirst == true)
        {
            heart.SetInteger("life", life);
        }

        CheckCollision();


    }

    private void CheckCollision()
    {
        hitColliders = Physics.OverlapSphere(transform.position, 0.1f);
        Collider firstBulletCol;

        Collider bestBullet = null;

        foreach (Collider col in hitColliders)
        {

            if (col.name == "Wall")
            {
                inst.enemiesAlive--;
                wallDamage.SetActive(true);
                player.Life -= 10;
                if (player.Life > 0) { shakeCamera.isShaking = true; }
                Destroy(gameObject);
            }

            else if (col.tag == "RedBullet" || col.tag == "BlueBullet" || col.tag == "GreenBullet"
                || col.tag == "OrangeBullet" || col.tag == "VioletBullet" || col.tag == "YellowBullet")
            {

                if (bestBullet == null)
                {
                    bestBullet = col;
                }
                if (col.GetComponent<Bullet>().index < bestBullet.GetComponent<Bullet>().index)
                {
                    bestBullet = col;
                }

            }

        }
        if (bestBullet != null && dead == false)
        {
            if (bestBullet.tag == "RedBullet")   // si la bala es roja y el tipo de enemigo tambien destruye al enemigo y a la bala. Si la bala es roja pero el enemigo no, destruye la bala
            {
                if (type == 0 && shield == 0)
                {
                    if (life > 1) { transform.localScale -= new Vector3(.1f, .1f, 0); }
                    life -= bestBullet.gameObject.GetComponent<Bullet>().Damage;
                    Destroy(bestBullet.gameObject);
                    //life--;
                }
                else if (type == 1) { life++; Destroy(bestBullet.gameObject); transform.localScale += new Vector3(.1f, .1f, 0); }
                else { Destroy(bestBullet.gameObject); if (velocity > 0) { velocity += 1f; } }


            }

            else if (bestBullet.tag == "BlueBullet")
            {
                if (type == 1 && shield == 0)
                {
                    if (life > 1) { transform.localScale -= new Vector3(.1f, .1f, 0); }
                    life -= bestBullet.gameObject.GetComponent<Bullet>().Damage;
                    Destroy(bestBullet.gameObject);
                    //life--;
                }
                else if (type == 2) { life++; Destroy(bestBullet.gameObject); transform.localScale += new Vector3(.1f, .1f, 0); }
                else
                {
                    Destroy(bestBullet.gameObject);

                    if (velocity > 0) { velocity += 1f; }
                }

            }
            else if (bestBullet.tag == "GreenBullet")
            {
                if (type == 2 && shield == 0)
                {
                    if (life > 1) { transform.localScale -= new Vector3(.1f, .1f, 0); }
                    life -= bestBullet.gameObject.GetComponent<Bullet>().Damage;
                    Destroy(bestBullet.gameObject);
                    //life--;
                }
                else if (type == 0) { life++; Destroy(bestBullet.gameObject); transform.localScale += new Vector3(.1f, .1f, 0); }
                else { Destroy(bestBullet.gameObject); if (velocity > 0) { velocity += 1f; } }


            }
            else if (bestBullet.tag == "VioletBullet")
            {
                if (type == 3 && shield == 0)
                {
                    if (life > 1) { transform.localScale -= new Vector3(.1f, .1f, 0); }
                    life -= bestBullet.gameObject.GetComponent<Bullet>().Damage;
                    Destroy(bestBullet.gameObject);
                    //life--;
                }
                else if (type == 4) { life++; Destroy(bestBullet.gameObject); transform.localScale += new Vector3(.1f, .1f, 0); }
                else { Destroy(bestBullet.gameObject); if (velocity > 0) { velocity += 1f; } }


            }
            else if (bestBullet.tag == "OrangeBullet")
            {
                if (type == 4 && shield == 0)
                {
                    if (life > 1) { transform.localScale -= new Vector3(.1f, .1f, 0); }
                    life -= bestBullet.gameObject.GetComponent<Bullet>().Damage;
                    Destroy(bestBullet.gameObject);
                    //life--;
                }
                else if (type == 5) { life++; Destroy(bestBullet.gameObject); transform.localScale += new Vector3(.1f, .1f, 0); }
                else { Destroy(bestBullet.gameObject); if (velocity > 0) { velocity += 1f; } }

            }
            else if (bestBullet.tag == "YellowBullet" && shield == 0)
            {
                if (type == 5 && shield == 0)
                {
                    if (life > 1) { transform.localScale -= new Vector3(.1f, .1f, 0); }
                    life -= bestBullet.gameObject.GetComponent<Bullet>().Damage;
                    Destroy(bestBullet.gameObject);
                    //life--;
                }
                else if (type == 3) { life++; Destroy(bestBullet.gameObject); transform.localScale += new Vector3(.1f, .1f, 0); }
                else { Destroy(bestBullet.gameObject); if (velocity > 0) { velocity += 1f; } }

            }
        }

        if (life <= 0 && dead != true )
        {
            dead = true; player.Experience = 10f;
            player.combo++; player.comboTimer = Time.time + player.comboDuration * Time.deltaTime;
        }


        if (dead == true)
        {


            velocity = 0f;
            if (death != null) { death.SetBool("Death", true); }

            Collider collider = GetComponent<Collider>();
            if (collider != null)
            {
                collider.enabled = false;
            }

            StartCoroutine(Destroy());
        }

    }

    public void IsFirst()
    {
        if (circle != null) { circle.SetBool("isFirst", true); }
        isFirst = true;
    }

    IEnumerator Destroy()
    {

        if (player != null)
        {

            gameObject.tag = "Untagged";

            player.GetEnemyList();
            //player.GetClosestEnemy(player.enemiesList);
        }
        yield return new WaitForSeconds(0.6f);
        GameManager.score += 10;
        Destroy(gameObject);
        inst.enemiesAlive--;
    }

    void ShieldUp()
    {
        if (shield == 0 && timer <= 0)
        {
            shield = 1;
            timer = 3;
        }

        else if(shield == 1 && timer <= 0)
        {
                shield = 0;
                timer = 3;                 
        }  
     }


}

