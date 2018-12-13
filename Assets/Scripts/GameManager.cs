using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager instance = null;
    public static int score = 0;
    public static int highscore = 0;

    //public static int life = 100;

    void Awake()
    {

        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }


    void Start() {
        highscore = PlayerPrefs.GetInt("HighScore");
    }

    public static void Save(string data, int number) {
        PlayerPrefs.SetInt(data,number);
    }

}