using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BuildManager : MonoBehaviour
{

    public static BuildManager instance;

    private void Awake()
    {
        if (instance != null) return;
        instance = this;
    }

    public GameObject standardTurretPrefab;
    public GameObject missileTurretPrefab;
    public GameObject laserTurretPrefab;

    private TurretTemplate turretToBuild;
    private NodeHandler selectedNode;
    public NodeUIHandler nodeUI;

    public TMP_Text insufficientMoneyErrorText;

    public GameObject buildEffect;
    private GameObject buildEffectInstance;

    public GameObject sellEffect;

    public bool CanBuild { get { return turretToBuild != null; } } 
    public bool HasMoney { get { return PlayerStatsHandler.Money >= turretToBuild.cost; } }

    public TurretTemplate GetTurretToBuild()
    {
        return turretToBuild;
    }

    public void SetTurretToBuild(TurretTemplate _turretToBuild)
    {
        turretToBuild = _turretToBuild;
        DeselectNode();
    }

    public void SelectNode(NodeHandler node)
    {
        if (selectedNode == node)
        {
            DeselectNode();
            return;
        }
        selectedNode = node;
        turretToBuild = null;
        nodeUI.SetTargetNode(selectedNode);
    }

    public void DeselectNode()
    {
        selectedNode = null;
        nodeUI.HideUI();
    }


    public IEnumerator DisplayInsufficientMoneyError()
    {
        if (insufficientMoneyErrorText.gameObject.activeInHierarchy)
            insufficientMoneyErrorText.gameObject.SetActive(false);
        insufficientMoneyErrorText.gameObject.SetActive(true);
        yield return new WaitForSeconds(2);
        insufficientMoneyErrorText.gameObject.SetActive(false);
    }    
}
