using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerStats : MonoBehaviour {

    public static int Money;
    public int startMoney = 400;

    public static int Lives;
    public int startLives = 10;

    public static int TroopsInCamp = 0;

    public static int MaxTroops;
    public int MAX_TROOPS = 0;

    public static int Rounds;
    public static int PathIndex;

    void Start()
    {
        Money = startMoney;
        Lives = startLives;
        MaxTroops = MAX_TROOPS;
        Rounds = 0;
        PathIndex = 0;
    }

    public void SelectPath1()
    {
        PathIndex = 0;
        Debug.Log("Path changed to: Path 1");
    }

    public void SelectPath2()
    {
        PathIndex = 1;
        Debug.Log("Path changed to: Path 2");
    }
}
