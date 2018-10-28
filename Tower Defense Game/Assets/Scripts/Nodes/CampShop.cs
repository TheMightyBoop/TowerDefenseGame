using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CampShop : MonoBehaviour {

    public TurretBlueprint footSoldierTower;

    [HideInInspector]
    public bool footSoldierTowerSelected = false;

    public BuildManager buildManager;

    public GameObject ui;

    private Node target;

    [HideInInspector]
    public GameObject turret;
    [HideInInspector]
    public TurretBlueprint turretBlueprint;

    public void SelectFootSoldierTower()
    {
        buildManager.SelectTurretToBuild(footSoldierTower);
        footSoldierTowerSelected = true;
    }

    public void SetTarget(Node _target)
    {
        target = _target;

        transform.position = target.GetBuildPosition();

        ui.SetActive(true);
    }

    public void Hide()
    {
        ui.SetActive(false);
    }
}
