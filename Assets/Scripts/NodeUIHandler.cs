using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NodeUIHandler : MonoBehaviour
{
    public GameObject ui;
    private NodeHandler targetNode;
    public TMP_Text upgradeText;
    public TMP_Text sellText;

    public ShopManager shop;

    public void UpdateButtonText()
    {
        upgradeText.text = "<b>Upgrade</b>\n-" + (targetNode.turretTemplate.upgradeCost).ToString();
        sellText.text = "<b>Sell</b>\n+" + (targetNode.turretTemplate.sellCost).ToString();
    }

    public void SetTargetNode(NodeHandler _targetNode)
    {
        targetNode = _targetNode;

        transform.position = targetNode.GetBuildPosition();

        UpdateButtonText();
        
        ui.SetActive(true);
    }

    public void HideUI()
    {
        ui.SetActive(false);
    }

    public void Upgrade()
    {
        targetNode.UpgradeTurret();
        BuildManager.instance.DeselectNode();
    }

    public void Sell()
    {
        targetNode.SellTurret();
        BuildManager.instance.DeselectNode();
    }
}
