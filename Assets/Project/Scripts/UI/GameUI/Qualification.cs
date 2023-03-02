using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Qualification : MonoBehaviour
{
    public GameObject UpgradeImage;
    public GameObject HeroesImage;
    public GameObject Encyclopedia;

    private void Awake()
    {
        UpgradeImage.SetActive(false);
        HeroesImage.SetActive(false);
        Encyclopedia.SetActive(false);
    }
     
    public void UpgradeMenu()
    {
        UpgradeImage.SetActive(true);
    }
    public void HeroesMenu()
    {
        HeroesImage.SetActive(true);
    }
    public void EncyclopediaMenu()
    {
        Encyclopedia.SetActive(true);
    }
     public void Exit()
    {
        UpgradeImage.SetActive(false);
        HeroesImage.SetActive(false);
        Encyclopedia.SetActive(false);
    }

    
}
