using UnityEngine;


public class UpgradeMenu : MonoBehaviour
{
    GameValue GameValue;
    public float newfirecontdown=1f;
    public int towerPrice;
    public int rangedTowerDamage;
    public int rangeTowerCritDamage; 
    public int towerRangeUpgrade;

    private void Start()
    {
        
        towerPrice = 120;
        GameValue = FindObjectOfType<GameValue>();
        
    }

    public void TowerSpeedUp()
    {
        if (StarPoint._starPoint > 0)
        {
            newfirecontdown = 0.2f;
            GameValue.NewFireCountDown = 0.2f;
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
            GameValue.TowerPrice = 90;
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
            GameValue.RangedTowerDamage = 20;
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
            GameValue.TowerRangeUpgrade = 20;
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
            rangeTowerCritDamage = GameValue.RangedTowerDamage * 10 / 100;
            GameValue.RangedTowerCritDamage = rangedTowerDamage * 10 / 100;
            StarPoint._starPoint -= 1;
        }
        
        if (StarPoint._starPoint < 0)
        {
            StarPoint._starPoint = 0;
        }
    }
}
