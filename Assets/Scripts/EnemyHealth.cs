using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public float health;
    public int maxHealth = 0;
    public int enemyCurrencyReward = 0;

    public Image healthBar;

    public GameObject deathEffect;
    private GameObject deathEffectInstance;

    private void Start()
    {
        health = maxHealth;
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0)
        {
            Die();
        }
    }

    private void Update()
    {
        if (GameStateHandler.gameState == 0)
        {
            Destroy(this.gameObject);
            return;
        }
        healthBar.fillAmount = health / maxHealth;
    }

    void Die()
    {
        PlayerStatsHandler.ChangeMoney(enemyCurrencyReward);

        deathEffectInstance = Instantiate(deathEffect, transform.position, transform.rotation);
        Destroy(deathEffectInstance, 0.5f);
        Destroy(gameObject);
    }
}
