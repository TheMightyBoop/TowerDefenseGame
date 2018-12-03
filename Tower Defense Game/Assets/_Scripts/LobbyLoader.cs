using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LobbyLoader : MonoBehaviour {

    public string levelToLoad = "Level0_SinglePlayer";
    public string quit = "ModeSelect";

    public SceneFader sceneFader;

    public void StartGame()
    {
        sceneFader.FadeTo(levelToLoad);
    }

    public void Quit()
    {
        sceneFader.FadeTo(quit);
    }
}
