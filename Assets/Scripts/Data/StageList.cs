
using UnityEngine;
using System.Collections;

[CreateAssetMenu(fileName = "Data", menuName = "Data/StageList", order = 1)]
public class StageList : ScriptableObject
{

    public int setting = 0; // 0 forest ; 1 desert ; 2 swamp ; 3 mountain ; 4 cave ;

    public GameObject initialFase;

    public float stageVelocity = 1f; // afecta la velocidad de todo lo que se instancia en el stage
    public float dropRate = 1f;
    //public int wavesCant = 1; //cantidad de waves del stage
    public Vector2 waveEnemiesCant = new Vector2(10,15); //cantidad de enemigos de la wave (el primer valor es el min y el otro el max)
    public GameObject[] enemiesToInstanciate;
    public GameObject[] obstaclesToInstanciate;
    public float instanciatorVelocity;
    public float timeToComplete;

    public GameObject finalFase;
}
