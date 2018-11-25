using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TroopsAliveUI : MonoBehaviour {

    public Text troopsAliveText;

    void Update()
    {
        troopsAliveText.text = "Troops: " + PlayerStats.TroopsInCamp.ToString() + "/" + PlayerStats.MaxTroops.ToString();
    }
}
