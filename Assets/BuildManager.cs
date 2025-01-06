using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{

    public static BuildManager instance;

    private void Awake()
    {
        if (instance != null) return;
        instance = this;
    }

    public GameObject standardTurretPrefab;
    private GameObject turretToBuild;

    public GameObject GetTurretToBuild()
    {
        return turretToBuild;
    }


    void Start()
    {
        turretToBuild = standardTurretPrefab;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
