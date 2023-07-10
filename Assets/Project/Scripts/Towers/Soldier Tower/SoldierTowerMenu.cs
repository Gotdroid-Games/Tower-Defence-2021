using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SoldierTowerMenu : MonoBehaviour
{
    [Header("References")]
    GameManager gameManager;
    GameUI GameUI;

    [Header("GameObjects")]
    public GameObject TowerUI;
    public GameObject upgradeButton;
    public GameObject sellButton;
    public GameObject soldilerTower;
    public GameObject rangeIndicator;
    GameObject soldierObjList;
    public Button soldierTowerUpgradeButton;
    public TextMeshProUGUI soldierTowerUpgradeMoneyText;
    public Image maxLevelImage;
    public List<GameObject> soldierList = new List<GameObject>();

    [Header("Veriables")]
    public int Count;
    public int soldierTowerCountCheck;
    public int soldierDamage;
    public int soldierRange; // Bu menzil deðeri, asker robotlara aittir. Düþman robotlar, asker robotlarýmýzýn menziline girdiðinde düþman robotlarý olduðu yerde durur ve asker robotlarýmýz düþman robotlara doðru hareket edip saldýrýya geçer
    public int soldierTowerRange; // Bu menzil deðeri, kuleye aittir. Asker robotlarýn en fazla hangi konuma gidebileceðini gösterir ve sýnýrlar.
    public bool soldierTowerClicked;

    public EnemyManager.TowerType TowerType;


    private void Start()
    {
        maxLevelImage.gameObject.SetActive(false);
        soldierTowerClicked = false;
        Count = 0;
        soldierList[0].SetActive(true);

        gameManager = FindObjectOfType<GameManager>();
        GameUI.FindObjectOfType<GameUI>();
    }

    private void OnMouseDown()
    {
        if (soldierTowerClicked == false)
        {
            TowerUI.SetActive(true);
            soldierTowerClicked = true;
        }
        else
        {
            TowerUI.SetActive(false);
            soldierTowerClicked = false;
            rangeIndicator.SetActive(false);
        }
    }

    private void Update()
    {
        //Clickdetector();
        if (Count <= 2)
        {
            soldilerTower = soldierList[Count];
            soldierTowerCountCheck = Count;

            soldierList[0].SetActive(Count == 0);
            soldierList[1].SetActive(Count == 1);
            soldierList[2].SetActive(Count == 2);
        }

        if (Count == 2)
        {
            upgradeButton.SetActive(false);
        }
        else
        {
            upgradeButton.SetActive(soldierTowerClicked);
            rangeIndicator.SetActive(soldierTowerClicked);
        }
        maxLevelImage.gameObject.SetActive(Count == 2 && soldierTowerClicked);

        if (soldierTowerCountCheck == 0 && GameUI._coinText >= gameManager.TowerVaribles[3].TowerMoneyUpgradeLevel1)
        {
            soldierTowerUpgradeButton.interactable = true;
            soldierTowerUpgradeMoneyText.text = gameManager.TowerVaribles[3].TowerMoneyUpgradeLevel1.ToString();
        }
        else if (soldierTowerCountCheck == 1 && GameUI._coinText >= gameManager.TowerVaribles[3].TowerMoneyUpgradeLevel2)
        {
            soldierTowerUpgradeButton.interactable = true;
            soldierTowerUpgradeMoneyText.text = gameManager.TowerVaribles[3].TowerMoneyUpgradeLevel2.ToString();
        }
        else
        {
            soldierTowerUpgradeButton.interactable = false;
        }

        sellButton.SetActive(soldierTowerClicked);
    }

    public void SoldierUpgradeButton()
    {
        Count++;
        Debug.Log(gameObject.name);
        soldilerTower = gameObject;
        soldierTowerClicked = false;

        upgradeButton.SetActive(false);
        sellButton.SetActive(false);

        if (GameUI._coinText >= gameManager.TowerVaribles[3].TowerMoneyUpgradeLevel1)
        {
            if(soldierTowerCountCheck==0)
            {
                GameUI.DecreaseCoinValue(gameManager.TowerVaribles[3].TowerMoneyUpgradeLevel1);
                soldierDamage += gameManager.TowerVaribles[3].TowerDamageIncreaseValueLevel1;
                soldierTowerRange += gameManager.TowerVaribles[3].TowerRangeIncreaseValueLevel1;
            }
            
            if(soldierTowerCountCheck==1)
            {
                GameUI.DecreaseCoinValue(gameManager.TowerVaribles[3].TowerMoneyUpgradeLevel2);
                soldierDamage += gameManager.TowerVaribles[3].TowerDamageIncreaseValueLevel2;
                soldierTowerRange += gameManager.TowerVaribles[3].TowerRangeIncreaseValueLevel2;
            }
        }
    }

    public void SoldierTowerSell()
    {
        if (soldierTowerCountCheck == 0)
        {
            GameUI.IncreaseCoinValue(gameManager.TowerVaribles[3].TowerMoneySellLevel1);
        }

        if (soldierTowerCountCheck == 1)
        {
            GameUI.IncreaseCoinValue(gameManager.TowerVaribles[3].TowerMoneySellLevel2);
        }

        if (soldierTowerCountCheck == 2)
        {
            GameUI.IncreaseCoinValue(gameManager.TowerVaribles[3].TowerMoneySellLevel3);
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
                if (hit.collider.gameObject == gameObject || hit.collider.gameObject == upgradeButton || hit.collider.gameObject == sellButton)
                {
                    isClickedOnGameObject = true;
                    TowerUI.SetActive(true);
                    rangeIndicator.SetActive(true);
                    rangeIndicator.transform.position = transform.position;
                }
            }

            if (!isClickedOnGameObject && soldierTowerClicked == true)
            {
                soldierTowerClicked = false;
                TowerUI.SetActive(false);
                rangeIndicator.SetActive(false);
            }
        }
    }
}