using UnityEngine;


public class UpgradeMenu : MonoBehaviour
{
    
    public static float newfirecontdown;
    public static int towerPrice;
    public static int rangedTowerDamage;
    public static int rangeTowerCritDamage; 
    public static int towerRangeUpgrade;

    private void Start()
    {
        newfirecontdown = 1f;
        towerPrice = 120;
    }

    public void TowerSpeedUp()
    {
        if (StarPoint._starPoint > 0)
        {
            newfirecontdown = 0.2f;
            GameValue.instance.NewFireCountDown = 0.2f;
            StarPoint._starPoint -= 1;
        }

        if (StarPoint._starPoint < 0)
        {
            StarPoint._starPoint = 0;
        }
    }  
   
    public void TowerPrice()
    {
        if (StarPoint._starPoint > 0)
        {
            towerPrice -= 30;
            GameValue.instance.TowerPrice = 90;
            StarPoint._starPoint -= 1;
        }
        
        if (StarPoint._starPoint < 0)
        {
            StarPoint._starPoint = 0;
        }
    }

    public void TowerDamage()
    {
        if (StarPoint._starPoint > 0)
        {
            rangedTowerDamage = 20;
            GameValue.instance.RangedTowerDamage = 20;
            StarPoint._starPoint -= 1;
        }
        
        if (StarPoint._starPoint < 0)
        {
            StarPoint._starPoint = 0;
        }
    }

    public void TowerRangeUpgrade()
    {
        if (StarPoint._starPoint > 0)
        {
            towerRangeUpgrade = 20;
            GameValue.instance.TowerRangeUpgrade = 20;
            StarPoint._starPoint -= 1;
        }
        
        if (StarPoint._starPoint < 0)
        {
            StarPoint._starPoint = 0;
        }
    }

    public void RangeTowerCrit()
    {
        if (StarPoint._starPoint > 0)
        {
            rangeTowerCritDamage = GameValue.instance.RangedTowerDamage * 10 / 100;
            GameValue.instance.RangedTowerCritDamage = rangedTowerDamage * 10 / 100;
            StarPoint._starPoint -= 1;
        }
        
        if (StarPoint._starPoint < 0)
        {
            StarPoint._starPoint = 0;
        }
    }
}
