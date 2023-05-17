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
    public int countcheck;
    private bool damageAdded = false;
    private bool damageAdded2 = false;


    private void Start()
    {
        GameValue = FindObjectOfType<GameValue>();
        GameManager = FindObjectOfType<GameManager>();

        Damage = GameManager.TowerVaribles[0].TowerDamage;
        Range = GameManager.TowerVaribles[0].TowerRange;
    }
    private void Update()
    {
       
        countcheck = GetComponent<TowerRangeController>().countcheck;
        if (countcheck == 1 && !damageAdded)
        {
            Damage += GameManager.TowerVaribles[0].TowerDamageIncreaseValue;
            Range += GameManager.TowerVaribles[0].TowerRangeIncreaseValue;
            damageAdded = true;
            Debug.Log("Damage: " + Damage);
        }
        if (countcheck == 2 && damageAdded&&!damageAdded2)
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
