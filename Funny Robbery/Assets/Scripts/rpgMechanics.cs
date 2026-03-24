using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class rpgMechanics : MonoBehaviour
{
    public TMP_Text coinText;
    public TMP_Text warn;
    public GameObject PanelWarning;

    void Start()
    {     
        PanelWarning.SetActive(false);

    }

    void Update()
    {
        printCoin();
        if (GlobalState.Panel)
        {
            PanelWarning.SetActive(true);
            warn.text = $"Not enough money: {GlobalState.missingCoins} to go";
        }
    }

    void printCoin()
    {
        coinText.text = $"{GlobalState.Coin}";
    }

    public void Ok()
    {
        PanelWarning.SetActive(false);
        GlobalState.Panel = false;
    }

}