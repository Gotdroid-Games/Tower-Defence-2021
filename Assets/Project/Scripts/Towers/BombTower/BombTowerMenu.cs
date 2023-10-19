using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BombTowerMenu : MonoBehaviour
{
    GameManager GameManager;
    GameUI GameUI;
    public Node Node;
    public GameObject towerUI;
    public GameObject _upgradeButton;
    public GameObject SellButton;
    public GameObject BombTower;
    public GameObject canvas;
    public GameObject rangeIndicator;
    GameObject bombObjList;
    public int Count;
    public int bombTowerCountCheck;
    public int bombTowerDamage;
    public int bombTowerRange;
    public int bombTowerDamageIncreasePercentage;
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
        GameManager = FindObjectOfType<GameManager>();
        GameUI = FindObjectOfType<GameUI>();
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
        rangeIndicator.SetActive(bombTowerClicked);
        bombTowerDamageIncreasePercentage = (bombTowerDamage * GameManager.TowerVaribles[1].TowerDamage * 2) / 100;
        rangeIndicator.transform.localScale = new Vector3(bombTowerRange * 2, 0.5f, bombTowerRange * 2);
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

        if (bombTowerCountCheck == 0 && GameUI._coinText >= GameManager.TowerVaribles[1].TowerMoneyUpgradeLevel1)
        {
            BombTowerUpgradeButton.interactable = true;
            BombTowerUpgradeMoneyText.text = GameManager.TowerVaribles[1].TowerMoneyUpgradeLevel1.ToString();
        }
        else if (bombTowerCountCheck == 1 && GameUI._coinText >= GameManager.TowerVaribles[1].TowerMoneyUpgradeLevel2)
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

        if (GameUI._coinText >= GameManager.TowerVaribles[1].TowerMoneyUpgradeLevel1)
        {
            if (bombTowerCountCheck == 0)
            {
                GameUI.DecreaseCoinValue(GameManager.TowerVaribles[1].TowerMoneyUpgradeLevel1);
                bombTowerDamage += GameManager.TowerVaribles[1].TowerDamageIncreaseValueLevel1;
                bombTowerRange += GameManager.TowerVaribles[1].TowerRangeIncreaseValueLevel1;
                Debug.Log("BombCountcheck = " + bombTowerCountCheck);
            }

            if (bombTowerCountCheck == 1)
            {
                GameUI.DecreaseCoinValue(GameManager.TowerVaribles[1].TowerMoneyUpgradeLevel2);
                bombTowerDamage += GameManager.TowerVaribles[1].TowerDamageIncreaseValueLevel2;
                bombTowerRange += GameManager.TowerVaribles[1].TowerRangeIncreaseValueLevel2;
                Debug.Log("BombCountcheck = " + bombTowerCountCheck);
            }
        }
    }

    public void BombTowerSell()
    {
        Node.towerBuildControl = false;
        if (bombTowerCountCheck == 0)
        {
            GameUI.IncreaseCoinValue(GameManager.TowerVaribles[1].TowerMoneySellLevel1);
        }

        if (bombTowerCountCheck == 1)
        {
            GameUI.IncreaseCoinValue(GameManager.TowerVaribles[1].TowerMoneySellLevel2);
        }

        if (bombTowerCountCheck == 2)
        {
            GameUI.IncreaseCoinValue(GameManager.TowerVaribles[1].TowerMoneySellLevel3);
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
                if (hit.collider.gameObject == gameObject || hit.collider.gameObject == _upgradeButton || hit.collider.gameObject == SellButton || hit.collider.gameObject == rangeIndicator)
                {
                    Debug.Log("objeye tıklandı");
                    isClickedOnGameObject = true;
                    towerUI.SetActive(true);
                    rangeIndicator.SetActive(true);
                    rangeIndicator.transform.position = transform.position;
                }
            }

            if (!isClickedOnGameObject && bombTowerClicked == true)
            {
                Debug.Log("Başka bir yere tıklandı");
                bombTowerClicked = false;
                towerUI.SetActive(false);
                rangeIndicator.SetActive(false);
            }
        }
    }
}
