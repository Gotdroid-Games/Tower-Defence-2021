using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class RangeUpgrade : MonoBehaviour
{
    GameValue GameValue;
    GameManager GameManager;
    public int Damage;
    public float Range;
    public int sniperTowerCountCheck;
    public int bombTowerCountCheck;
    private bool damageAdded = false;
    private bool damageAdded2 = false;


    private void Start()
    {
        GameValue = FindObjectOfType<GameValue>();
        GameManager = FindObjectOfType<GameManager>();

        Damage = GameManager.TowerVaribles[0].TowerDamage;
        Range = GameManager.TowerVaribles[0].TowerRange;

        Damage = GameManager.TowerVaribles[1].TowerDamage;
        Range = GameManager.TowerVaribles[2].TowerRange;
    }
    private void Update()
    {
       
        sniperTowerCountCheck = GetComponent<TowerRangeController>().sniperTowerCountCheck;
        bombTowerCountCheck=GetComponent<TowerRangeController>().bombTowerCountCheck;
        if (sniperTowerCountCheck == 1 && !damageAdded)
        {
            Damage += GameManager.TowerVaribles[0].TowerDamageIncreaseValue;
            Range += GameManager.TowerVaribles[0].TowerRangeIncreaseValue;
            damageAdded = true;
            Debug.Log("Damage: " + Damage);
        }
        if (sniperTowerCountCheck == 2 && damageAdded&&!damageAdded2)
        {
            Damage += 15;
            Range += 15;
            damageAdded2 = true;
            Debug.Log("damage" + Damage);
        }

    }

    public void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position,Range);
    }
}
