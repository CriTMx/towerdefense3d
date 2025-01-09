using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WaveSpawner : MonoBehaviour
{
    public static int EnemiesAlive = 0;

    public WaveData[] waves;

    public GameObject enemyPrefab;

    public bool enableSpawning = true;

    public float waveCooldown = 3f;
    public float spawnCountdown = 2f;
    public float spawnCooldown = 0.5f;

    public TMP_Text spawnCountdownText;

    public Transform spawnPoint;

    public int waveNumber = 1;

    private void Update()
    {
        if (enableSpawning)
        {
            if (EnemiesAlive > 0)
            {
                return;
            }

            if (spawnCountdown <= 0f)
            {
                StartCoroutine(SpawnWave());
                spawnCountdown = waveCooldown;
                return;
            }

            spawnCountdown -= Time.deltaTime;
            spawnCountdownText.text = Mathf.Round(spawnCountdown + 1).ToString();
        }
    }


    IEnumerator SpawnWave()
    {
        WaveData wave = waves[waveNumber];

        for (int i = 0; i < wave.count; i++)
        {
            SpawnEnemy(wave.enemy);
            yield return new WaitForSeconds(1f / wave.spawnRate);
        }

        waveNumber++;
    }

    private void SpawnEnemy(GameObject enemy)
    {
        Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
        EnemiesAlive++;
    }
}
