using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GlobalState
{
    
    public static bool Key { get; set; } = false;
    public static int Coin { get; set; } = 0;
    public static bool Screen { get; set; } = true;
    public static float DetectionLevelMax { get; set; } = 5f;
    public static float baseHackTimeDoor { get; set; } = 6f;
    public static bool Panel { get; set; } = false;
    public static int missingCoins { get; set; } = 0;

    // public static bool KeyCPY { get; set; };
    // public static int CoinCPY { get; set; };
    // public static bool ScreenCPY { get; set; };
    // public static float DetectionLevelMaxCPY { get; set; };
    // public static float baseHackTimeDoorCPY { get; set; };

    // public void Start(){

    // }
}