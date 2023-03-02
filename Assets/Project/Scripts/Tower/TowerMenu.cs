using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class TowerMenu : MonoBehaviour
{
    TowerTarget towerTarget;
    

    public GameObject UpgradeButton1;
    public GameObject Tower;
    //public GameObject TowerLevel2;
    //public GameObject TowerLevel3;
    //public GameObject UpgradeButton2;
    //public GameObject UpgradeButton3;
    public GameObject SellButton;

    private void Start()
    {
        towerTarget = TowerTarget.instance;
    }

    private void OnMouseDown()
    {
        if (!UpgradeButton1.activeSelf)
        {
            UpgradeButton1.SetActive(true);
            SellButton.SetActive(true);
        }
        else if (UpgradeButton1.activeSelf)
        {
            UpgradeButton1.SetActive(false);
            SellButton.SetActive(false);
        }
    }
    
    public void Upgrade()
    {
        towerTarget.damage += 15;
        towerTarget.Range += 15f;
        if(Quaity.Instance._coinText>=120)
        {
            Quaity.Instance.PaidTower(120);
        }
        UpgradeButton1.SetActive(false);
        SellButton.SetActive(false);   
    }

    public void Sell()
    {
        Quaity.Instance.SellTower(70);
        Destroy(Tower);
    }

}
