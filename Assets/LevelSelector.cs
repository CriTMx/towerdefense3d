using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelector : MonoBehaviour
{
    public string[] levels;

    public void LoadLevel(int levelIndex)
    {
        SceneManager.LoadScene(levels[levelIndex]);
    }
}
