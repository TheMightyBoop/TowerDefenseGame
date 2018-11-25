using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DefenseShop : MonoBehaviour {

    public TurretBlueprint gunTurret;
    public TurretBlueprint missileLauncher;
    public TurretBlueprint mageTower;

    [HideInInspector]
    public bool gunTurretSelected = false;
    [HideInInspector]
    public bool missileLauncherSelected = false;
    [HideInInspector]
    public bool mageTowerSelected = false;

    public BuildManager buildManager;

    public GameObject ui;

    private Node target;

    [HideInInspector]
    public GameObject turret;
    [HideInInspector]
    public TurretBlueprint turretBlueprint;

    public void SelectGunTurret()
    {
        buildManager.SelectTurretToBuild(gunTurret);
        gunTurretSelected = true;
    }

    public void SelectMissileLauncher()
    {
        buildManager.SelectTurretToBuild(missileLauncher);
        missileLauncherSelected = true;
    }

    public void SelectMageTower()
    {
        buildManager.SelectTurretToBuild(mageTower);
        mageTowerSelected = true;
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
