using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public GameObject enemyPrefab;

    public float waveCooldown = 5f;
    public float spawnCountdown = 2f;

    private void Update()
    {
        if (spawnCountdown <= 0f)
        {
            SpawnWave();
            spawnCountdown = waveCooldown;
        }

        spawnCountdown -= Time.deltaTime;
    }

    private void SpawnWave()
    {
        Instantiate(enemyPrefab);
    }
}
