using Unity.VisualScripting;
using UnityEngine;

public class TowerUpgrades : MonoBehaviour
{
    BuildManager buildManager;
    TowerTarget target;
    private void Start()
    {
        //buildManager = BuildManager.instance;
        target = GetComponent<TowerTarget>();
    }

    public void UpgradeButton()
    {
        if (Quaity.Instance._coinText >= 100)
        {
            Quaity.Instance.TowerUpgradeMoney(120);
        }

        if (target != null) // towerTarget null deðilse, damage artýrýlabilir
        {
            target.damage += 30;
        }
        else // towerTarget null ise, hata verdirilir
        {
            Debug.LogError("TowerTarget component is not attached to this GameObject.");
        }
    }

    public void SellButton()
    {
        Quaity.Instance.CoinValue(70);
    }
}
