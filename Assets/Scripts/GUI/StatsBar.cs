using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class StatsBar : MonoBehaviour {

    //SpriteRenderer rendererStat;
    Image image;
    
    [SerializeField] Sprite[] statBarSprite;

	void Start () {
        //rendererStat = GetComponent<SpriteRenderer>();
        image = GetComponent<Image>();
	}
	
	void Update () {
		
	}

    public void SpriteNumber(int spriteIndex) {

        image.sprite = statBarSprite[spriteIndex];
        //rendererStat.sprite = statBarSprite[spriteIndex];
    }
}
