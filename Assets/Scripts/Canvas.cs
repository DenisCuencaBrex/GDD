using UnityEngine;
using UnityEngine.UI;

public class Canvas : MonoBehaviour {

    public Text textLife;
    public Text textScore;
    public Text textHighScore;
    public float startHealths = 10f;
    public float maxHeartAmmount = 10f;
    [SerializeField] Text textLvl;

    [SerializeField] Text textCombo;

    [SerializeField] Image xpBar;

    [SerializeField] Image[] hearts;
    [SerializeField] Sprite fullHeart;
    [SerializeField] Sprite halfHeart;
    [SerializeField] Sprite emptyHeart;
    private int[] fiveNums;
    public int numOfHearts;
    public int health;

    //[SerializeField] Image hpBar;
    [SerializeField] LvlsList lvlList;
    float xp = 0.0f;
    float xpBarSize;
    float hpBarSize;

    [SerializeField] Player player;
    

	void Start () {
        player = FindObjectOfType<Player>();
	}
	

	void Update () {

        int playerlife = (int)player.Life;
        health = playerlife;


        if (textCombo != null)
        {
            textCombo.text = player.combo.ToString();
        }

        //calcula el tamaño de la barra de XP tomando como escala 1 cuando esta completa y 0 vacia
        if (xpBar != null)
        {
            xpBarSize = (player.Experience * 1) / lvlList.lvls[player.GetLvl() - 1];

            xpBar.rectTransform.localScale = new Vector3(xpBarSize, xpBar.rectTransform.localScale.y, xpBar.rectTransform.localScale.z);
            textLvl.text = player.GetLvl().ToString();
        }

        if(health < numOfHearts)
        {
            playerlife = numOfHearts;
        }
       
        

        for (int i = 0; i < hearts.Length; i++) {
            if (i < health)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }


            if (i < numOfHearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }

        }

        /*if (hearts != null)
        {
            hpBarSize = (player.Life * 1) / player.MaxLife;

            hearts[1].rectTransform.localScale = new Vector3(hpBarSize, hearts.rectTransform.localScale.y, hearts.rectTransform.localScale.z);
            //textLvl.text = player.GetLvl().ToString();
        }*/

//        textLife.text = player.Life.ToString();
		textScore.text = GameManager.score.ToString();
        textHighScore.text = GameManager.highscore.ToString();

	}


  
}
