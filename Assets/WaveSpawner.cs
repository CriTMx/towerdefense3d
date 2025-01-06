using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WaveSpawner : MonoBehaviour
{
    public GameObject enemyPrefab;

    public float waveCooldown = 5f;
    public float spawnCountdown = 2f;
    public float spawnCooldown = 0.5f;

    public TMP_Text spawnCountdownText;

    public Transform spawnPoint;

    private int waveNumber = 1;

    private void Update()
    {
        if (spawnCountdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            spawnCountdown = waveCooldown;
        }

        spawnCountdown -= Time.deltaTime;
        spawnCountdownText.text = Mathf.Round(spawnCountdown+1).ToString();
    }


    IEnumerator SpawnWave()
    {
        for (int i = 0; i < waveNumber; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(spawnCooldown);
        }

        waveNumber++;
    }

    private void SpawnEnemy()
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
