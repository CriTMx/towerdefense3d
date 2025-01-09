using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuScript : MonoBehaviour
{

    public string levelToLoad = "LevelSelect";
    public void StartGame()
    {
        SceneManager.LoadScene(levelToLoad);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
