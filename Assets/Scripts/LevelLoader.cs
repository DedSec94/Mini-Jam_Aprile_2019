using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public int sceneIndex;

    public void Load()
    {
        SceneManager.LoadScene(sceneIndex);
    }

    public void SceneExit()
    {
        Application.Quit();
    }
}
