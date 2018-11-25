using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ModeSelect : MonoBehaviour {

    public string singlePlayer = "SinglePlayerLobby";
    public string gallery = "Gallery";
    public string optionsMenu = "OptionsMenu";

    public SceneFader sceneFader;

    public void SinglePlayer()
    {
        sceneFader.FadeTo(singlePlayer);
    }

    public void Gallery()
    {
        sceneFader.FadeTo(gallery);
    }

    public void Options()
    {
        sceneFader.FadeTo(optionsMenu);
    }

    public void Quit()
    {
        Debug.Log("Exiting...");
        Application.Quit();
    }
}
