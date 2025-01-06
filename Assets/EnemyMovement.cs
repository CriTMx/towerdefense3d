using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    private float speed = 4f;
    private Transform target;
    private int waypointIndex = 0;

    
    void Start()
    {
        target = WaypointsHandler.waypoints[waypointIndex++];
    }

    void Update()
    {
        Vector3 moveDir = (target.position - transform.position);
        transform.Translate(moveDir.normalized * Time.deltaTime * speed);

        if (Vector3.Distance(transform.position, target.position) <= 0.2f)
        {
            GetNextWaypoint();
        }
    }

    private void GetNextWaypoint()
    {
        if (waypointIndex < WaypointsHandler.waypoints.Length)
        {
            target = WaypointsHandler.waypoints[waypointIndex++];
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
