using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class RangeUpgrade : MonoBehaviour
{
    GameValue GameValue;
    GameManager GameManager;
    TowerRangeController towercontroller;
    BombTowerMenu bombtowermenu;
    public int Damage;
    public float Range;
    public int sniperTowerCountCheck;
    public int bombTowerCountCheck;
    private bool damageAdded = false;
    private bool damageAdded2 = false;
    private bool bombtowerdamageAdded = false;
    private bool bombtowerdamageAdded2 = false;


    private void Start()
    {
        GameValue = FindObjectOfType<GameValue>();
        GameManager = FindObjectOfType<GameManager>();

        Damage = GameManager.TowerVaribles[0].TowerDamage;
        Range = GameManager.TowerVaribles[0].TowerRange;

        Damage = GameManager.TowerVaribles[1].TowerDamage;
        Range = GameManager.TowerVaribles[1].TowerRange;
        towercontroller = GetComponent<TowerRangeController>();
        bombtowermenu = GetComponent<BombTowerMenu>();
    }
    private void Update()
    {
       if(towercontroller!=null)
       {
            sniperTowerCountCheck = GetComponent<TowerRangeController>().sniperTowerCountCheck;
       }
        if (bombtowermenu != null)
        {
            bombTowerCountCheck = GetComponent<BombTowerMenu>().bombTowerCountCheck;
        }
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

        if (bombTowerCountCheck == 1 && !bombtowerdamageAdded)
        {
            Damage += GameManager.TowerVaribles[0].TowerDamageIncreaseValue;
            Range += GameManager.TowerVaribles[0].TowerRangeIncreaseValue;
            bombtowerdamageAdded = true;
            Debug.Log("Damage: " + Damage);
        }
        if (bombTowerCountCheck == 2 && bombtowerdamageAdded && !bombtowerdamageAdded2)
        {
            Damage += 15;
            Range += 15;
            bombtowerdamageAdded2 = true;
            Debug.Log("damage" + Damage);
        }


    }

    public void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position,Range);
    }
}
