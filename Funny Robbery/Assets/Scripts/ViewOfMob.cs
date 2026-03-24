using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyDetectionSlider : MonoBehaviour
{
    public Slider detectionSlider; // Ссылка на слайдер обнаружения
    public float maxDetectionLevel; // Максимальный уровень обнаружения
    private float currentDetectionLevel = 0f; // Текущий уровень обнаружения
    public bool inZone = false;
    public GameObject gameEndPanel;
    RaycastHit hit;

    void Start()
    {
        maxDetectionLevel = GlobalState.DetectionLevelMax;
        detectionSlider.gameObject.SetActive(false);
        detectionSlider.maxValue = maxDetectionLevel;
    }

    void Update()
    {
        reset();
        Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit);
        if (hit.collider.CompareTag("Player"))
        {
            inZone = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && inZone)
        {
            detectionSlider.gameObject.SetActive(true);
            //detectionSlider.gameObject.SetActive(true);
            currentDetectionLevel += Time.deltaTime;
            // Ограничение уровня обнаружения до максимального значения
            currentDetectionLevel = Mathf.Clamp(currentDetectionLevel, 0f, maxDetectionLevel);
            
            detectionSlider.value = currentDetectionLevel;
            if (currentDetectionLevel == maxDetectionLevel)
            {
                EndGame(); // Завершаем игру, когда время истекло
            } 
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            inZone = false;
            detectionSlider.gameObject.SetActive(false);
            currentDetectionLevel = 0f;
        }
    }

    void EndGame()
    {
        gameEndPanel.SetActive(true);

    }

    public void reset()
    {
        maxDetectionLevel = GlobalState.DetectionLevelMax;
        detectionSlider.maxValue = maxDetectionLevel;
    }
}

