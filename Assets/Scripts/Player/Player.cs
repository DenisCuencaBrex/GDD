using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour {

    #region Init variables

    [Header("Player Settings")]

    [SerializeField] float life = 10;
    [SerializeField] float maxLife = 10;
    [SerializeField] float experience = 0f;
    float xpModifier = 2.5f;
    [SerializeField] int lvl = 1;
    //LvlsList lvllist; //lista de cuanto es la experiencia requerida para cada lvl
    int[] lvllist = new int[] { 100, 250, 500, 1000, 1500 };
    public bool isPlaying = true;


    public float fireRate = 0.5f;
    public float nextFire = 1f;

    public float combo = 0f;
    public float comboTimer = 0f;
    public float comboDuration = 75f;
    public Animator atack;


    [Header("Player Stats")]

    public int statsPoint = 0;//los puntos disponibles para asignar cuando termina el stage
    public int statsPointAvailable = 0;
    public Vector3 assignedStats = new Vector3(0f, 0f, 0f); // para saber al final de nivel que puntos se agregaron a que. Resistence, Damage, luck
    public int resistence = 0;
    public int damage = 0;
    public int luck = 0;


    [Header("Bullets")]

    [SerializeField] GameObject redBullet;
    [SerializeField] GameObject blueBullet;
    [SerializeField] GameObject greenBullet;
    [SerializeField] GameObject orangeBullet;
    [SerializeField] GameObject yellowBullet;
    [SerializeField] GameObject violetBullet;

    public GameObject[] enemiesList;

    [SerializeField] ColorMix colorMix;
    [SerializeField] Renderer light;

    GameObject bullet;
    GameObject bulletColor;
    GameObject[] bullets;
    int bulletIndex = 0;

    [SerializeField] AudioSource aSource;
    [SerializeField] AudioClip redAudio;
    [SerializeField] AudioClip greenAudio;
    [SerializeField] AudioClip blueAudio;


    public bool alreadyPlayed = false;

    //[HideInInspector] public GameObject firstBullet = null;


    

    GameObject targetBest = null;

    #endregion



    void Start()
    {
        aSource = GetComponent<AudioSource>();

        enemiesList = GameObject.FindGameObjectsWithTag("Enemy");
        if (enemiesList != null) { GetClosestEnemy(enemiesList); }
        //lvllist = Resources.Load<LvlsList>("Databases/LvlsList");
    }


    void Update()
    {
        if (isPlaying)
        {

            if (comboTimer < Time.time) { combo = 0; }


            /*if (firstBullet != null) { }
            else { print("buscar primer bullet"); }*/
            Shoot();


            if (atack.GetBool("attack") == false)
            {
                light.gameObject.SetActive(true);

                if (colorMix.GetButtonColorOver() == "Red")
                {

                    light.material.SetColor("_TintColor", Color.red);
                }
                else if (colorMix.GetButtonColorOver() == "Blue")
                {

                    light.material.SetColor("_TintColor", Color.blue);
                }
                else if (colorMix.GetButtonColorOver() == "Green")
                {

                    light.material.SetColor("_TintColor", Color.green);
                }
                else if (colorMix.GetButtonColorOver() == "Violet")
                {

                    light.material.SetColor("_TintColor", Color.magenta);
                }
                else if (colorMix.GetButtonColorOver() == "Yellow")
                {

                    light.material.SetColor("_TintColor", Color.yellow);
                }
                else if (colorMix.GetButtonColorOver() == "Orange")
                {

                    Color orange = new Color32(255, 60, 0, 255);
                    light.material.SetColor("_TintColor", orange);
                }
                else
                {
                    light.material.SetColor("_TintColor", Color.white);
                    light.gameObject.SetActive(false);
                }
            }
            else
            {

                light.gameObject.SetActive(false);

            }
        }
    }

    void OnTriggerStay(Collider other)
    {


        if (other.tag == "Red")
        {
            GameManager.score += 10;
            print(GameManager.score);
            print("it's red");
            Destroy(other.gameObject);
        }
        if (other.tag == "Blue")
        {
            GameManager.score += 10;
            print(GameManager.score);
            print("it's blue");
            Destroy(other.gameObject);
        }
        if (other.tag == "Green")
        {
            GameManager.score += 10;
            print(GameManager.score);
            print("it's green");
            Destroy(other.gameObject);
        }

    }

    void Shoot()
    {
        //enemiesList = GameObject.FindGameObjectsWithTag("Enemy");
        GetEnemyList();
        if (enemiesList.Length > 0 && targetBest != null) //solo dispara si hay enemigos
        {
            bool buttonReleased = false;


            if (CrossPlatformInputManager.GetButtonUp("Fire1") && Time.time > nextFire)
            {
                bulletColor = redBullet;
                buttonReleased = true;

                aSource.PlayOneShot(redAudio);
            }


            if (CrossPlatformInputManager.GetButtonUp("Fire2") && Time.time > nextFire)
            {
                bulletColor = blueBullet;
                buttonReleased = true;

               aSource.PlayOneShot(blueAudio);
            }


            if (CrossPlatformInputManager.GetButtonUp("Fire3") && Time.time > nextFire)
            {
                bulletColor = greenBullet;
                buttonReleased = true;

                aSource.PlayOneShot(greenAudio);
            }


            // fire4 violeta, fire5 naranja, fire6 amarillo

            if (CrossPlatformInputManager.GetButtonUp("Fire4") && Time.time > nextFire)
            {
                bulletColor = violetBullet;
                buttonReleased = true;

            }

            if (CrossPlatformInputManager.GetButtonUp("Fire5") && Time.time > nextFire)
            {
                bulletColor = orangeBullet;
                buttonReleased = true;

            }

            if (CrossPlatformInputManager.GetButtonUp("Fire6") && Time.time > nextFire)
            {
                bulletColor = yellowBullet;
                buttonReleased = true;


            }
            if (buttonReleased == true)
            {
                nextFire = Time.time + fireRate;
                bullet = Instantiate(bulletColor, transform.position + new Vector3(0, -.39f, 0), transform.rotation) as GameObject;
                Bullet bulletScript = bullet.GetComponent<Bullet>();

                bulletScript.target = GetClosestEnemy(enemiesList);
                bulletScript.index = bulletIndex++;
                bulletScript.Damage = damage + 1;

                atack.SetBool("attack", true);

            }

        }
    }

    void AttackAnim(bool var)
    {
        if (var == true) {
            atack.SetBool("attack", true);
        }
        else if (var == false)
        {
            atack.SetBool("attack", false);
        }
    }

    public void GetEnemyList() {
        enemiesList = GameObject.FindGameObjectsWithTag("Enemy");
        if (enemiesList.Length > 0)
        {
            GetClosestEnemy(enemiesList);
        }


    }

    //devuelve el enemigo mas cercano al personaje tomando en cuenta el eje z
    public Transform GetClosestEnemy(GameObject[] enemiesList)
    {

        Transform bestTarget = GameObject.Find("InstanciationPos").transform; // esto es solo una referencia del eje z del instanciador

        foreach (GameObject potentialTarget in enemiesList) //busca en la lista de enemigos
        {

            if (bestTarget.position.z < potentialTarget.transform.position.z)
            {
                bestTarget = potentialTarget.transform;

            }

        }
        if (bestTarget.gameObject.name != "InstanciationPos")
        {
            bestTarget.gameObject.GetComponent<ColorBlock>().IsFirst();

            targetBest = bestTarget.gameObject;


        }

        return bestTarget;

    }

    public int GetLvl()
    {

        return lvl;
    }

    public void AssignLife()
    {
        maxLife += resistence * 10;
        life = MaxLife;
    }

    //Properties
    public float Experience
    {
        get { return experience; }
        set
        {
            if (value < 0)
                experience = 0;

            if (lvllist != null)
            {

                if (experience + value >= lvllist[lvl - 1])
                {
                    experience = (experience + value)+ (combo*xpModifier) - lvllist[lvl - 1];

                    lvl++;
                    statsPoint += 2;
                    statsPointAvailable = statsPoint;
                }
                else
                {
                    experience += value + (combo * xpModifier);


                }

            }
        }
    }

    public float Life
    {
        get { return life; }
        set
        {
            if (value < 0)
                life = 0;
            else
                life = value;

            if (life > maxLife) { life = maxLife; }
        }
    }

    public float MaxLife
    {
        get { return maxLife; }
        set
        {
            if (value < 10)
                maxLife = 10;
            else
                maxLife = value;
        }
    }

    public int Resistence
    {
        get { return resistence; }
        set
        {
            if ((value>0 && statsPointAvailable>0) || (value<0 && statsPointAvailable < statsPoint && assignedStats.x > 0))
            {
                statsPointAvailable -= value;
                assignedStats.x += value;
                resistence += value;
                //maxLife += resistence * 10;
                //life = MaxLife;
            }
        }
    }

    public int Damage
    {
        get { return damage; }
        set
        {
            if ((value > 0 && statsPointAvailable > 0) || (value < 0 && statsPointAvailable < statsPoint && assignedStats.y > 0))
            {
                statsPointAvailable -= value;
                assignedStats.y += value;
                damage += value;
            }
        }
    }

    public int Luck
    {
        get { return luck; }
        set
        {
            if ((value > 0 && statsPointAvailable > 0) || (value < 0 && statsPointAvailable < statsPoint && assignedStats.z > 0))
            {
                statsPointAvailable -= value;
                assignedStats.z += value;
                luck += value;
            }

        }
    }


}

