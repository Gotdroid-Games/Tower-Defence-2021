using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameValue : MonoBehaviour
{
    public static GameValue instance;
    public int TowerPrice = 120;
    public int RangedTowerDamage = 20;
    public int TowerRangeUpgrade = 20;
    public float NewFireCountDown = 1f;
    


    private void Awake()
    {
        if(instance==null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        NewFireCountDown = UpgradeMenu.newfirecontdown;
        TowerPrice = UpgradeMenu.towerPrice;
        RangedTowerDamage = UpgradeMenu.rangedTowerDamage;
        TowerRangeUpgrade = UpgradeMenu.towerRangeUpgrade;
    }
}
