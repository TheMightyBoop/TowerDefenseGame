using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paths : MonoBehaviour {

    public TroopWaypoints[] paths;

    void Awake()
    {
        paths = new TroopWaypoints[transform.childCount];

        for (int i = 0; i < paths.Length; i++)
        {
            if (paths[i] == null)
            {
                paths[i] = transform.GetChild(i).GetComponent<TroopWaypoints>();
            }
        }
    }
}