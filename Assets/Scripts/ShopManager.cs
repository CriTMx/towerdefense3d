using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShopManager : MonoBehaviour
{
    public TurretTemplate standardTurret;
    public TurretTemplate missileTurret;
    public TurretTemplate laserTurret;

    public TMP_Text standardTurretCostText;
    public TMP_Text missleTurretCostText;
    public TMP_Text laserTurretCostText;

    private void Start()
    {
        standardTurretCostText.text = standardTurret.cost.ToString();
        missleTurretCostText.text = missileTurret.cost.ToString();
        laserTurretCostText.text = laserTurret.cost.ToString();
    }

    public void PurchaseStandardTurret()
    {
        BuildManager.instance.SetTurretToBuild(standardTurret);
    }

    public void PurchaseMissileTurret()
    {
        BuildManager.instance.SetTurretToBuild(missileTurret);
    }

    public void PurchaseLaserTurret()
    {
        BuildManager.instance.SetTurretToBuild(laserTurret);
    }
}
