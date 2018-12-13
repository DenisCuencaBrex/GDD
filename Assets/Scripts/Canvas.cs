using UnityEngine;
using UnityEngine.UI;

public class Canvas : MonoBehaviour {

    public Text textLife;
    public Text textScore;
    public Text textHighScore;
    [SerializeField] Text textLvl;

    [SerializeField] Text textCombo;

    [SerializeField] Image xpBar;
    [SerializeField] Image hpBar;
    [SerializeField] LvlsList lvlList;
    float xp = 0.0f;
    float xpBarSize;
    float hpBarSize;

    [SerializeField] Player player;
    

	void Start () {
        
	}
	

	void Update () {
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

        if (hpBar != null)
        {
            hpBarSize = (player.Life * 1) / player.MaxLife;

            hpBar.rectTransform.localScale = new Vector3(hpBarSize, hpBar.rectTransform.localScale.y, hpBar.rectTransform.localScale.z);
            //textLvl.text = player.GetLvl().ToString();
        }

        textLife.text = player.Life.ToString();
		textScore.text = GameManager.score.ToString();
        textHighScore.text = GameManager.highscore.ToString();
	}
}
