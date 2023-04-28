using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Qualification : MonoBehaviour
{
    //public GameObject UpgradeImage;
    //public GameObject HeroesImage;
    //public GameObject Encyclopedia;
    //public GameObject BackButton;

    //public void UpgradeMenu()
    //{
    //    UpgradeImage.SetActive(true);
    //    BackButton.SetActive(false);
    //}
    //public void HeroesMenu()
    //{
    //    HeroesImage.SetActive(true);
    //    BackButton.SetActive(false);
    //}
    //public void EncyclopediaMenu()
    //{
    //    Encyclopedia.SetActive(true);
    //    BackButton.SetActive(false);
    //}
    // public void Exit()
    //{
    //    UpgradeImage.SetActive(false);
    //    HeroesImage.SetActive(false);
    //    Encyclopedia.SetActive(false);
    //    BackButton.SetActive(true);
    //}

    //public void BackMenu()
    //{
    //    SceneManager.LoadScene(0);
    //}

    public GameObject UpgradeImage;
    public GameObject HeroesImage;
    public GameObject Encyclopedia;
    public GameObject BackButton;

    public void UpgradeMenu()
    {
        UpgradeImage.SetActive(true);
        BackButton.SetActive(false);
    }

    public void HeroesMenu()
    {
        HeroesImage.SetActive(true);
        BackButton.SetActive(false);
    }

    public void EncyclopediaMenu()
    {
        Encyclopedia.SetActive(true);
        BackButton.SetActive(false);
    }

    public void CloseMenu(GameObject menuObject)
    {
        menuObject.SetActive(false);
        BackButton.SetActive(true);
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene(0);
    }


}
