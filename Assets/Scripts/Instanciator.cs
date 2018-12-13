using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instanciator : MonoBehaviour
{

    [SerializeField] GameObject[] objects;
    float timeToInstanciate = 2f;
    float lastInstance;
    float stageVelocity = 0f;
    public bool isStageFinished = true;
    public int actualStage = 0;

    public GameObject initialFase;

    public int type = 0;//     0 = red;      1 = blue;      2 = green;      3 = violet;     4 = orange;     5 = yellow


    public List<GameObject> enemiesToInstanciate;

    [Range(1, 50)]
    public int maxObj;
    public int spawnCount;

    int randObj = 0;
    int instEnemeyOrNot = 0; //le da variación a la instanciación

    public int wave;

    public int enemiesAlive;

    int LootChances = 50;
    public GameObject loot;

    [SerializeField] Player player;

    void Start()
    {
        lastInstance = Time.time;

    }


    void Update()
    {
        // si ya paso el tiempo establecido para instanciar (timeToInstanciate) ejecuta la funcion para instanciar el enemigo
        if (Time.time > lastInstance + timeToInstanciate)
        {
            if (isStageFinished == false)
            {
                instEnemeyOrNot = Random.Range(0, 35);
                if (instEnemeyOrNot == 0)//le da variación a la instanciación
                {
                    print(instEnemeyOrNot);
                    InstanciateEnemy();
                    lastInstance = Time.time;
                }

            }

        }


    }

    void InstanciateEnemy()
    {

        // random para ver si tira vida dependiendo de la suerte del player
        if (Random.Range(0, 100) < 5*player.Luck) {

            Instantiate(loot, new Vector3(transform.position.x + Random.Range(-3, 3), transform.position.y, -3), transform.rotation);
        }

        //instancia enemigo
        randObj = Random.Range(0, enemiesToInstanciate.Count);
        GameObject colorblock = Instantiate(enemiesToInstanciate[randObj], new Vector3(transform.position.x + Random.Range(-3, 3), transform.position.y, transform.position.z), transform.rotation) as GameObject;
        ColorBlock colorblockscript = colorblock.GetComponent<ColorBlock>();
        colorblockscript.type = enemiesToInstanciate[randObj].GetComponent<ColorBlock>().type;
        colorblockscript.velocity += stageVelocity;
        spawnCount++;
        enemiesAlive++;
        StartCoroutine(Wait());
        return;
        
    }

    public void StagePref(float stageVel, float dropRate) {

        timeToInstanciate = dropRate;
        stageVelocity = stageVel;
        isStageFinished = false;
    }

    IEnumerator Wait()
    {
        if(spawnCount >= maxObj)
        {
            //wave++;
            yield return new WaitForSeconds(7);
            spawnCount = 0;
        }

    }
}
	