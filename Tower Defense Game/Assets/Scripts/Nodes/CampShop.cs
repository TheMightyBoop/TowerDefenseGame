using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CampShop : MonoBehaviour {

    public TurretBlueprint footSoldierTower;
    public TurretBlueprint footSoldierTower_NavMesh;

    [HideInInspector]
    public bool footSoldierTowerSelected = false;
    [HideInInspector]
    public bool footSoldierTower_NavMeshSelected = false;

    BuildManager buildManager;

    public GameObject ui;

    private Node target;

    [HideInInspector]
    public GameObject turret;
    [HideInInspector]
    public TurretBlueprint turretBlueprint;

    void Start()
    {
        buildManager = BuildManager.instance;
    }

    public void SelectFootSoldierTower()
    {
        buildManager.SelectTurretToBuild(footSoldierTower);
        footSoldierTowerSelected = true;
    }

    public void SelectFootSoldierTower_NavMesh()
    {
        buildManager.SelectTurretToBuild(footSoldierTower_NavMesh);
        footSoldierTower_NavMeshSelected = true;
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
