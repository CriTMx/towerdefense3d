using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    public GameObject standardTurret;
    public GameObject anotherTurret;

    public void PurchaseStandardTurret()
    {
        BuildManager.instance.SetTurretToBuild(standardTurret);
    }

    public void PurchaseAnotherTurret()
    {
        BuildManager.instance.SetTurretToBuild(anotherTurret);
    }

    
}
