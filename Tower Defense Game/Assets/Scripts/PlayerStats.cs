using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour {

    public static int Money;
    public int startMoney = 400;

    public static int Lives;
    public int startLives = 10;

    public static int TroopsInCamp = 0;

    public static int MaxTroops;
    public int MAX_TROOPS = 0;

    public static int Rounds;

    void Start()
    {
        Money = startMoney;
        Lives = startLives;
        MaxTroops = MAX_TROOPS;
        Rounds = 0;
    }
}
