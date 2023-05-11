using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BombTowerMenu : MonoBehaviour
{
    Quaity Quaity;
    GameManager GameManager;
    public GameObject _upgradeButton;
    public GameObject SellButton;
    public GameObject BombTower;
    GameObject bombObjList;
    public int[] BombTowerUpgradeMoneyList;
    public int Count;
    public int CountCheck;
    public bool BombTowerClicked;
    public Image MaxlevelImage;
    public Button BombTowerUpgradeButton;
    public List<GameObject> BombObjList = new List<GameObject>();

    public TextMeshProUGUI BombTowerUpgradeMoneyText;

    void Start()
    {
        BombTowerClicked = false;
        _upgradeButton.SetActive(false);
        SellButton.SetActive(false);
        Count = 0;
        BombObjList[0].SetActive(true);
        Quaity = FindObjectOfType<Quaity>();
        GameManager = FindObjectOfType<GameManager>();
    }

    private void OnMouseDown()
    {

        if (BombTowerClicked == false)
        {
            _upgradeButton.SetActive(true);
            SellButton.SetActive(true);
            BombTowerClicked = true;
        }
        else
        {
            _upgradeButton.SetActive(false);
            SellButton.SetActive(false);
            BombTowerClicked = false;
        }
        Debug.Log("çalıştııııı");
        
    }

    void Update()
    {

        if (Count <= 2)
        {
            bombObjList = BombObjList[Count];
        }

        CountCheck = Count;

        if (bombObjList != null)
        {
            if (Count == 0)
            {
                BombTower = BombObjList[0];
                BombObjList[0].SetActive(true);
                BombObjList[1].SetActive(false);
                BombObjList[2].SetActive(false);

            }
            if (Count == 1)
            {
                BombTower = BombObjList[1];
                BombObjList[0].SetActive(false);
                BombObjList[1].SetActive(true);
                BombObjList[2].SetActive(false);

            }
            if (Count == 2)
            {
                BombTower = BombObjList[2];
                BombObjList[0].SetActive(false);
                BombObjList[1].SetActive(false);
                BombObjList[2].SetActive(true);

            }
        }

        if (Quaity._coinText >= GameManager._bombTowerUpgradeMoney[0]._bombTowerUpgradeMoney && CountCheck == 0)
        {
            BombTowerUpgradeButton.interactable = true;
            MaxlevelImage.gameObject.SetActive(false);
            BombTowerUpgradeMoneyText.text = GameManager._bombTowerUpgradeMoney[0].ToString();
        }
        else if (Quaity._coinText >= GameManager._bombTowerUpgradeMoney[1]._bombTowerUpgradeMoney && CountCheck == 1)
        {
            BombTowerUpgradeButton.interactable = true;
            MaxlevelImage.gameObject.SetActive(false);
            BombTowerUpgradeMoneyText.text = GameManager._bombTowerUpgradeMoney[1].ToString();
        }
        else
        {
            BombTowerUpgradeButton.interactable = false;
        }
    }

    public void UpgradeBomb()
    {
        Count++;
        Debug.Log(gameObject.name);
        BombTower = gameObject;

        if (Quaity._coinText >= GameManager._bombTowerUpgradeMoney[0]._bombTowerUpgradeMoney)
        {


            if (CountCheck == 0)
            {
                Quaity.BombTowerUpgradeMoney(GameManager._bombTowerUpgradeMoney[0]._bombTowerUpgradeMoney);
                Debug.Log("BombCountcheck = " + CountCheck);
            }

            if (CountCheck == 1)
            {
                _upgradeButton.gameObject.SetActive(false);
                MaxlevelImage.gameObject.SetActive(true);
                Quaity.BombTowerUpgradeMoney(GameManager._bombTowerUpgradeMoney[1]._bombTowerUpgradeMoney);
                Debug.Log("BombCountcheck = " + CountCheck);
            }
        }
    }

    public void BombTowerSell()
    {
        

        if (CountCheck == 0)
        {
            Quaity.SellTower(GameManager._bombTowerMoneySell[0]._bombTowerMoneySell);
        }

        if (CountCheck == 1)
        {
            Quaity.SellTower(GameManager._bombTowerMoneySell[1]._bombTowerMoneySell);
        }

        if (CountCheck == 2)
        {
            Quaity.SellTower(GameManager._bombTowerMoneySell[2]._bombTowerMoneySell);
        }
        Destroy(gameObject);
    }
}
