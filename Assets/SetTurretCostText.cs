using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SetTurretCostText : MonoBehaviour
{
    public TurretTemplate turret;
    
    void Start()
    {
        TMP_Text costText = transform.GetChild(0).gameObject.GetComponent<TextMeshPro>();
        costText.text = turret.cost.ToString();    
    }
}
