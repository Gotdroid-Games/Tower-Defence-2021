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
    public GameObject _upgradeButton;
    public GameObject SellButton;
    public GameObject BombTower;
    public GameObject canvas;
    GameObject bombObjList;
    public int Count;
    public int bombTowerCountCheck;
    public int bombTowerDamage;
    public int bombTowerRange;
    public bool bombTowerClicked;
    public Image MaxlevelImage;
    public Button BombTowerUpgradeButton;
    public List<GameObject> BombObjList = new List<GameObject>();
    public TextMeshProUGUI BombTowerUpgradeMoneyText;
    public EnemyManager.TowerType TowerType;
    void Start()
    {
        MaxlevelImage.gameObject.SetActive(false);
        bombTowerClicked = false;
        Count = 0;
        BombObjList[0].SetActive(true);
        Quaity = FindObjectOfType<Quaity>();
        GameManager = FindObjectOfType<GameManager>();

        bombTowerDamage = GameManager.TowerVaribles[1].TowerDamage;
        bombTowerRange = GameManager.TowerVaribles[1].TowerRange;
    }
    private void OnMouseDown()
    {
        Debug.Log("on mouse downçalıştıı");
        if (bombTowerClicked == false)
        {
            towerUI.SetActive(true);
            _upgradeButton.SetActive(true);
            SellButton.SetActive(true);
            bombTowerClicked = true;
        }
        else
        {
            towerUI.SetActive(false);
            bombTowerClicked = false;
        }
    }

    void Update()
    {
        Clickdetector();
        if (Count <= 2)
        {
            bombObjList = BombObjList[Count];
            bombTowerCountCheck = Count;

            BombObjList[0].SetActive(Count == 0);
            BombObjList[1].SetActive(Count == 1);
            BombObjList[2].SetActive(Count == 2);

            BombTower = BombObjList[Count];
        }

        if (Count == 2)
        {
            _upgradeButton.SetActive(false);
        }
        else
        {
            _upgradeButton.SetActive(bombTowerClicked);
        }

        MaxlevelImage.gameObject.SetActive(Count == 2 && bombTowerClicked);

        if (bombTowerCountCheck == 0 && Quaity._coinText >= GameManager.TowerVaribles[1].TowerMoneyUpgradeLevel1)
        {
            BombTowerUpgradeButton.interactable = true;
            BombTowerUpgradeMoneyText.text = GameManager.TowerVaribles[1].TowerMoneyUpgradeLevel1.ToString();
        }
        else if (bombTowerCountCheck == 1 && Quaity._coinText >= GameManager.TowerVaribles[1].TowerMoneyUpgradeLevel2)
        {
            BombTowerUpgradeButton.interactable = true;
            BombTowerUpgradeMoneyText.text = GameManager.TowerVaribles[1].TowerMoneyUpgradeLevel2.ToString();
        }
        else
        {
            BombTowerUpgradeButton.interactable = false;
        }

        SellButton.SetActive(bombTowerClicked);
    }

    public void UpgradeBomb()
    {
        Count++;
        Debug.Log(gameObject.name);
        BombTower = gameObject;
        bombTowerClicked = false;

        _upgradeButton.SetActive(false);
        SellButton.SetActive(false);

        if (Quaity._coinText >= GameManager.TowerVaribles[1].TowerMoneyUpgradeLevel1)
        {
            if (bombTowerCountCheck == 0)
            {
                Quaity.BombTowerUpgradeMoney(GameManager.TowerVaribles[1].TowerMoneyUpgradeLevel1);
                bombTowerDamage += GameManager.TowerVaribles[1].TowerDamageIncreaseValueLevel1;
                bombTowerRange += GameManager.TowerVaribles[1].TowerRangeIncreaseValueLevel1;
                Debug.Log("BombCountcheck = " + bombTowerCountCheck);
            }

            if (bombTowerCountCheck == 1)
            {
                Quaity.BombTowerUpgradeMoney(GameManager.TowerVaribles[1].TowerMoneyUpgradeLevel2);
                bombTowerDamage += GameManager.TowerVaribles[1].TowerDamageIncreaseValueLevel2;
                bombTowerRange += GameManager.TowerVaribles[1].TowerRangeIncreaseValueLevel2;
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
                    Debug.Log("objeye tıklandı");
                    isClickedOnGameObject = true;
                    towerUI.SetActive(true);
                }
            }

            if (!isClickedOnGameObject && bombTowerClicked == true)
            {
                Debug.Log("Başka bir yere tıklandı");
                bombTowerClicked = false;
                towerUI.SetActive(false);
            }
        }
    }
}
