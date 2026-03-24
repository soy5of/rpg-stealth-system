using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelManager : MonoBehaviour
{
    public Animator panelAnimator; // Ссылка на Animator панели
    public Button openPanelButton; // Ссылка на кнопку для открытия панели
    public bool panel = false;

    void Start()
    {
        panelAnimator.Play("offPanel");
        openPanelButton.onClick.AddListener(ChangePanel);
    }

    void ChangePanel()
    {
        if (panel)
        {
            ClosePanel();
        }
        else 
        {
            OpenPanel();
        }
    }

    void ClosePanel()
    {
        panelAnimator.SetTrigger("ClosePanel"); 
        panel = false;
    }
    
    void OpenPanel()
    {
        panelAnimator.SetTrigger("OpenPanel"); 
        panel = true;

    }
}