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

    [Header("Optional")]
    public GameObject turret;
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
        if (turret != null || !buildManager.CanBuild || EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        buildManager.BuildTurretOn(this);
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
