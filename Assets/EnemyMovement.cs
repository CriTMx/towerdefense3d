using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    private float speed = 10f;
    private Transform target;
    private int waypointIndex = 0;

    
    void Start()
    {
        target = WaypointsHandler.waypoints[0];
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed);
        
    }
}
