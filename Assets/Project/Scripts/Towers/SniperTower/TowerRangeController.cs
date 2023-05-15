using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TowerRangeController : MonoBehaviour
{
    Quaity Quaity;
    RangeUpgrade RangeUpgrade;
    GameManager GameManager;
    public List<GameObject> UIController = new List<GameObject>();
    public List<GameObject> TouchObjList = new List<GameObject>();
    public Button UpgradeButton;
    public Image MaxLevelButton;
    GameObject touchGameObj;
    public TextMeshProUGUI SniperTowerUpgradeMoneyText;
    public int counts;
    public int countcheck;
    
    

    TowerMenu TowerMenu;


    private void Start()
    {
        TouchObjList[0].SetActive(true);
        TowerMenu = FindObjectOfType<TowerMenu>();
        Quaity = FindObjectOfType<Quaity>();
        RangeUpgrade = FindObjectOfType<RangeUpgrade>();
        GameManager = FindObjectOfType<GameManager>();
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



        if (Quaity._coinText >= GameManager.TowerVaribles[0].TowerMoneyUpgrade1 && RangeUpgrade.countcheck == 0)
        {
            UpgradeButton.interactable = true;
            MaxLevelButton.gameObject.SetActive(false);
            SniperTowerUpgradeMoneyText.text = GameManager.TowerVaribles[0].TowerMoneyUpgrade1.ToString();
        }
        else if (Quaity._coinText >= GameManager.TowerVaribles[0].TowerMoneyUpgrade2 && RangeUpgrade.countcheck == 1)
        {
            UpgradeButton.interactable = true;
            MaxLevelButton.gameObject.SetActive(false);
            SniperTowerUpgradeMoneyText.text = GameManager.TowerVaribles[0].TowerMoneyUpgrade2.ToString();
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
