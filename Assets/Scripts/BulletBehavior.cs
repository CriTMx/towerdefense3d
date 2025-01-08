using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    private Transform target;
    public float speed = 40f;
    public float explosionRadius = 0f;
    public int bulletDamage = 0;

    public GameObject bulletImpactEffect;
    public GameObject bulletExplosionEffect;
    /*public GameObject bulletTrailEffect;*/


    GameObject impactEffectInstance;
    GameObject explosionEffectInstance;
    /*GameObject trailEffectInstance;*/

    public void Seek(Transform _target)
    {
        target = _target;
    }


    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if (dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
    }

    void HitTarget()
    {
        impactEffectInstance = (GameObject) Instantiate(bulletImpactEffect, transform.position, bulletImpactEffect.transform.rotation);
        Destroy(impactEffectInstance, 0.75f);

        if (explosionRadius > 0f)
        {
            DamageAOEAtTarget(target.gameObject);
        } else
        {
            DamageSingleTarget(target.gameObject);
        }

        
        Destroy(gameObject);
    }

    void DamageSingleTarget(GameObject _target)
    {
        if (_target.CompareTag("Enemy"))
        {
            _target.GetComponent<EnemyHealth>().TakeDamage(bulletDamage);
        }
    }

    void DamageAOEAtTarget(GameObject _target)
    {
        explosionEffectInstance = Instantiate(bulletExplosionEffect, _target.transform.position, bulletExplosionEffect.transform.rotation);
        Destroy(explosionEffectInstance, 2f);

        Collider[] affectedTargets = Physics.OverlapSphere(_target.transform.position, explosionRadius);
        foreach (Collider targ in affectedTargets)
        {
            if (targ.CompareTag("Enemy"))
            {
                targ.GetComponent<EnemyHealth>().TakeDamage(bulletDamage);
                
            }
        }
    }
}
