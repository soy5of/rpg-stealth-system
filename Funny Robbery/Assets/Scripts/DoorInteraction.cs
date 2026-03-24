using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorHackMulti : MonoBehaviour
{
    public float baseHackTime;
    private float currentHackTime;
    private bool isHacking = false;
    public bool dorIsHacked = false;
    public Slider hackProgressSlider;
    private bool playerInRange = false;
    Animator animator;

    void Start()
    {
        baseHackTime = GlobalState.baseHackTimeDoor;
        currentHackTime = baseHackTime;
        hackProgressSlider.maxValue = currentHackTime;
        animator = GetComponent<Animator>();
        hackProgressSlider.gameObject.SetActive(false);
        animator.Play("Idle");
        //Debug.Log(" ");
    }

    void Update()
    {
        reset();
        if (playerInRange && Input.GetKeyDown(KeyCode.F) && !dorIsHacked)
        {
            //hackProgressSlider.gameObject.SetActive(true);
            InteractWithDoor(baseHackTime);
        }

        if (isHacking)
        {
            currentHackTime -= Time.deltaTime;
            hackProgressSlider.value = currentHackTime;

            if (currentHackTime <= 0)
            {
                hackProgressSlider.gameObject.SetActive(false);
                Debug.Log("Дверь успешно взломана!");
                isHacking = false;
                animator.SetTrigger("OD");
                dorIsHacked = true;
                // Здесь можно добавить логику для изменения состояния двери
            }
        }
    }

    public void InteractWithDoor(float improvedTime)
    {
        reset();
        if (!isHacking)
        {
            isHacking = true;
            currentHackTime = improvedTime;
            hackProgressSlider.value = currentHackTime;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!dorIsHacked)
            {
                hackProgressSlider.gameObject.SetActive(true);
            }
            playerInRange = true;
            // hackProgressSlider.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!dorIsHacked)
            {
                hackProgressSlider.gameObject.SetActive(false);
            }
            playerInRange = false;
            if (isHacking)
            {
                isHacking = false;
                Debug.Log("Взлом прерван из-за ухода игрока из зоны.");
            }
        }

    }

    public void reset()
    {
        baseHackTime = GlobalState.baseHackTimeDoor;
        hackProgressSlider.maxValue = baseHackTime;
    }
}
