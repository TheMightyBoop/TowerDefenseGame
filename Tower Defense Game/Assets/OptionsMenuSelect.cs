using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsMenuSelect : MonoBehaviour {

    public string modeSelect = "ModeSelect";

    public SceneFader sceneFader;

    public void Quit()
    {
        sceneFader.FadeTo(modeSelect);
    }
}
