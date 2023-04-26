using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelController : MonoBehaviour
{
    public Button[] LevelCompleteButtons = new Button[21];
    public static bool[] Levels =new bool[21];

    private void Start()
    {
        Levels[0]= true;
    }

    private void Update()
    {
        if (Levels[1] == true)
        {
            LevelCompleteButtons[1].interactable = true;
        }

        if (Levels[2] == true)
        {
            LevelCompleteButtons[2].interactable = true;
        }

        if (Levels[3] == true)  
        {
            LevelCompleteButtons[3].interactable= true;
        }

        if (Levels[4] == true) 
        {
            LevelCompleteButtons[4].interactable = true;
        }

        if (Levels[5] == true)
        {
            LevelCompleteButtons[5].interactable = true;
        }

        if (Levels[6] == true)
        {
            LevelCompleteButtons[6].interactable = true;
        }

        if (Levels[7] == true)
        {
            LevelCompleteButtons[7].interactable = true;
        }

        if (Levels[8] == true)
        {
            LevelCompleteButtons[8].interactable = true;
        }

        if (Levels[9] == true)
        {
            LevelCompleteButtons[9].interactable = true;
        }

        if (Levels[10] == true)
        {
            LevelCompleteButtons[10].interactable = true;
        }

        if (Levels[11] == true)
        {
            LevelCompleteButtons[11].interactable = true;
        }

        if (Levels[12] == true)
        {
            LevelCompleteButtons[12].interactable = true;
        }

        if (Levels[13] == true)
        {
            LevelCompleteButtons[13].interactable = true;
        }

        if (Levels[14] == true)
        {
            LevelCompleteButtons[14].interactable = true;
        }

        if (Levels[15] == true)
        {
            LevelCompleteButtons[15].interactable = true;
        }

        if (Levels[16] == true)
        {
            LevelCompleteButtons[16].interactable = true;
        }

        if (Levels[17] == true)
        {
            LevelCompleteButtons[17].interactable = true;
        }

        if (Levels[18] == true)
        {
            LevelCompleteButtons[18].interactable = true;
        }

        if (Levels[19] == true)
        {
            LevelCompleteButtons[19].interactable = true;
        }

        if (Levels[20] == true)
        {
            LevelCompleteButtons[20].interactable = true;
        }
    }
}
