using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TurretBlueprint {

    public GameObject prefab;
    public int cost;

    public GameObject upgradedPrefab;
    public int upgradeCost;

    public GameObject specUpgradedPrefab;
    public int specUpgradeCost;

    public int GetSellAmount()
    {
        return cost / 2;
    }
}
