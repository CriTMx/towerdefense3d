using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeUIHandler : MonoBehaviour
{
    public GameObject ui;
    private NodeHandler targetNode;

    public void SetTargetNode(NodeHandler _targetNode)
    {
        targetNode = _targetNode;

        transform.position = targetNode.GetBuildPosition();
        this.enabled = true;
        ui.SetActive(true);
    }

    public void HideUI()
    {
        ui.SetActive(false);
    }
}
