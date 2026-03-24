using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class rpgMechanicsHack : MonoBehaviour
{
    // public float timeOfBreaking;
    public int upgradeCostBr;
    public int levelBreaking = 0;
    public TMP_Text LBText;
    public GameObject button;

    void Start()
    {
        button.SetActive(true);
    }

    void Update()
    {
        printLevelBreaking(levelBreaking);
        if(levelBreaking == 5)
        {
            button.SetActive(false);
        }
    }

    public void levelUpBr()
    {
        upgradeCost();
        if (GlobalState.Coin >= upgradeCostBr)
        {
            levelBreaking++;
            GlobalState.baseHackTimeDoor--;
            GlobalState.Coin -= upgradeCostBr;
        }
        else 
        { 
            GlobalState.Panel = true;
            GlobalState.missingCoins = upgradeCostBr - GlobalState.Coin;
        }
    }

    public void upgradeCost()
    {
        upgradeCostBr = levelBreaking * 5 + 10;
    }

    public void printLevelBreaking(int levelBreaking)
    {
        LBText.text = $"{levelBreaking}/5";
    }
}