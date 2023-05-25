using UnityEngine;

public class GameValue : MonoBehaviour
{
    UpgradeMenu UpgradeMenu;
    GameManager GameManager;
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
        GameManager = FindObjectOfType<GameManager>();
        
            Debug.Log("not null");
            //NewFireCountDown = UpgradeMenu.newfirecontdown;
            //GameManager.TowerVaribles[0].TowerMoneyBuy = UpgradeMenu.towerPrice;
            //RangedTowerDamage = UpgradeMenu.rangedTowerDamage;
            //TowerRangeUpgrade = UpgradeMenu.towerRangeUpgrade;
           // RangedTowerCritDamage = UpgradeMenu.rangeTowerCritDamage;
        
    }
}
