using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using TMPro;

public class EndGameTrigger : MonoBehaviour
{
    public GameObject gameEndPanel; // Объявляем публичное поле для панели окончания игры

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Endgame();
        }
    }

    void Endgame()
    {
        // Активируем панель окончания игры
        gameEndPanel.SetActive(true);
        Time.timeScale = 0f;

        //UnityEditor.EditorApplication.isPlaying = false;    
    } 
}