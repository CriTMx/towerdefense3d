using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShopManager : MonoBehaviour
{
    public TurretTemplate standardTurret;
    public TurretTemplate anotherTurret;

    public void PurchaseStandardTurret()
    {
        BuildManager.instance.SetTurretToBuild(standardTurret);
    }

    public void PurchaseAnotherTurret()
    {
        BuildManager.instance.SetTurretToBuild(anotherTurret);
    }
}
