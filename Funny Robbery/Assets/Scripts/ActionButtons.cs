using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class action : MonoBehaviour
{
    public GameObject gamePausePanel;
    public TMP_Text ButtonName;

    public void LoadGame()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
        GlobalState.Screen = true;
    }

    public void RestartLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
        Time.timeScale = 1f;
        GlobalState.Screen = false;
    }

    public void PauseLevel()
    {
        if (Time.timeScale == 0f)
        {
            Time.timeScale = 1f; // Возобновление игры
            ButtonName.text = "PAUSE";
            gamePausePanel.SetActive(false);

        }
        else
        {
            Time.timeScale = 0f; // Пауза игры
            ButtonName.text = "PLAY";
            gamePausePanel.SetActive(true);
        }
    }
}
