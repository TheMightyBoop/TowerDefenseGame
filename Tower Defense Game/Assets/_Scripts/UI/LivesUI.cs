using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesUI : MonoBehaviour {

    public Text livesText;
    public bool enemy;
    public bool player;

	// Update is called once per frame
	void Update () {
        if (enemy == true)
        {
            livesText.text = EnemyStats.Lives + " LIVES";
        } else if (player == true)
        {
            livesText.text = PlayerStats.Lives + " LIVES";
        }
	}
}
