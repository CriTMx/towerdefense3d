using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretBehavior : MonoBehaviour
{
    [Header("Setup")]

    private Transform target;
    public Transform partToRotate;
    public float turnSpeed = 8f;
    public string enemyTag = "Enemy";

    public GameObject bulletPrefab;
    public Transform firePoint;

    [Header("Attributes")]

    private float range = 15f;
    public float fireRate = 1f;
    private float fireCountdown = 0f;

    

    void Start()
    {
        InvokeRepeating(nameof(UpdateTarget), 0f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null) return;

        Vector3 dir = target.position - transform.position;
        Quaternion lookRot = Quaternion.LookRotation(dir);
        Vector3 rot = Quaternion.Lerp(partToRotate.rotation, lookRot, Time.deltaTime * turnSpeed).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0f, rot.y, 0f);

        if (fireCountdown <= 0f)
        {
            Shoot();
            fireCountdown = 1f / fireRate;
        }

        fireCountdown -= Time.deltaTime;
    }

    void Shoot()
    {
        GameObject bulletGO = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        BulletBehavior bulletBehavior = bulletGO.GetComponent<BulletBehavior>();

        if (bulletBehavior != null)
        {
            bulletBehavior.Seek(target);
        }

    }

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDist = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distToEnemy < shortestDist)
            {
                shortestDist = distToEnemy;
                nearestEnemy = enemy;
            }

        }

        if (nearestEnemy != null && shortestDist <= range)
        {
            target = nearestEnemy.transform;
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
