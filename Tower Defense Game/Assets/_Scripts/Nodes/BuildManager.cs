using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour {

    public GameObject buildEffect;
    public GameObject sellEffect;

    private TurretBlueprint turretToBuild;
    private Node selectedNode;

    [Header("Node UI")]
    public NodeUI nodeUI_playerOne;
    //public NodeUI nodeUI_playerTwo;
    [Header("Defense Shops")]
    public DefenseShop defenseShopUI_playerOne;
    //public DefenseShop defenseShopUI_playerTwo;
    [Header("Camp Shops")]
    public CampShop campShopUI_playerOne;
    //public CampShop campShopUI_playerTwo;

    public bool CanBuild { get { return turretToBuild != null; } }
    public bool HasMoney { get { return PlayerStats.Money >= turretToBuild.cost; } }

    void Update()
    {
        //PlayerOne shops
        //Defense
        if (defenseShopUI_playerOne.gunTurretSelected && PlayerStats.PlayerNumber == 1)
        {
            selectedNode.BuildTurret(turretToBuild);
            defenseShopUI_playerOne.gunTurretSelected = false;
            DeselectNode();
        }

        if (defenseShopUI_playerOne.missileLauncherSelected && PlayerStats.PlayerNumber == 1)
        {
            selectedNode.BuildTurret(turretToBuild);
            defenseShopUI_playerOne.missileLauncherSelected = false;
            DeselectNode();
        }

        if (defenseShopUI_playerOne.mageTowerSelected && PlayerStats.PlayerNumber == 1)
        {
            selectedNode.BuildTurret(turretToBuild);
            defenseShopUI_playerOne.mageTowerSelected = false;
            DeselectNode();
        }

        //Offense
        if (campShopUI_playerOne.footSoldierTowerSelected && PlayerStats.PlayerNumber == 1)
        {
            selectedNode.BuildTurret(turretToBuild);
            campShopUI_playerOne.footSoldierTowerSelected = false;
            DeselectNode();
        }

        if (campShopUI_playerOne.heavySoldierTowerSelected && PlayerStats.PlayerNumber == 1)
        {
            selectedNode.BuildTurret(turretToBuild);
            campShopUI_playerOne.heavySoldierTowerSelected = false;
            DeselectNode();
        }

        if (campShopUI_playerOne.fastSoldierTowerSelected && PlayerStats.PlayerNumber == 1)
        {
            selectedNode.BuildTurret(turretToBuild);
            campShopUI_playerOne.fastSoldierTowerSelected = false;
            DeselectNode();
        }

        if (campShopUI_playerOne.flyingSoldierTowerSelected && PlayerStats.PlayerNumber == 1)
        {
            selectedNode.BuildTurret(turretToBuild);
            campShopUI_playerOne.flyingSoldierTowerSelected = false;
            DeselectNode();
        }

        /*//PlayerTwo shops
        //Defense
        if (defenseShopUI_playerTwo.gunTurretSelected && PlayerStats.PlayerNumber == 2)
        {
            selectedNode.BuildTurret(turretToBuild);
            defenseShopUI_playerTwo.gunTurretSelected = false;
            DeselectNode();
        }

        if (defenseShopUI_playerTwo.missileLauncherSelected && PlayerStats.PlayerNumber == 2)
        {
            selectedNode.BuildTurret(turretToBuild);
            defenseShopUI_playerTwo.missileLauncherSelected = false;
            DeselectNode();
        }

        if (defenseShopUI_playerTwo.mageTowerSelected && PlayerStats.PlayerNumber == 2)
        {
            selectedNode.BuildTurret(turretToBuild);
            defenseShopUI_playerTwo.mageTowerSelected = false;
            DeselectNode();
        }

        //Offense
        if (campShopUI_playerTwo.footSoldierTowerSelected && PlayerStats.PlayerNumber == 2)
        {
            selectedNode.BuildTurret(turretToBuild);
            campShopUI_playerTwo.footSoldierTowerSelected = false;
            DeselectNode();
        }

        if (campShopUI_playerTwo.heavySoldierTowerSelected && PlayerStats.PlayerNumber == 2)
        {
            selectedNode.BuildTurret(turretToBuild);
            campShopUI_playerTwo.heavySoldierTowerSelected = false;
            DeselectNode();
        }

        if (campShopUI_playerTwo.fastSoldierTowerSelected && PlayerStats.PlayerNumber == 2)
        {
            selectedNode.BuildTurret(turretToBuild);
            campShopUI_playerTwo.fastSoldierTowerSelected = false;
            DeselectNode();
        }

        if (campShopUI_playerTwo.flyingSoldierTowerSelected && PlayerStats.PlayerNumber == 2)
        {
            selectedNode.BuildTurret(turretToBuild);
            campShopUI_playerTwo.flyingSoldierTowerSelected = false;
            DeselectNode();
        }*/
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
        nodeUI_playerOne.SetTarget(node);
    }

    public void SelectDefenseNodeShop(Node node)
    {
        if (selectedNode == node)
        {
            DeselectNode();
            return;
        }

        campShopUI_playerOne.Hide();
        selectedNode = node;
        turretToBuild = null;
        defenseShopUI_playerOne.SetTarget(node);
    }

    public void SelectCampNodeShop(Node node)
    {
        if (selectedNode == node)
        {
            DeselectNode();
            return;
        }

        defenseShopUI_playerOne.Hide();
        selectedNode = node;
        turretToBuild = null;
        campShopUI_playerOne.SetTarget(node);
    }

    public void DeselectNode()
    {
        selectedNode = null;
        nodeUI_playerOne.Hide();
        defenseShopUI_playerOne.Hide();
        campShopUI_playerOne.Hide();
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
