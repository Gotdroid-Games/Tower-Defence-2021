using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BombTowerMenu : MonoBehaviour
{
    Quaity Quaity;
    GameManager GameManager;
    public GameObject towerUI;
    public GameObject tower;
    TowerUIManager towerUIManager;
    public GameObject _upgradeButton;
    public GameObject SellButton;
    public GameObject BombTower;
    public GameObject canvas;
    GameObject bombObjList;
    public int[] BombTowerUpgradeMoneyList;
    public int Count;
    public int bombTowerCountCheck;
    public bool bombTowerClicked;
    public Image MaxlevelImage;
    public Button BombTowerUpgradeButton;
    public List<GameObject> BombObjList = new List<GameObject>();
    public TextMeshProUGUI BombTowerUpgradeMoneyText;

    Dictionary<GameObject, GameObject> towerUIDictionary = new Dictionary<GameObject, GameObject>();

    void Start()
    {
        MaxlevelImage.gameObject.SetActive(false);
        bombTowerClicked = false;
       // canvas.SetActive(false);
       // _upgradeButton.SetActive(false);
        //SellButton.SetActive(false);
        Count = 0;
        BombObjList[0].SetActive(true);
        Quaity = FindObjectOfType<Quaity>();
        GameManager = FindObjectOfType<GameManager>();
        towerUIManager = FindObjectOfType<TowerUIManager>();
    }
    private void OnMouseDown()
    {
        Debug.Log("on mouse downçalıştıı");
        towerUIManager.SetActiveTowerUI(tower, towerUI);
        if (bombTowerClicked == false)
        {
            
             towerUI.SetActive(true);
            /*
            _upgradeButton.SetActive(true);
            SellButton.SetActive(true);
             */
            bombTowerClicked = true;
           
        }
        else
        {
           // towerUIManager.DeactivateTowerUI(tower);
             towerUI.SetActive(false);
            /*
            _upgradeButton.SetActive(false);
            SellButton.SetActive(false);
            MaxlevelImage.gameObject.SetActive(false);
             */
            bombTowerClicked = false;
        }

      
       
        
    }

    void Update()
    {

        if (Count <= 2)
        {
            bombObjList = BombObjList[Count];
        }

        bombTowerCountCheck = Count;

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

            if (Count == 2 && bombTowerClicked == true)
            {
                _upgradeButton.SetActive(false);
                MaxlevelImage.gameObject.SetActive(true);
            }
            else
            {
                MaxlevelImage.gameObject.SetActive(false);
            }
        }

        if (Quaity._coinText >= GameManager.TowerVaribles[1].TowerMoneyUpgradeLevel1 && bombTowerCountCheck == 0)
        {
            BombTowerUpgradeButton.interactable = true;
            BombTowerUpgradeMoneyText.text = GameManager.TowerVaribles[1].TowerMoneyUpgradeLevel1.ToString();
        }
        else if (Quaity._coinText >= GameManager.TowerVaribles[1].TowerMoneyUpgradeLevel2 && bombTowerCountCheck == 1)
        {
            BombTowerUpgradeButton.interactable = true;
            BombTowerUpgradeMoneyText.text = GameManager.TowerVaribles[1].TowerMoneyUpgradeLevel2.ToString();
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
        bombTowerClicked = false;

        if (Quaity._coinText >= GameManager.TowerVaribles[1].TowerMoneyUpgradeLevel1)

            _upgradeButton.SetActive(false);
        SellButton.SetActive(false);

        if (Quaity._coinText >= GameManager.TowerVaribles[1].TowerMoneyUpgradeLevel1)
        {


            if (bombTowerCountCheck == 0)
            {
                Quaity.BombTowerUpgradeMoney(GameManager.TowerVaribles[1].TowerMoneyUpgradeLevel1);
                Debug.Log("BombCountcheck = " + bombTowerCountCheck);
            }

            if (bombTowerCountCheck == 1)
            {
                _upgradeButton.gameObject.SetActive(false);
                Quaity.BombTowerUpgradeMoney(GameManager.TowerVaribles[1].TowerMoneyUpgradeLevel2);
                Debug.Log("BombCountcheck = " + bombTowerCountCheck);
            }
        }
    }

    public void BombTowerSell()
    {


        if (bombTowerCountCheck == 0)
        {
            Quaity.SellTower(GameManager.TowerVaribles[1].TowerMoneySellLevel1);
        }

        if (bombTowerCountCheck == 1)
        {
            Quaity.SellTower(GameManager.TowerVaribles[1].TowerMoneySellLevel2);
        }

        if (bombTowerCountCheck == 2)
        {
            Quaity.SellTower(GameManager.TowerVaribles[1].TowerMoneySellLevel3);
        }
        Destroy(gameObject);
    }
}
