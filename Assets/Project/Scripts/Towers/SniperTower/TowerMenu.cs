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
    int countcheck;
    
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
        countcheck = TowerRangeController.counts;
        if (TowerRangeController.counts >= 2)
        {
            TowerRangeController.counts = 2;
        }

       
    }

    private void OnMouseDown()
    {
        var up = transform.TransformDirection(Vector3.up);
        RaycastHit hit;
        Debug.DrawRay(transform.position, -up * 2, Color.green);

        if (Physics.Raycast(transform.position, -up, out hit, 2))
        {
            if (hit.collider != null)
            {

                if (TowerClicked==false)
                {
                    UpgradeButton1.SetActive(true);
                    SellButton.SetActive(true);
                    TowerClicked = true;
                }
                else
                {
                    UpgradeButton1.SetActive(false);
                    SellButton.SetActive(false);
                    TowerClicked = false;
                }

                for (int i = 0; i < TowerRangeController.UIController.Count; i++ )
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

        UpgradeButton1.SetActive(false);
        SellButton.SetActive(false);
        if (Quaity._coinText >= GameManager._sniperTowerUpgradeMoney[0]._sniperTowerUpgradeMoney)
        {
            GetComponent<TowerRangeController>().counts++;
            

            if(countcheck==0)
            {
                Quaity.TowerUpgradeMoney(GameManager._sniperTowerUpgradeMoney[0]._sniperTowerUpgradeMoney);
                Debug.Log("Countcheck 0");
            }

            if(countcheck==1)
            {
                Quaity.TowerUpgradeMoney(GameManager._sniperTowerUpgradeMoney[1]._sniperTowerUpgradeMoney);
                Debug.Log("Countcheck 1");
            }

            if(countcheck==2)
            {
                Quaity.TowerUpgradeMoney(0);
                Debug.Log("Countcheck 2");
            }

            Debug.Log("Upgrade aktif");
        }

        for (int i = 0; i <TowerRangeController.UIController.Count; i++)
        {
           TowerRangeController.UIController[i].SetActive(false);
        }

        UpgradeButton1.SetActive(false);
        SellButton.SetActive(false);
    }

    public void SniperTowerSell()
    {
        Destroy(gameObject);

        if (countcheck == 0)
        {
            Quaity.SellTower(GameManager._sniperTowerMoneySell[0]._sniperTowerMoneySell);
        }

        if (countcheck == 1)
        {
            Quaity.SellTower(GameManager._sniperTowerMoneySell[1]._sniperTowerMoneySell);
        }

        if (countcheck == 2)
        {
            Quaity.SellTower(GameManager._sniperTowerMoneySell[2]._sniperTowerMoneySell);
        }
    }
}
