using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingScreenControl : MonoBehaviour {

    public GameObject loadingScreenObj;
    public GameObject loseMenuUI;
    public GameObject menuCanvas;
    public Slider slider;
    public Text progressText;

    Player player;

    public void Start()
    {
        player = FindObjectOfType<Player>();
    }

    public void PlayGame()
    {
        Time.timeScale = 1f;
        StartCoroutine(LoadingScreen());
        loseMenuUI.SetActive(false);
        player.Life=100;
        GameManager.score = 0;
    }


    IEnumerator LoadingScreen()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(1);

        loadingScreenObj.SetActive(true);
        menuCanvas.SetActive(false);
        float progress = Mathf.Clamp01(operation.progress / .9f);

        while (!operation.isDone)
        {
            progress = Mathf.Clamp01(operation.progress / .9f);
            Debug.Log(progress);

            slider.value = progress;
            progressText.text = progress * 100f + "%";
            if (operation.progress == .9f)
            {
                slider.value = 1f;
                operation.allowSceneActivation = true;
            }
            yield return null;
        }
    }
}
