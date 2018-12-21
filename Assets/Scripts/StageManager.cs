using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour {

    [SerializeField] int actualStage = 0;
    [SerializeField] float timeToEndStage;
    [SerializeField] float tiempo;
    [SerializeField] int stageFase = 0;
    GameObject initialStage;

    [SerializeField] StageList[] stagelist;
    [SerializeField] Instanciator inst;
    [SerializeField] MenuManager menumanager;
    [SerializeField] Floor floor;
    bool gameOver = false;

    int stageCant = 3;
    float[] stageTimeToComplete = new float[] { 15, 15, 15 };
    float[] stageVelocity = new float[] { 0, 1, 2 };
    float[] stageDropRate = new float[] { 2, 1.5f, 1 };


    void Start () {
        stagelist[0] = Resources.Load<StageList>("Databases/Stage_1_a");
        stagelist[1] = Resources.Load<StageList>("Databases/Stage_1_b");
        stagelist[2] = Resources.Load<StageList>("Databases/Stage_1_c");

    }
	
	
	void Update () {
        tiempo = Time.time; // esta solo para ver como transcurre el tiempo en el inspector

        // si no hay initial fase (tutorial) pasa directamente a instanciar enemigos
        if (stageFase == 0 && stagelist[actualStage].initialFase == null)
        {
            stageFase = 1;
            Initiate();

        }
        else if(stageFase == 0 && initialStage == null) {
            // instanciar gameobject del tutorial
            initialStage = Instantiate(stagelist[actualStage].initialFase);

        }
         

        else if (stageFase == 1) {

            //si termino el tiempo del stage
            if (timeToEndStage < Time.time)
            {

                //si no es el ultimo stage, avanza al siguiente
                if (stageCant > actualStage + 1)
                {
                    print("se termino el stage");
                    //carga los datos del stage en el instanciator
                    actualStage++;
                    inst.actualStage = actualStage;
                    inst.isStageFinished = true; // le dice al instanciator que termino el stage anterior
                    /*floor.Velocity = stagelist[actualStage].stageVelocity; //carga las propiedades del nuevo stage
                    timeToEndStage = stagelist[actualStage].timeToComplete + Time.time;

                    inst.enemiesToInstanciate.Clear(); //limpia la lista de enemigos del stage anterior y carga la del stage nuevo
                    for (int i = 0; i < stagelist[actualStage].enemiesToInstanciate.Length; i++)
                    {
                        GameObject e = stagelist[actualStage].enemiesToInstanciate[i];
                        inst.enemiesToInstanciate.Add(e);
                    }

                    inst.StagePref(stagelist[actualStage].stageVelocity, stagelist[actualStage].dropRate);
                    inst.gameObject.SetActive(false);
                    */
                    inst.gameObject.SetActive(false);
                    floor.Velocity = 0;
                    menumanager.NextLV();
                    stageFase = 0; // vuelve a la fase 0 para cargar el tutorial del nuevo stage si hay
                }
                //si es el ultimo stage le dice al menumanager que abra el menu de lose
                else if (stageCant <= actualStage + 1) { menumanager.Lose(); }
            }
        }



    }

    public int ActualStage
    {
        get { return actualStage; }
        set
        {
                actualStage = value;
        }
    }
    public int StageFase
    {
        get { return stageFase; }
        set
        {
            stageFase = value;
        }
    }

    public void Initiate() { //se inicializa en MenuManager.cs
        if (stageCant > 0)
        {
            inst.gameObject.SetActive(true);
            //carga los datos del stage en el instanciator
            timeToEndStage = stagelist[actualStage].timeToComplete + Time.time;

            inst.enemiesToInstanciate.Clear();
            //carga enemigos del scripteable object
            for (int i = 0; i < stagelist[actualStage].enemiesToInstanciate.Length; i++)
            {
                GameObject e = stagelist[actualStage].enemiesToInstanciate[i];
                inst.enemiesToInstanciate.Add(e);
            }

            floor.Velocity = stagelist[actualStage].stageVelocity;
            inst.StagePref(stagelist[actualStage].stageVelocity, stagelist[actualStage].dropRate);
            inst.isStageFinished = false;
            //stageFase = 1;
        }
    }
}
