using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{
    public GameObject gameStartPanel;
    public GameObject pause;   
    
    public void Start()
    {
        GlobalState.Key = false;
        GlobalState.Coin = 0;
        GlobalState.Screen = true;
        GlobalState.DetectionLevelMax = 5f;
        GlobalState.baseHackTimeDoor = 6f;
        GlobalState.Panel = false;
        GlobalState.missingCoins = 0;

        if(GlobalState.Screen)
        {
            Time.timeScale = 0f;
            pause.SetActive(false);
        }
        else 
        {
            gameStartPanel.SetActive(false);
        }
        
    }
    public void PlayGame()
    {
        Time.timeScale = 1f;
        gameStartPanel.SetActive(false);
        pause.SetActive(true);
    } 

    public void ExitGame()
    {
        Debug.Log("Игра закрылась");
        //Application.Quit();
        UnityEditor.EditorApplication.isPlaying = false;
    }

}