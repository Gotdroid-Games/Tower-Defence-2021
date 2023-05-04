using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelCompletionController : MonoBehaviour
{
    public void LevelComplete(int level)
    {
        LevelController.Levels[level] = true;
        SceneManager.LoadScene(1);
    }

    public void Level20Complete()
    {
        SceneManager.LoadScene(1);
    }
}
