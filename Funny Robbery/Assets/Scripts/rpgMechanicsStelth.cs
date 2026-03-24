using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class rpgMechanicsSthelth : MonoBehaviour
{
    // public float timeOfDetection;
    public int upgradeCostSt;
    public int levelStealth = 0;
    public TMP_Text LSText;
    public GameObject button;

    void Start()
    {
        button.SetActive(true);
    }

    void Update()
    {
        printLevelStealth(levelStealth);
        if(levelStealth == 5)
        {
            button.SetActive(false);
        }
    }

    public void levelUpSt()
    {
        upgradeCost();
        if (GlobalState.Coin >= upgradeCostSt)
        {
            levelStealth++;
            GlobalState.DetectionLevelMax += 0.5f;
            GlobalState.Coin -= upgradeCostSt;
        }
        else 
        { 
            GlobalState.Panel = true;
            GlobalState.missingCoins = upgradeCostSt - GlobalState.Coin;
        }
    }

    public void upgradeCost()
    {
        upgradeCostSt = levelStealth * 5 + 10;
    }

    public void printLevelStealth(int levelStealth)
    {
        LSText.text = $"{levelStealth}/5";
    }
}