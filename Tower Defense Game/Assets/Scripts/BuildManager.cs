using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour {

    public static BuildManager instance;

    void Awake()
    {
        if(instance != null)
        {
            Debug.LogError("Multiple BuildManagers");
            return;
        }

        instance = this;
    }

    public GameObject buildEffect;
    public GameObject sellEffect;

    private TurretBlueprint turretToBuild;
    private Node selectedNode;

    public NodeUI nodeUI;
    public DefenseShop defenseShopUI;
    public CampShop campShopUI;

    public bool CanBuild { get { return turretToBuild != null; } }
    public bool HasMoney { get { return PlayerStats.Money >= turretToBuild.cost; } }

    void Update()
    {
        if (defenseShopUI.standardTurretSelected)
        {
            selectedNode.BuildTurret(turretToBuild);
            defenseShopUI.standardTurretSelected = false;
            DeselectNode();
        }

        if (defenseShopUI.missileLauncherSelected)
        {
            selectedNode.BuildTurret(turretToBuild);
            defenseShopUI.missileLauncherSelected = false;
            DeselectNode();
        }

        if (defenseShopUI.laserBeamerSelected)
        {
            selectedNode.BuildTurret(turretToBuild);
            defenseShopUI.laserBeamerSelected = false;
            DeselectNode();
        }

        if (campShopUI.footSoldierTowerSelected)
        {
            selectedNode.BuildTurret(turretToBuild);
            campShopUI.footSoldierTowerSelected = false;
            DeselectNode();
        }

        if (campShopUI.footSoldierTower_NavMeshSelected)
        {
            selectedNode.BuildTurret(turretToBuild);
            campShopUI.footSoldierTower_NavMeshSelected = false;
            DeselectNode();
        }
    }

    public void SelectNodeUpgrade(Node node)
    {
        if(selectedNode == node)
        {
            DeselectNode();
            return;
        }

        selectedNode = node;
        turretToBuild = null;
        nodeUI.SetTarget(node);
    }

    public void SelectDefenseNodeShop(Node node)
    {
        if (selectedNode == node)
        {
            DeselectNode();
            return;
        }

        campShopUI.Hide();
        selectedNode = node;
        turretToBuild = null;
        defenseShopUI.SetTarget(node);
    }

    public void SelectCampNodeShop(Node node)
    {
        if (selectedNode == node)
        {
            DeselectNode();
            return;
        }

        defenseShopUI.Hide();
        selectedNode = node;
        turretToBuild = null;
        campShopUI.SetTarget(node);
    }

    public void DeselectNode()
    {
        selectedNode = null;
        nodeUI.Hide();
        defenseShopUI.Hide();
        campShopUI.Hide();
    }

    public void SelectTurretToBuild(TurretBlueprint turret)
    {
        turretToBuild = turret;
    }

    public TurretBlueprint GetTurretToBuild()
    {
        return turretToBuild;
    }
}
