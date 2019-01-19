using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Splitter : MonoBehaviour {

    ColorBlock colorBlock;

    public GameObject smallSpliter;

    public float distance = 4f;
    public int maxCount = 2;

    private int spawnCount = 0;


	void Start () {
        colorBlock = FindObjectOfType<ColorBlock>();
	}
	
	void Update () {
        if (colorBlock.life == 0 && spawnCount < maxCount)
        {

            StartCoroutine(SpawnTimer());
        }


	}
    IEnumerator SpawnTimer()
    {
        yield return new WaitForSeconds(0.5f);
        Instantiate(smallSpliter, transform.position + (transform.right * distance), transform.rotation);
        spawnCount++;
        Instantiate(smallSpliter, transform.position + (-transform.right * distance), transform.rotation);
        spawnCount++;
    }
}
