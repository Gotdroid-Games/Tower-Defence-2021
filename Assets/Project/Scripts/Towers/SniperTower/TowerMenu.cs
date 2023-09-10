using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;

public class TowerMenu : MonoBehaviour
{
    //Referanslar
    GameManager GameManager;
    TowerTarget TowerTarget;
    GameUI GameUI;
    Enemy Enemy;
    GameObject touchObjList;
    public EnemyManager.TowerType TowerType;

    //UI Elemanlarý
    public GameObject UpgradeButton1;
    public GameObject Tower;
    public GameObject SellButton;
    public GameObject towerUI;
    public GameObject canvas;
    public GameObject rangeindicator;
    public List<GameObject> TouchObjList = new List<GameObject>();
    public Button SniperTowerUpgradeButton;
    public Image MaxlevelImage;
    public TextMeshProUGUI SniperTowerUpgradeMoneyText;

    //Durum Bilgileri
    public bool TowerClicked;

    //Niþancý Kulesi Özellikleri 
    public int sniperTowerCount;
    public int sniperTowerCountCheck;
    public int sniperTowerDamage;
    public int sniperTowerDamageIncreasePercentage;
    public int sniperTowerRange;


    private void Start()
    {
        //Referans Tanýmlamalarý
        sniperTowerCount = 0;
        TowerClicked = false;
        TouchObjList[0].SetActive(true);
        TowerTarget = FindObjectOfType<TowerTarget>();
        GameManager = FindObjectOfType<GameManager>();
        Enemy = FindObjectOfType<Enemy>();
        GameUI = FindObjectOfType<GameUI>();

        //Kule Hasar ve Menzil Tanýmlamalarý
        sniperTowerDamage = GameManager.TowerVaribles[0].TowerDamage;
        sniperTowerRange = GameManager.TowerVaribles[0].TowerRange;

        
    }

    private void OnMouseDown()
    {
        if (TowerClicked == false)
        {
            towerUI.SetActive(true);
            UpgradeButton1.SetActive(true);
            SellButton.SetActive(true);
            TowerClicked = true;
        }
        else
        {
            //UpgradeButton1.SetActive(false);
            //SellButton.SetActive(false);
            //TowerRangeController.MaxLevelButton.gameObject.SetActive(false);
            towerUI.SetActive(false);
            rangeindicator.SetActive(false);
            TowerClicked = false;

        }
    }
    private void Update()
    {
        sniperTowerDamageIncreasePercentage = (sniperTowerDamage * GameManager.TowerVaribles[0].TowerDamage*2/* TowerDamage*2 deðeri yüzdeliðin 2 katýný alýyor */) / 100;
        rangeindicator.transform.localScale = new Vector3(sniperTowerRange*2, 0, sniperTowerRange*2);
        Clickdetector();

        if (sniperTowerCount <= 2)
        {
            touchObjList = TouchObjList[sniperTowerCount];
            sniperTowerCountCheck = sniperTowerCount;

            TouchObjList[0].SetActive(sniperTowerCount == 0);
            TouchObjList[1].SetActive(sniperTowerCount == 1);
            TouchObjList[2].SetActive(sniperTowerCount == 2);

            Tower = TouchObjList[sniperTowerCount];
        }

        if (sniperTowerCount == 2)
        {
            UpgradeButton1.SetActive(false);

        }
        else
        {
            UpgradeButton1.SetActive(TowerClicked);
            rangeindicator.SetActive(TowerClicked);
        }

        MaxlevelImage.gameObject.SetActive(sniperTowerCount == 2 && TowerClicked);
        rangeindicator.SetActive(TowerClicked);

        if (sniperTowerCountCheck == 0 && GameUI._coinText >= GameManager.TowerVaribles[0].TowerMoneyUpgradeLevel1)
        {
            SniperTowerUpgradeButton.interactable = true;
            SniperTowerUpgradeMoneyText.text = GameManager.TowerVaribles[0].TowerMoneyUpgradeLevel1.ToString();
        }
        else if (sniperTowerCountCheck == 1 && GameUI._coinText >= GameManager.TowerVaribles[0].TowerMoneyUpgradeLevel2)
        {
            SniperTowerUpgradeButton.interactable = true;
            SniperTowerUpgradeMoneyText.text = GameManager.TowerVaribles[0].TowerMoneyUpgradeLevel2.ToString();
        }
        else
        {
            SniperTowerUpgradeButton.interactable = false;
        }

        SellButton.SetActive(TowerClicked);
    }



    public void Upgrade()
    {
        sniperTowerCount++;
        Tower = gameObject;
        TowerClicked = false;
        Debug.Log(gameObject.name);
        //if (Quaity._coinText >= GameManager.TowerVaribles[0].TowerMoneyUpgradeLevel1)

        UpgradeButton1.SetActive(false);
        SellButton.SetActive(false);
        rangeindicator.SetActive(false);
        if (GameUI._coinText >= GameManager.TowerVaribles[0].TowerMoneyUpgradeLevel1)

        {
            if (sniperTowerCountCheck == 0)
            {
                GameUI.DecreaseCoinValue(GameManager.TowerVaribles[0].TowerMoneyUpgradeLevel1);
                sniperTowerDamage += GameManager.TowerVaribles[0].TowerDamageIncreaseValueLevel1;
                sniperTowerRange += GameManager.TowerVaribles[0].TowerDamageIncreaseValueLevel1;
            }

            if (sniperTowerCountCheck == 1)
            {
                GameUI.DecreaseCoinValue(GameManager.TowerVaribles[0].TowerMoneyUpgradeLevel2);
                sniperTowerDamage += GameManager.TowerVaribles[0].TowerDamageIncreaseValueLevel2;
                sniperTowerRange += GameManager.TowerVaribles[0].TowerRangeIncreaseValueLevel2;
            }
        }
    }

    public void SniperTowerSell()
    {
        Destroy(gameObject);

        if (sniperTowerCount == 0)
        {
            GameUI.IncreaseCoinValue(GameManager.TowerVaribles[0].TowerMoneySellLevel1);
        }

        if (sniperTowerCount == 1)
        {
            GameUI.IncreaseCoinValue(GameManager.TowerVaribles[0].TowerMoneySellLevel2);
        }

        if (sniperTowerCount == 2)
        {
            GameUI.IncreaseCoinValue(GameManager.TowerVaribles[0].TowerMoneySellLevel3);
        }
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
                if (hit.collider.gameObject == gameObject || hit.collider.gameObject == UpgradeButton1 || hit.collider.gameObject == SellButton || hit.collider.gameObject == rangeindicator)
                {
                    Debug.Log("objeye týklandý");
                    isClickedOnGameObject = true;
                    towerUI.SetActive(true);
                    rangeindicator.SetActive(true);
                    rangeindicator.transform.position = transform.position;

                }
            }

            if (!isClickedOnGameObject && TowerClicked == true)
            {
                Debug.Log("Baþka bir yere týklandý");
                TowerClicked = false;
                towerUI.SetActive(false);
                rangeindicator.SetActive(false);

            }
        }
    }

    public void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, sniperTowerRange);
    }
}
