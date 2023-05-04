using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelController : MonoBehaviour
{
    public Button[] LevelCompleteButtons = new Button[20];
    public static bool[] Levels = new bool[20];

    private void Start()
    {
        Levels[0] = true;
    }

    private void Update()
    {
        for (int i = 1; i < Levels.Length; i++)
        {
            LevelCompleteButtons[i].interactable = Levels[i];
        }
    }
}
