using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class GameStateHandler : MonoBehaviour
{
    public static GameStateHandler instance;

    public static int gameState = 1;

    public int score;

    private void Awake()
    {
        if (instance != null) return;
        instance = this;
    }

    public GameObject shopPanel;
    public GameObject gameOverScreen;
    public GameObject waveCountdownDisplay;
    public TMP_Text scoreText;

    public void EndGame()
    {
        GetComponent<WaveSpawner>().enableSpawning = false;
        shopPanel.SetActive(false);
        waveCountdownDisplay.SetActive(false);
        gameOverScreen.SetActive(true);
        scoreText.text = (GetComponent<WaveSpawner>().waveNumber - 1).ToString();
        gameState = 0;
    }

    public void Retry()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void Exit()
    {
        Application.Quit();
    }
}
