using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class NodeHandler : MonoBehaviour
{
    private Renderer ren;
    public Color hoverColor = Color.yellow;
    public Color startColor = Color.white;
    public Color clickColor = new Color(255, 128, 0);
    public Color errorColor = Color.red;

    [HideInInspector]
    public GameObject turret;
    [HideInInspector]
    public TurretTemplate turretTemplate;
    [HideInInspector]
    public bool isUpgraded = false;

    public Vector3 turretPositionOffset = new Vector3(0f, 0.25f, 0f);

    BuildManager buildManager;

    public Vector3 GetBuildPosition()
    {
        return transform.position + turretPositionOffset;
    }

    private void Start()
    {
        ren = GetComponent<Renderer>();
        buildManager = BuildManager.instance;
    }

    public void BuildTurret(TurretTemplate turretToBuild)
    {
        if (PlayerStatsHandler.Money < turretToBuild.cost)
        {
            StartCoroutine(buildManager.DisplayInsufficientMoneyError());
            return;
        }
        /*Debug.Log("build turret on");*/
        GameObject _turret = Instantiate(turretToBuild.turret, GetBuildPosition(), turretToBuild.turret.transform.rotation);
        turret = _turret;
        turretTemplate = turretToBuild;

        GameObject buildEffectInstance = Instantiate(buildManager.buildEffect, GetBuildPosition(), buildManager.buildEffect.transform.rotation);
        Destroy(buildEffectInstance, 1f);

        PlayerStatsHandler.Money -= turretToBuild.cost;
    }

    public void UpgradeTurret()
    {
        if (PlayerStatsHandler.Money < turretTemplate.upgradeCost)
        {
            StartCoroutine(buildManager.DisplayInsufficientMoneyError());
            return;
        }

        Destroy(turret);
        Debug.Log(turretTemplate.ToString());
        Debug.Log(turretTemplate.upgradedTurret.ToString());
        GameObject _turret = Instantiate(turretTemplate.upgradedTurret, GetBuildPosition(), turretTemplate.upgradedTurret.transform.rotation);
        turret = _turret;

        GameObject upgradeEffectInstance = Instantiate(buildManager.buildEffect, GetBuildPosition(), buildManager.buildEffect.transform.rotation);
        Destroy(upgradeEffectInstance, 1f);

        PlayerStatsHandler.Money -= turretTemplate.upgradeCost;


        isUpgraded = true;
    }

    public void SellTurret()
    {
        if (turret != null)
        {
            PlayerStatsHandler.Money += turretTemplate.sellCost;
            isUpgraded = false;
            GameObject sellEffectInstance = Instantiate(buildManager.sellEffect, GetBuildPosition(), buildManager.sellEffect.transform.rotation);
            Destroy(turret);
        }
    }

    private void OnMouseEnter()
    {
        if (!buildManager.CanBuild || EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        ren.material.color = buildManager.HasMoney ? hoverColor : errorColor;
    }

    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if (turret != null)
        {
            buildManager.SelectNode(this);
            return;
        }

        if (!buildManager.CanBuild)
        {
            return;
        }

        

        BuildTurret(buildManager.GetTurretToBuild());
    }

    private void OnMouseUp()
    {
        ren.material.color = startColor;
    }

    private void OnMouseExit()
    {
        ren.material.color = startColor;
    }
}
