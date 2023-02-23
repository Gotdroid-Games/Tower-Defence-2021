using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerMenu : MonoBehaviour
{
    

    public GameObject UpgradeButton1;
    public GameObject Tower;
    //public GameObject UpgradeButton2;
    //public GameObject UpgradeButton3;
    public GameObject SellButton;

    public int _damage = 15;

    private void Start()
    {
        
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
        
    }

    public void Sell()
    {
        Quaity.Instance.SellTower(70);
        Destroy(Tower);
    }
}
