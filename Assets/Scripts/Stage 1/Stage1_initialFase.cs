using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage1_initialFase : MonoBehaviour {

    [SerializeField] StageManager stageManager;

    Player player;

    float timer = 0;
    float timerLimit = 2;

	void Start () {
        stageManager = FindObjectOfType<StageManager>();
        player = FindObjectOfType<Player>();
	}
	
	
	void Update () {
        timer += 1 * Time.deltaTime;

        if (timer > timerLimit)
        {
            if (player.enemiesList.Length <= 0) {
            stageManager.StageFase = 1;
            stageManager.Initiate();
            Destroy(gameObject);
            }
        }


    }
}
