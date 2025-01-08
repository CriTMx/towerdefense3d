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
    public TMP_Text insufficientMoneyErrorText;

    public GameObject buildEffect;
    private GameObject buildEffectInstance;

    public bool CanBuild { get { return turretToBuild != null; } } 
    public bool HasMoney { get { return PlayerStatsHandler.Money >= turretToBuild.cost; } }

    public TurretTemplate GetTurretToBuild()
    {
        return turretToBuild;
    }

    public void SetTurretToBuild(TurretTemplate _turretToBuild)
    {
        turretToBuild = _turretToBuild;
    }


    public void BuildTurretOn(NodeHandler node)
    {
        if (PlayerStatsHandler.Money < turretToBuild.cost)
        {
            StartCoroutine(DisplayInsufficientMoneyError());
            return;
        }
        /*Debug.Log("build turret on");*/
        GameObject turret = Instantiate(turretToBuild.turret, node.GetBuildPosition(), turretToBuild.turret.transform.rotation);
        node.turret = turret;

        buildEffectInstance = Instantiate(buildEffect, node.GetBuildPosition(), buildEffect.transform.rotation);
        Destroy(buildEffectInstance, 1f);

        PlayerStatsHandler.Money -= turretToBuild.cost;
    }

    IEnumerator DisplayInsufficientMoneyError()
    {
        if (insufficientMoneyErrorText.gameObject.activeInHierarchy)
            insufficientMoneyErrorText.gameObject.SetActive(false);
        insufficientMoneyErrorText.gameObject.SetActive(true);
        yield return new WaitForSeconds(2);
        insufficientMoneyErrorText.gameObject.SetActive(false);
    }    
}
