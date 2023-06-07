using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;

public class TowerMenu : MonoBehaviour
{
    //Referanslar
    TowerRangeController TowerRangeController;
    GameManager GameManager;
    TowerTarget TowerTarget;
    Enemy Enemy;
    Quaity Quaity;
    GameObject touchObjList;
    public EnemyManager.TowerType TowerType;

    //UI Elemanlarý
    public GameObject UpgradeButton1;
    public GameObject Tower;
    public GameObject SellButton;
    public GameObject towerUI;
    public List<GameObject> TouchObjList = new List<GameObject>();
    public GameObject sniperTower;
    public Button SniperTowerUpgradeButton;
    public Image MaxlevelImage;
    public TextMeshProUGUI SniperTowerUpgradeMoneyText;

    //Durum Bilgileri
    public bool TowerClicked;
    private bool sniperTowerDamageUpgradeLevel1 = false;
    private bool sniperTowerDamageUpgradeLevel2 = false;

    //Niþancý Kulesi Özellikleri 
    public int sniperTowerCount;
    public int sniperTowerCountCheck;
    public int sniperTowerDamage;
    public int sniperTowerRange;

    
    private void Start()
    {
        //Referans Tanýmlamalarý
        sniperTowerCount = 0;
        TowerClicked = false;
        TouchObjList[0].SetActive(true);
        TowerTarget = FindObjectOfType<TowerTarget>();
        Quaity = FindObjectOfType<Quaity>();
        GameManager = FindObjectOfType<GameManager>();
        Enemy = FindObjectOfType<Enemy>();

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
            TowerClicked = false;
        }
    }
    private void Update()
    {
        Clickdetector();
        //TowerRangeController = FindObjectOfType<TowerRangeController>();
        //sniperTowerCountCheck = TowerRangeController.sniperTowerCounts;

        if (sniperTowerCount<=2)
        {
            touchObjList = TouchObjList[sniperTowerCount];
            sniperTowerCountCheck = sniperTowerCount;

            TouchObjList[0].SetActive(sniperTowerCount == 0);
            TouchObjList[1].SetActive(sniperTowerCount == 1);
            TouchObjList[2].SetActive(sniperTowerCount == 2);
        }

        if (sniperTowerCount == 2)
        {
            UpgradeButton1.SetActive(false);
        }
        else
        {
            UpgradeButton1.SetActive(TowerClicked);
        }

        MaxlevelImage.gameObject.SetActive(sniperTowerCount == 2 && TowerClicked);

        if (sniperTowerCountCheck == 0 && Quaity._coinText >= GameManager.TowerVaribles[0].TowerMoneyUpgradeLevel1)
        {
            SniperTowerUpgradeButton.interactable = true;
            SniperTowerUpgradeMoneyText.text = GameManager.TowerVaribles[0].TowerMoneyUpgradeLevel1.ToString();
        }
        else if (sniperTowerCountCheck == 1 && Quaity._coinText >= GameManager.TowerVaribles[0].TowerMoneyUpgradeLevel2)
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
        if (Quaity._coinText >= GameManager.TowerVaribles[0].TowerMoneyUpgradeLevel1)

        //UpgradeButton1.SetActive(false);
        //SellButton.SetActive(false);
        if (Quaity._coinText >= GameManager.TowerVaribles[0].TowerMoneyUpgradeLevel1)

        {
            if (sniperTowerCount == 0)
            {
                sniperTowerDamage += GameManager.TowerVaribles[0].TowerDamageIncreaseValueLevel1;
                sniperTowerRange += GameManager.TowerVaribles[0].TowerDamageIncreaseValueLevel1;
                Quaity.TowerUpgradeMoney(GameManager.TowerVaribles[0].TowerMoneyUpgradeLevel1);
                Debug.Log("Countcheck 0");
            }

            if (sniperTowerCount == 1)
            {
                sniperTowerDamage += GameManager.TowerVaribles[0].TowerDamageIncreaseValueLevel2;
                sniperTowerRange += GameManager.TowerVaribles[0].TowerRangeIncreaseValueLevel2;
                sniperTowerDamageUpgradeLevel1 = true;
                Quaity.TowerUpgradeMoney(GameManager.TowerVaribles[0].TowerMoneyUpgradeLevel2);
                Debug.Log("Countcheck 1");
            }

           
        }
    }

    public void SniperTowerSell()
    {
        Destroy(gameObject);

        if (sniperTowerCount == 0)
        {
            Quaity.SellTower(GameManager.TowerVaribles[0].TowerMoneySellLevel1);
        }

        if (sniperTowerCount == 1)
        {
            Quaity.SellTower(GameManager.TowerVaribles[0].TowerMoneySellLevel2);
        }

        if (sniperTowerCount == 2)
        {
            Quaity.SellTower(GameManager.TowerVaribles[0].TowerMoneySellLevel3);
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
                if (hit.collider.gameObject == gameObject || hit.collider.gameObject == UpgradeButton1 || hit.collider.gameObject == SellButton)
                {
                    Debug.Log("objeye týklandý");

                    if (sniperTowerCount != 2)
                    {
                        UpgradeButton1.SetActive(true);

                    }
                    SellButton.SetActive(true);
                    // bombmenu.towerUI.SetActive(true);
                    isClickedOnGameObject = true;

                }
            }

            if (!isClickedOnGameObject)
            {
                Debug.Log("Baþka bir yere týklandý");
                UpgradeButton1.SetActive(false);
                SellButton.SetActive(false);
            }
        }


    }

    //public void OnDrawGizmos()
    //{
    //    Gizmos.color = Color.green;
    //    Gizmos.DrawWireSphere(transform.position, sniperTowerRange);
    //}
}
