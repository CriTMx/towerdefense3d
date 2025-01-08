using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStateHandler : MonoBehaviour
{
    public static GameStateHandler instance;

    private void Awake()
    {
        if (instance != null) return;
        instance = this;
    }

    public GameObject shopPanel;
    public GameObject gameOverScreen;

    public void EndGame()
    {
        GetComponent<WaveSpawner>().enableSpawning = false;
        shopPanel.SetActive(false);
        gameOverScreen.SetActive(true);
    }

    public void Retry()
    {
        SceneManager.LoadScene("GameScene");
    }
}
