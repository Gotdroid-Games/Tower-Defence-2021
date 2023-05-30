using UnityEngine;
using System.Collections.Generic;
public class TowerMenu : MonoBehaviour
{
    TowerRangeController TowerRangeController;
    GameManager GameManager;
    RangeUpgrade RangeUpgrade;
    TowerTarget TowerTarget;
    Quaity Quaity;
    public GameObject UpgradeButton1;
    public GameObject Tower;
    public GameObject SellButton;
    public bool TowerClicked;
   public int sniperTowerCountCheck;

    private void Start()
    {
        TowerClicked = false;
        TowerTarget = FindObjectOfType<TowerTarget>();
        Quaity = FindObjectOfType<Quaity>();
        RangeUpgrade = GetComponent<RangeUpgrade>();
        GameManager = FindObjectOfType<GameManager>();
    }
    private void Update()
    {
        TowerRangeController = FindObjectOfType<TowerRangeController>();
        sniperTowerCountCheck = TowerRangeController.sniperTowerCounts;
        if (TowerRangeController.sniperTowerCounts >= 2)
        {
            TowerRangeController.sniperTowerCounts = 2;
        }

        if (sniperTowerCountCheck == 2 && TowerClicked == true)
        {
            TowerRangeController.MaxLevelButton.gameObject.SetActive(true);
        }
        else
        {
            TowerRangeController.MaxLevelButton.gameObject.SetActive(false);
        }
    }

    private void OnMouseDown()
    {
        var up = transform.TransformDirection(Vector3.up);
        RaycastHit hit;
        Debug.DrawRay(transform.position, -up * 2, Color.magenta);

        if (Physics.Raycast(transform.position, -up, out hit, 2))
        {
            if (hit.collider != null)
            {

                if (TowerClicked == false)
                {
                    UpgradeButton1.SetActive(true);
                    SellButton.SetActive(true);
                    TowerClicked = true;
                }
                else
                {
                    UpgradeButton1.SetActive(false);
                    SellButton.SetActive(false);
                    TowerRangeController.MaxLevelButton.gameObject.SetActive(false);
                    TowerClicked = false;
                }

                for (int i = 0; i < TowerRangeController.UIController.Count; i++)
                {
                    TowerRangeController.UIController[i].SetActive(true);
                }

                Debug.Log(hit.collider.gameObject.name);
            }
        }
    }

    public void Upgrade()
    {
        Debug.Log(gameObject.name);
        Tower = gameObject;


        if (Quaity._coinText >= GameManager.TowerVaribles[0].TowerMoneyUpgradeLevel1)

        UpgradeButton1.SetActive(false);
        SellButton.SetActive(false);
        if (Quaity._coinText >= GameManager.TowerVaribles[0].TowerMoneyUpgradeLevel1)

        {
            GetComponent<TowerRangeController>().sniperTowerCounts++;


            if (sniperTowerCountCheck == 0)
            {
                Quaity.TowerUpgradeMoney(GameManager.TowerVaribles[0].TowerMoneyUpgradeLevel1);
                Debug.Log("Countcheck 0");
            }

            if (sniperTowerCountCheck == 1)
            {
                Quaity.TowerUpgradeMoney(GameManager.TowerVaribles[0].TowerMoneyUpgradeLevel2);
                Debug.Log("Countcheck 1");
            }

            if (sniperTowerCountCheck == 2)
            {
                Quaity.TowerUpgradeMoney(0);
                Debug.Log("Countcheck 2");
            }

            

            Debug.Log("Upgrade aktif");
        }

        for (int i = 0; i < TowerRangeController.UIController.Count; i++)
        {
            TowerRangeController.UIController[i].SetActive(false);
        }

        UpgradeButton1.SetActive(false);
        SellButton.SetActive(false);
    }

    public void SniperTowerSell()
    {
        Destroy(gameObject);

        if (sniperTowerCountCheck == 0)
        {
            Quaity.SellTower(GameManager.TowerVaribles[0].TowerMoneySellLevel1);
        }

        if (sniperTowerCountCheck == 1)
        {
            Quaity.SellTower(GameManager.TowerVaribles[0].TowerMoneySellLevel2);
        }

        if (sniperTowerCountCheck == 2)
        {
            Quaity.SellTower(GameManager.TowerVaribles[0].TowerMoneySellLevel3);
        }
    }
}
