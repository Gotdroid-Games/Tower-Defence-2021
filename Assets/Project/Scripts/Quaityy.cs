using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Quaityy : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI liveText;


    

    int lives;

    private void Start()
    {
        lives = 10;
       liveText.text=lives.ToString();
    }

    //public int Lives()
    //{

    //}
}
