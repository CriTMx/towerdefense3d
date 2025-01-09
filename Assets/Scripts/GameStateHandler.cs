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

    public GameObject shopPanel;
    public GameObject gameOverScreen;
    public GameObject waveCountdownDisplay;

    public GameObject pauseScreen;

    public TMP_Text scoreText;

    private void Awake()
    {
        if (instance != null) return;
        instance = this;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.E))
        {
            TogglePausedState();
        }
    }

    public void TogglePausedState()
    {
        pauseScreen.SetActive(!pauseScreen.activeSelf);

        if (pauseScreen.activeSelf)
        {
            Time.timeScale = 0f;
            gameState = 2;
        }
        else
        {
            Time.timeScale = 1f;
            gameState = 2;
        }
    }

    public void ContinueGame()
    {
        TogglePausedState();
    }

    public void EndGame()
    {
        GetComponent<WaveSpawner>().enableSpawning = false;
        shopPanel.SetActive(false);
        waveCountdownDisplay.SetActive(false);
        gameOverScreen.SetActive(true);
        scoreText.text = (GetComponent<WaveSpawner>().waveNumber).ToString();
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
