using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeHandler : MonoBehaviour
{
    private Renderer ren;
    public Color hoverColor = Color.yellow;
    public Color startColor = Color.white;
    public Color clickColor = new Color(255, 128, 0);

    public GameObject turret;
    public Vector3 turretPositionOffset = new Vector3(0f, 0.5f, 0f);

    private void Start()
    {
        ren = GetComponent<Renderer>();
    }

    private void OnMouseEnter()
    {
        ren.material.color = hoverColor;
    }

    private void OnMouseDown()
    {
        if (turret != null)
        {
            return;
        }

        GameObject turretToBuild = BuildManager.instance.GetTurretToBuild();
        turret = (GameObject) Instantiate(turretToBuild, transform.position + turretPositionOffset, turretToBuild.transform.rotation);
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
