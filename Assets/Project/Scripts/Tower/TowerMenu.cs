using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerMenu : MonoBehaviour
{
    private TowerUpgrades TowerUpgrades;
    private TowerTarget towerTarget;

    public GameObject UpgradeButton1;
    public GameObject UpgradeButton2;
    public GameObject UpgradeButton3;
    public GameObject SellButton;

    private void Start()
    {
        TowerUpgrades = GetComponent<TowerUpgrades>();
        towerTarget = GetComponent<TowerTarget>();

        //if (towerTarget == null)
        //{
        //    Debug.LogError("TowerTarget component is not attached to this GameObject.");
        //}
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

    public void Sell()
    {
        Destroy(gameObject);
    }


}
