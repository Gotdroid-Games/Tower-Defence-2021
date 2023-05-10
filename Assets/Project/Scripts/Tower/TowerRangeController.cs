using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TowerRangeController : MonoBehaviour
{
    Quaity Quaity;
    RangeUpgrade RangeUpgrade;
    WaveSpawner WaveSpawner;
    public List<GameObject> UIController = new List<GameObject>();
    public List<GameObject> TouchObjList = new List<GameObject>();
    public Button UpgradeButton;
    public Button SellButton;
    public Image MaxLevelButton;
    GameObject touchGameObj;
    public TextMeshProUGUI TowerUpgradeMoneyText;
    public int counts;
    public int countcheck;
    public int[] TowerUpgradeMoneyValue;
    
    

    TowerMenu TowerMenu;


    private void Start()
    {
        TouchObjList[0].SetActive(true);
        TowerMenu = FindObjectOfType<TowerMenu>();
        Quaity = FindObjectOfType<Quaity>();
        RangeUpgrade = FindObjectOfType<RangeUpgrade>();
        WaveSpawner = FindObjectOfType<WaveSpawner>();
    }
    private void Update()
    {
        countcheck = counts;
        if (counts <= 2)
        {
            touchGameObj = TouchObjList[counts];
        }

        if (counts >= 2)
        {
            counts = 2;
        }

        if (countcheck >= 2)
        {
            countcheck = 2;
        }

        if (touchGameObj != null)
        {
            if (counts == 0)
            {
                TowerMenu.Tower = TouchObjList[0];
                TouchObjList[0].SetActive(true);
                TouchObjList[1].SetActive(false);
                TouchObjList[2].SetActive(false);
            }

            if (counts == 1)
            {
                TowerMenu.Tower = TouchObjList[1];
                TouchObjList[0].SetActive(false);
                TouchObjList[1].SetActive(true);
                TouchObjList[2].SetActive(false);
            }

            if (counts == 2)
            {
                TowerMenu.Tower = TouchObjList[2];
                TouchObjList[0].SetActive(false);
                TouchObjList[1].SetActive(false);
                TouchObjList[2].SetActive(true);
            }
        }



        if (Quaity._coinText >= TowerUpgradeMoneyValue[0] && RangeUpgrade.countcheck == 0)
        {
            UpgradeButton.interactable = true;
            SellButton.interactable = true;
            MaxLevelButton.gameObject.SetActive(false);
            TowerUpgradeMoneyText.text = TowerUpgradeMoneyValue[0].ToString();
        }
        else if (Quaity._coinText >= TowerUpgradeMoneyValue[1] && RangeUpgrade.countcheck == 1)
        {
            UpgradeButton.interactable = true;
            SellButton.interactable = true;
            MaxLevelButton.gameObject.SetActive(false);
            TowerUpgradeMoneyText.text = TowerUpgradeMoneyValue[1].ToString();
        }
        else
        {
            UpgradeButton.interactable = false;
        }


        if (Quaity._coinText <= 0)
        {
            Quaity._coinText = 0;
        }


        if (RangeUpgrade.countcheck == 2)
        {
            UpgradeButton.gameObject.SetActive(false);
            MaxLevelButton.gameObject.SetActive(true);
        }

    }
}
