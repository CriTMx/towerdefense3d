using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShopManager : MonoBehaviour
{
    public TurretTemplate standardTurret;
    public TurretTemplate anotherTurret;

    public TMP_Text standardTurretCostText;
    public TMP_Text anotherTurretCostText;

    private void Start()
    {
        standardTurretCostText.text = standardTurret.cost.ToString();
        anotherTurretCostText.text = anotherTurret.cost.ToString();
    }

    public void PurchaseStandardTurret()
    {
        BuildManager.instance.SetTurretToBuild(standardTurret);
    }

    public void PurchaseAnotherTurret()
    {
        BuildManager.instance.SetTurretToBuild(anotherTurret);
    }
}
