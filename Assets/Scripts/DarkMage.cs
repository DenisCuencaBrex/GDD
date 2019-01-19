using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkMage : MonoBehaviour
{
      public MageStages stage;
    public float initialLife = 10f;
    public float actuaLife; 
    public float speed = 2f;
    float percentage;

    public bool shooting = false;

    public Animator darkMage;
    public Transform target;
    public Transform pos;
    public Transform spawnPos;

    public GameObject bullet;

    public List<GameObject> spawnObject;

    public float fireRate = 0.5f;
    float nextFire = 1f;

    public float timer;
    public float maxTimer = 5f;

    public float timeLastSpawn;
    public float delaySpawn;

    Player player;


    public int type = 0;//     0 = red;      1 = blue;      2 = green;      3 = violet;     4 = orange;     5 = yellow

    enum EnemyType { BasicRed, BasicBlue, BasicGreen, BasicViolet, BasicOrange, BasicYellow };

    [SerializeField]
    EnemyType enemyType = 0;

    bool dead = false;

    public bool isFirst = false;

    //public Animator death;
    //[SerializeField] Animator heart;
    [SerializeField] Animator circle;

    //public GameObject destroy;

    //[SerializeField] GameObject wallDamage;
    //ShakeCamera shakeCamera;

    Collider[] hitColliders;

    // Instanciator inst;

    public enum MageStages
    {
        phase1,
        phase2,
    }

    public void Start()
    {
        timer = maxTimer;
        actuaLife = initialLife;
        player = FindObjectOfType<Player>();
    }



    public void Update()
    {
        LifePercentage();
        Phases();
        CheckCollision();
    }


    private void CheckCollision()
    {
        hitColliders = Physics.OverlapSphere(transform.position, 0.1f);
        Collider firstBulletCol;

        Collider bestBullet = null;

        foreach (Collider col in hitColliders)
        {
        

            if (col.tag == "RedBullet" || col.tag == "BlueBullet" || col.tag == "GreenBullet"
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
                if (type == 0)
                {
                    actuaLife -= bestBullet.gameObject.GetComponent<Bullet>().Damage;
                    Destroy(bestBullet.gameObject);
                    //life--;
                }


            }
         


        }



    }

    public void IsFirst()
    {
        if (circle != null) { circle.SetBool("isFirst", true); }
        isFirst = true;
    }




    void LifePercentage(){
        percentage = (actuaLife * 10) / initialLife;

        if(percentage <= 10 && percentage >= 8){
            stage = MageStages.phase1;
        }
        else if (percentage <= 8 && percentage >= 6){
            stage = MageStages.phase2;
           // timer -= Time.deltaTime;
        }
      /*  if(timer <= 0){
            stage = MageStages.phase1;
        }*/
        if (percentage <= 6 && percentage >= 4)
        {
            stage = MageStages.phase1;
            //timer -= Time.deltaTime;
        }
       // if(timer <= 0)
        //{
          //  stage = MageStages.phase1;
        //}
        if(percentage <= 4 && percentage >= 1)
        {
            stage = MageStages.phase2;
        }

        if(percentage <= 0)
        {
            Destroy(gameObject);
        }

    }

    private void Phases(){
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
                    GameObject instantiateObject = Instantiate(spawnObject[selection], new Vector3(spawnPos.position.x + Random.Range(-3, 3), spawnPos.position.y, spawnPos.position.z), spawnPos.rotation) as GameObject;
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