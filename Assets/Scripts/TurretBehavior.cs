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

    [Header("Use bullets (default")]
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float fireRate = 1f;
    private float fireCountdown = 0f;

    [Header("Use laser")]
    public bool useLaser = false;
    public LineRenderer lineRen;
    public ParticleSystem laserImpactEffect;

    [Header("General Attributes")]

    public float range = 15f;
    

    

    void Start()
    {
        InvokeRepeating(nameof(UpdateTarget), 0f, 1f);
        lineRen = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            if (useLaser && lineRen.enabled)
            {
                lineRen.enabled = false;
                laserImpactEffect.Stop();
            }
            return;
        }

        LockOnTarget();

        if (useLaser)
        {
            Laser();
        }
        else
        {
            if (fireCountdown <= 0f)
            {
                Shoot();
                fireCountdown = 1f / fireRate;
            }

            fireCountdown -= Time.deltaTime;
        }
    }

    void Laser()
    {
        if (!lineRen.enabled)
        {
            lineRen.enabled = true;
            laserImpactEffect.Play();
        }

        lineRen.SetPosition(0, firePoint.position);
        lineRen.SetPosition(1, target.position);

        AdjustLaserImpactEffectTransform();

        target.gameObject.GetComponent<EnemyMovement>()?.ChangeSpeed(2);
    }

    void AdjustLaserImpactEffectTransform()
    {
        laserImpactEffect.transform.position = target.position;
        laserImpactEffect.transform.rotation = partToRotate.rotation;
        laserImpactEffect.transform.Rotate(Vector3.up, 180);
    }

    void LockOnTarget()
    {
        Vector3 dir = target.position - transform.position;
        Quaternion lookRot = Quaternion.LookRotation(dir);
        Vector3 rot = Quaternion.Lerp(partToRotate.rotation, lookRot, Time.deltaTime * turnSpeed).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0f, rot.y, 0f);
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
