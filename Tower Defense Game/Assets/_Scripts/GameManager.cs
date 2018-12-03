using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static bool GameIsOver;
    public static bool GameIsStarted;

    public GameObject gameOverUI;

    void Start()
    {
        GameIsOver = false;
        GameIsStarted = false;
    }

	void Update () {
        if (GameIsOver)
            return;

        if (Input.GetKeyDown(KeyCode.E))
        {
            GameIsStarted = true;
        }

		if(PlayerStats.Lives <= 0)
        {
            EndGame();
        }
	}

    void EndGame()
    {
        GameIsOver = true;
        gameOverUI.SetActive(true);
    }
}
