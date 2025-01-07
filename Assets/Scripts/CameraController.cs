using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("Panning")]
    public float panSpeed = 30f;
    public float panBorderThickness = 10;
    public bool enableMousePanning = true;
    public float minX = -10.75f;
    public float maxX = 29.25f;
    public float minZ = -19f;
    public float maxZ = 21f;

    [Header("Zooming")]
    public float scrollSpeed = 5f;
    public float minY = 10f;
    public float maxY = 50f;

    private Vector3 movePos;
    private float scroll;
    private Vector3 zoom;

    
    void Update()
    {
        if (Input.GetKey("w") /*|| Input.mousePosition.y >= (Screen.height - panBorderThickness)*/)
        {
            transform.Translate(Vector3.forward * panSpeed * Time.deltaTime, Space.World);
        }
        else if (Input.GetKey("a") /*|| Input.mousePosition.x <= panBorderThickness*/)
        {
            transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.World);
        }
        else if (Input.GetKey("s") /*|| Input.mousePosition.y <= panBorderThickness*/)
        {
            transform.Translate(Vector3.back * panSpeed * Time.deltaTime, Space.World);
        }
        else if (Input.GetKey("d") /*|| Input.mousePosition.x >= (Screen.width - panBorderThickness)*/)
        {
            transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.World);
        }

        scroll = Input.GetAxis("Mouse ScrollWheel");
        zoom = transform.position;
        zoom.y -= scroll * 1000 * scrollSpeed * Time.deltaTime;
        zoom.y = Mathf.Clamp(zoom.y, minY, maxY);

        transform.position = zoom;
    }
}
