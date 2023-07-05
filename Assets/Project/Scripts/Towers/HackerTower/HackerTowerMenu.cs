using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HackerTowerMenu : MonoBehaviour
{
    
    GameManager gameManager;
    GameUI GameUI;

    public GameObject towerUI;
    public GameObject _upgradeButton;
    public GameObject SellButton;
    public GameObject hackerTower;
    GameObject hackerObjList;
    public List<GameObject> HackerObjList = new List<GameObject>();
    public int Count;
    public int hackerTowerCountCheck;
    public int hackerTowerDamage;
    public int hackerTowerRange;
    public bool hackerTowerClicked;
    public Button hackerTowerUpgradeButton;
    public TextMeshProUGUI hackerTowerUpgradeMoneyText;
    public Image MaxlevelImage;
    public EnemyManager.TowerType TowerType;
    private void Start()
    {
        MaxlevelImage.gameObject.SetActive(false);
        hackerTowerClicked = false;
        Count = 0;
        HackerObjList[0].SetActive(true);

        gameManager = FindObjectOfType<GameManager>();
        GameUI = FindObjectOfType<GameUI>();
    }

    private void OnMouseDown()
    {
        Debug.Log("on mouse downçalýþtýý");
        if (hackerTowerClicked == false)
        {
            towerUI.SetActive(true);
            _upgradeButton.SetActive(true);
            SellButton.SetActive(true);
            hackerTowerClicked = true;
        }
        else
        {
            towerUI.SetActive(false);
            hackerTowerClicked = false;
        }
    }

    void Update()
    {
        Clickdetector();
        if (Count <= 2)
        {
            hackerTower = HackerObjList[Count];
            hackerTowerCountCheck = Count;

            HackerObjList[0].SetActive(Count == 0);
            HackerObjList[1].SetActive(Count == 1);
            HackerObjList[2].SetActive(Count == 2);

            hackerTower = HackerObjList[Count];
        }

        if (Count == 2)
        {
            _upgradeButton.SetActive(false);
        }
        else
        {
            _upgradeButton.SetActive(hackerTowerClicked);
        }

        MaxlevelImage.gameObject.SetActive(Count == 2 && hackerTowerClicked);

        if (hackerTowerCountCheck == 0 && GameUI._coinText >= gameManager.TowerVaribles[2].TowerMoneyUpgradeLevel1)
        {
            hackerTowerUpgradeButton.interactable = true;
            hackerTowerUpgradeMoneyText.text = gameManager.TowerVaribles[2].TowerMoneyUpgradeLevel1.ToString();
        }
        else if (hackerTowerCountCheck == 1 && GameUI._coinText >= gameManager.TowerVaribles[2].TowerMoneyUpgradeLevel2)
        {
            hackerTowerUpgradeButton.interactable = true;
            hackerTowerUpgradeMoneyText.text = gameManager.TowerVaribles[2].TowerMoneyUpgradeLevel2.ToString();
        }
        else
        {
            hackerTowerUpgradeButton.interactable = false;
        }

        SellButton.SetActive(hackerTowerClicked);
    }

    public void HackerUpgradeButton()
    {
        Count++;
        Debug.Log(gameObject.name);
        hackerTower = gameObject;
        hackerTowerClicked = false;

        _upgradeButton.SetActive(false);
        SellButton.SetActive(false);

        if (GameUI._coinText >= gameManager.TowerVaribles[2].TowerMoneyUpgradeLevel1)
        {
            if (hackerTowerCountCheck == 0)
            {
                GameUI.BombTowerUpgradeMoney(gameManager.TowerVaribles[2].TowerMoneyUpgradeLevel1);
                hackerTowerDamage += gameManager.TowerVaribles[2].TowerDamageIncreaseValueLevel1;
                hackerTowerRange += gameManager.TowerVaribles[2].TowerRangeIncreaseValueLevel1;
                Debug.Log("BombCountcheck = " + hackerTowerCountCheck);
            }

            if (hackerTowerCountCheck == 1)
            {
                GameUI.BombTowerUpgradeMoney(gameManager.TowerVaribles[2].TowerMoneyUpgradeLevel2);
                hackerTowerDamage += gameManager.TowerVaribles[2].TowerDamageIncreaseValueLevel2;
                hackerTowerRange += gameManager.TowerVaribles[2].TowerRangeIncreaseValueLevel2;
                Debug.Log("BombCountcheck = " + hackerTowerCountCheck);
            }
        }
    }

    public void HackerTowerSell()
    {
        if (hackerTowerCountCheck == 0)
        {
            GameUI.SellTower(gameManager.TowerVaribles[2].TowerMoneySellLevel1);
        }

        if (hackerTowerCountCheck == 1)
        {
            GameUI.SellTower(gameManager.TowerVaribles[2].TowerMoneySellLevel2);
        }

        if (hackerTowerCountCheck == 2)
        {
            GameUI.SellTower(gameManager.TowerVaribles[2].TowerMoneySellLevel3);
        }
        Destroy(gameObject);
    }

    public void Clickdetector()
    {
        if (Input.GetMouseButtonDown(0))
        {
            bool isClickedOnGameObject = false;

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject == gameObject || hit.collider.gameObject == _upgradeButton || hit.collider.gameObject == SellButton)
                {
                    Debug.Log("objeye týklandý");
                    isClickedOnGameObject = true;
                    towerUI.SetActive(true);
                }
            }

            if (!isClickedOnGameObject && hackerTowerClicked == true)
            {
                Debug.Log("Baþka bir yere týklandý");
                hackerTowerClicked = false;
                towerUI.SetActive(false);
            }
        }
    }
}
