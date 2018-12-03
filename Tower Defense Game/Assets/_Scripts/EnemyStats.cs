using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour {
    
    public static int Lives;
    public int startLives = 10;

    public static int TroopsInCamp = 0;

    public static int MaxTroops;
    public int MAX_TROOPS = 0;

    public static int Rounds;
    public static int PathIndex;
    public static Paths Paths;
    public Paths paths;

    public static Transform WaitingArea;
    public Transform waitingArea;

    void Start()
    {
        Lives = startLives;
        MaxTroops = MAX_TROOPS;
        Rounds = 0;
        PathIndex = 0;
        WaitingArea = waitingArea;
        Paths = paths;
    }
}
