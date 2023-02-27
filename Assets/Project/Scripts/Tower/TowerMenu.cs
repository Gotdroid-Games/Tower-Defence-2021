using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class TowerMenu : MonoBehaviour
{
    TowerTarget towerTarget;
    

    public GameObject UpgradeButton1;
    public GameObject TowerLevel1;
    public GameObject TowerLevel2;
    public GameObject TowerLevel3;
    //public GameObject UpgradeButton2;
    //public GameObject UpgradeButton3;
    public GameObject SellButton;

    public int _damage = 15;

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
        
    }

    public void Sell()
    {
        Quaity.Instance.SellTower(70);
        Destroy(TowerLevel1);
        Destroy(TowerLevel2);
        Destroy(TowerLevel3);
    }
}
