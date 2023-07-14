using UnityEngine;

public class GameValue : MonoBehaviour
{
    TowerTarget TowerTarget;
    GameManager GameManager;

    private void Start()
    {
        TowerTarget = FindObjectOfType<TowerTarget>();
        GameManager = FindObjectOfType<GameManager>();
    }
    public void Fill(int critValue, int towerRange, int towerDamage, int fireRate)
    {
        TowerTarget.critValue = critValue;
        TowerTarget.fireRate = fireRate;
        GameManager.TowerVaribles[0].TowerDamage = towerDamage;
        GameManager.TowerVaribles[0].TowerRange = towerRange;
    }
}
