using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    private float speed = 4f;
    public float speedModifiable;
    private Transform target;
    private int waypointIndex = 0;
    private float speedTimer = 0f;

    public float enemyEffectsOffset = 0.375f;

    
    void Start()
    {
        target = WaypointsHandler.waypoints[waypointIndex++];
        speedModifiable = speed;
    }

    void Update()
    {
        Vector3 moveDir = (target.position - transform.position);
        transform.Translate(moveDir.normalized * Time.deltaTime * speedModifiable);

        if (Vector3.Distance(transform.position, target.position) <= 0.2f)
        {
            GetNextWaypoint();
        }

        if (speedTimer > 0f) speedTimer -= Time.deltaTime;
        else
        {
            speedModifiable = speed;
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
            PlayerStatsHandler.ChangeLives(-1);
            Destroy(gameObject);
        }
    }

    public void ChangeSpeed(float factor)
    {
        speedTimer = 1f;
        speedModifiable = speed * factor;
    }
}
