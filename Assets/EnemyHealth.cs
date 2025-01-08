using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int health = 0;
    public int maxHealth = 0;
    public int enemyCurrencyReward = 0;

    public GameObject deathEffect;
    private GameObject deathEffectInstance;

    public void TakeDamage(int amount)
    {
        health -= amount;
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        PlayerStatsHandler.ChangeMoney(enemyCurrencyReward);

        deathEffectInstance = Instantiate(deathEffect, transform.position, transform.rotation);
        Destroy(deathEffectInstance, 0.5f);
        Destroy(gameObject);
    }
}
