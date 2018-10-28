using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DefenseShop : MonoBehaviour {

    public TurretBlueprint standardTurret;
    public TurretBlueprint missileLauncher;
    public TurretBlueprint laserBeamer;

    [HideInInspector]
    public bool standardTurretSelected = false;
    [HideInInspector]
    public bool missileLauncherSelected = false;
    [HideInInspector]
    public bool laserBeamerSelected = false;

    public BuildManager buildManager;

    public GameObject ui;

    private Node target;

    [HideInInspector]
    public GameObject turret;
    [HideInInspector]
    public TurretBlueprint turretBlueprint;

    public void SelectStandardTurret()
    {
        buildManager.SelectTurretToBuild(standardTurret);
        standardTurretSelected = true;
    }

    public void SelectMissileLauncher()
    {
        buildManager.SelectTurretToBuild(missileLauncher);
        missileLauncherSelected = true;
    }

    public void SelectLaserBeamer()
    {
        buildManager.SelectTurretToBuild(laserBeamer);
        laserBeamerSelected = true;
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
