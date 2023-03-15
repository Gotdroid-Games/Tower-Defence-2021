using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeMenu : MonoBehaviour
{
    public static UpgradeMenu instance;
    public static float newfirecontdown;
    public static int towerPrice;
    public static int rangedTowerDamage;
    public static int rangeTowerCritDamage; 
    public static int towerRangeUpgrade;

    private void Awake()
    {
        if(instance==null)
        {
            instance = this;
        }
    }
    private void Start()
    {
        newfirecontdown = 1f;
        towerPrice = 120;
    }

    public void TowerSpeedUp()
    {
        newfirecontdown = 0.2f;
        GameValue.instance.NewFireCountDown = 0.2f;
    }  
   
    public void TowerPrice()
    {
        towerPrice -= 30;
        GameValue.instance.TowerPrice = 90;
    }

    public void TowerDamage()
    {
        rangedTowerDamage = 20;
        GameValue.instance.RangedTowerDamage = 20;
    }

    public void TowerRangeUpgrade()
    {
        towerRangeUpgrade = 20;
        GameValue.instance.TowerRangeUpgrade = 20;
    }

    public void RangeTowerCrit()
    {
        rangeTowerCritDamage = GameValue.instance.RangedTowerDamage * 10 / 100;
        GameValue.instance.RangedTowerCritDamage = rangedTowerDamage * 10 / 100;
    }
}
