using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CampShop : MonoBehaviour {

    public TurretBlueprint footSoldierTower;
    public TurretBlueprint heavySoldierTower;
    public TurretBlueprint fastSoldierTower;
    public TurretBlueprint flyingSoldierTower;

    [HideInInspector]
    public bool footSoldierTowerSelected = false;
    [HideInInspector]
    public bool heavySoldierTowerSelected = false;
    [HideInInspector]
    public bool fastSoldierTowerSelected = false;
    [HideInInspector]
    public bool flyingSoldierTowerSelected = false;

    public BuildManager buildManager;

    public GameObject ui;

    private Node target;

    [HideInInspector]
    public GameObject turret;
    [HideInInspector]
    public TurretBlueprint turretBlueprint;

    //Select Tower Functions
    public void SelectFootSoldierTower()
    {
        buildManager.SelectTurretToBuild(footSoldierTower);
        footSoldierTowerSelected = true;
    }

    public void SelectHeavySoldierTower()
    {
        buildManager.SelectTurretToBuild(heavySoldierTower);
        footSoldierTowerSelected = true;
    }

    public void SelectFastSoldierTower()
    {
        buildManager.SelectTurretToBuild(fastSoldierTower);
        footSoldierTowerSelected = true;
    }

    public void SelectFlyingSoldierTower()
    {
        buildManager.SelectTurretToBuild(flyingSoldierTower);
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
