using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GalleryMenu : MonoBehaviour
{
    public string modeSelect = "ModeSelect";

    public SceneFader sceneFader;

    public void Quit()
    {
        sceneFader.FadeTo(modeSelect);
    }
}
