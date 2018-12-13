using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
//using UnityStandardAssets.CrossPlatformInput;

public class MenuManager : MonoBehaviour
{
    public static bool GameIsPaused = false;
    private bool nextlv = false;

    [SerializeField] GameObject pauseMenuUI;
    [SerializeField] GameObject loseMenuUI;
    [SerializeField] Slider healthBar;//pa borrar
    [SerializeField] GameObject nextLvUI;
    [SerializeField] Text stageNumber;
    [SerializeField] Text pointsAvalaibleNumber;
    [SerializeField] StatsBar[] statsBar; // order : resistence, damage, luck
    [SerializeField] StageManager stageManager;

    Instanciator inst;
    Player player;
    

    private void Start()
    {
        inst = FindObjectOfType<Instanciator>();
        player = FindObjectOfType<Player>();
        
    }

    public void FixedUpdate()
    {
        if (player != null) {
            healthBar.value = player.Life;
            pointsAvalaibleNumber.text = player.statsPoint.ToString();
            if (player.Life <= 0)
            {
                if (GameManager.score > GameManager.highscore)
                {
                    GameManager.Save("HighScore", GameManager.score);
                    GameManager.highscore = GameManager.score;
                }
                Lose();
            }
        }

        



        //NextLV();
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void Lose()
    {
        loseMenuUI.SetActive(true);
        Time.timeScale = 0f;
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void PlayGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(1);
        stageManager.ActualStage = 0;
        stageManager.Initiate();

        inst.isStageFinished = false;
        inst.gameObject.SetActive(true);
        

        loseMenuUI.SetActive(false);
        if (player != null) { player.Life = 100; }
        GameManager.score = 0;
    }

    public void QuitGame()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }

    public void NextLV()
    {
        nextLvUI.SetActive(true);
        stageNumber.text = (inst.actualStage+1).ToString();
        Time.timeScale = 0f;
        player.isPlaying = false;
    }

    public void LvNext()
    {
        nextLvUI.SetActive(false);
        player.AssignLife();
        player.isPlaying = true;

        inst.isStageFinished = false;
        inst.gameObject.SetActive(true);
        Time.timeScale = 1f;
        /*inst.wave = 0;
        inst.maxObj *= 2;
        inst.spawnCount = 0;*/


    }
    public void AddToResistence()
    {
        player.Resistence = 1;
        pointsAvalaibleNumber.text = player.statsPointAvailable.ToString();
        statsBar[0].SpriteNumber(player.Resistence);
    }
    public void RestToResistence()
    {
        player.Resistence = -1;
        pointsAvalaibleNumber.text = player.statsPointAvailable.ToString();
        statsBar[0].SpriteNumber(player.Resistence);
    }

    public void AddToDamage()
    {
        player.Damage = 1;
        pointsAvalaibleNumber.text = player.statsPointAvailable.ToString();
        statsBar[1].SpriteNumber(player.Damage);
    }
    public void RestToDamage()
    {
        player.Damage = -1;
        pointsAvalaibleNumber.text = player.statsPointAvailable.ToString();
        statsBar[1].SpriteNumber(player.Damage);
    }

    public void AddToLuck()
    {
        player.Luck = 1;
        pointsAvalaibleNumber.text = player.statsPointAvailable.ToString();
        statsBar[2].SpriteNumber(player.Luck);
    }
    public void RestToLuck()
    {
        player.Luck = -1;
        pointsAvalaibleNumber.text = player.statsPointAvailable.ToString();
        statsBar[2].SpriteNumber(player.Luck);
    }


}
