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
    public GameObject pauseScreen;
    public GameObject completeLevelScreen;
    public GameObject waveCountdownDisplay;

    public TMP_Text scoreTextLevelFail;
    public TMP_Text scoreTextLevelClear;

    public string nextLevel = "Level2";
    public int levelToUnlock = 2;

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

    public void WinLevel()
    {
        scoreTextLevelClear.text = (GetComponent<WaveSpawner>().waveNumber).ToString();
        completeLevelScreen.SetActive(true);
    }

    public void NextLevel()
    {
        PlayerPrefs.SetInt("levelReached", levelToUnlock);
        SceneManager.LoadScene(nextLevel);
    }


    public void EndGame()
    {
        GetComponent<WaveSpawner>().enableSpawning = false;
        shopPanel.SetActive(false);
        waveCountdownDisplay.SetActive(false);
        gameOverScreen.SetActive(true);
        scoreTextLevelFail.text = (GetComponent<WaveSpawner>().waveNumber).ToString();
        
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
