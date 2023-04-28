using UnityEngine;

public class GameValue : MonoBehaviour
{
    UpgradeMenu UpgradeMenu;
    public int TowerPrice = 120;
    public int RangedTowerDamage = 20;
    public int TowerRangeUpgrade = 20;
    public int RangedTowerCritDamage;
    public float NewFireCountDown = 1f;


    private void Awake()
    {
        
    }
    private void Start()
    {
        UpgradeMenu = FindObjectOfType<UpgradeMenu>();

        //NewFireCountDown = UpgradeMenu.newfirecontdown;
        //TowerPrice = UpgradeMenu.towerPrice;
        //RangedTowerDamage = UpgradeMenu.rangedTowerDamage;
        //TowerRangeUpgrade = UpgradeMenu.towerRangeUpgrade;
        //RangedTowerCritDamage = UpgradeMenu.rangeTowerCritDamage;
    }
}
