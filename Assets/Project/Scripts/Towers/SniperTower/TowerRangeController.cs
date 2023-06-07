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
    public int sniperTowerCounts;
    public int sniperTowerCountCheck;
    public int bombTowerCounts;
    public int bombTowerCountCheck;



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
        sniperTowerCountCheck = sniperTowerCounts;
        if (sniperTowerCounts <= 2)
        {
            touchGameObj = TouchObjList[sniperTowerCounts];
        }

        if (sniperTowerCounts >= 2)
        {
            sniperTowerCounts = 2;
        }


        if (touchGameObj != null)
        {
            if (sniperTowerCounts == 0)
            {
                TowerMenu.Tower = TouchObjList[0];
                TouchObjList[0].SetActive(true);
                TouchObjList[1].SetActive(false);
                TouchObjList[2].SetActive(false);
            }

            if (sniperTowerCounts == 1)
            {
                TowerMenu.Tower = TouchObjList[1];
                TouchObjList[0].SetActive(false);
                TouchObjList[1].SetActive(true);
                TouchObjList[2].SetActive(false);
            }

            if (sniperTowerCounts == 2)
            {
                TowerMenu.Tower = TouchObjList[2];
                TouchObjList[0].SetActive(false);
                TouchObjList[1].SetActive(false);
                TouchObjList[2].SetActive(true);
            }
        }



        if (Quaity._coinText >= GameManager.TowerVaribles[0].TowerMoneyUpgradeLevel1 && TowerMenu.sniperTowerCount == 0)
        {
            UpgradeButton.interactable = true;
            SniperTowerUpgradeMoneyText.text = GameManager.TowerVaribles[0].TowerMoneyUpgradeLevel1.ToString();
        }
        else if (Quaity._coinText >= GameManager.TowerVaribles[0].TowerMoneyUpgradeLevel2 && TowerMenu.sniperTowerCount == 1)
        {
            UpgradeButton.interactable = true;
            SniperTowerUpgradeMoneyText.text = GameManager.TowerVaribles[0].TowerMoneyUpgradeLevel2.ToString();
        }
        else
        {
            UpgradeButton.interactable = false;
        }


        if (Quaity._coinText <= 0)
        {
            Quaity._coinText = 0;
        }


        if (TowerMenu.sniperTowerCount == 2)
        {
            UpgradeButton.gameObject.SetActive(false);
            MaxLevelButton.gameObject.SetActive(true);
        }

    }
}
