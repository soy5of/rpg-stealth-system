using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FinalDoorInteraction : MonoBehaviour
{
    Animator animator;
    public GameObject PanelWarning;
    public GameObject key;

    void Start()
    {
        if (key != null)
        {
            key.SetActive(false);
        }
        animator = GetComponent<Animator>();
        animator.Play("FinalIdle");
        PanelWarning.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log(GlobalState.Key);
            if (GlobalState.Key)
            {
                animator.SetTrigger("FOD");
            }
            else
            {
                key.SetActive(true);
                PanelWarning.SetActive(true);
            }
        }
    }

    public void Ok()
    {
        PanelWarning.SetActive(false);
    }
}
