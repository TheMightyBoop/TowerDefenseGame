using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NodeUI : MonoBehaviour {

    public GameObject ui;

    public Text upgradeCost;
    public Button upgradeButton;

    public Text specUpgradeCost;
    public Button specUpgradeButton;

    public Text sellAmount;

    private Node target;

    public BuildManager buildManager;

    public void SetTarget(Node _target)
    {
        target = _target;

        transform.position = target.GetBuildPosition();

        if (!target.isUpgraded)
        {
            upgradeCost.text = "$" + target.turretBlueprint.upgradeCost;
            upgradeButton.interactable = true;
            specUpgradeCost.text = "$" + target.turretBlueprint.specUpgradeCost;
            specUpgradeButton.interactable = true;
        }else
        {
            upgradeCost.text = "DONE";
            upgradeButton.interactable = false;
            specUpgradeCost.text = "DONE";
            specUpgradeButton.interactable = false;
        }

        sellAmount.text = "$" + target.turretBlueprint.GetSellAmount();

        ui.SetActive(true);
    }

    public void Hide()
    {
        ui.SetActive(false);
    }

    public void Upgrade()
    {
        target.UpgradeTurret();
        buildManager.DeselectNode();
    }

    public void SpecUpgrade()
    {
        target.SpecUpgradeTurret();
        buildManager.DeselectNode();
    }

    public void Sell()
    {
        target.SellTurret();
        target.isUpgraded = false;
        buildManager.DeselectNode();
    }
}
