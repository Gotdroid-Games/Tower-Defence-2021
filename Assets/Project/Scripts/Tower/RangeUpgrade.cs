using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeUpgrade : MonoBehaviour
{
    public static RangeUpgrade instance;
    public int Damage = 15;
    public float Range = 15f;
    public int countcheck;
    private bool damageAdded = false;
    private bool damageAdded2 = false;
    
    private void Awake()
    {
        if (instance==null)
        {
            instance = this;
        } 
    }
    
    private void Start()
    {
       
        Damage += GameValue.instance.RangedTowerDamage;
        Range += GameValue.instance.TowerRangeUpgrade;
    }
    private void Update()
    {
       
        countcheck = GetComponent<TowerRangeController>().countcheck;
        if (countcheck == 1 && !damageAdded)
        {
            Damage+= 15;
            Range+= 15;
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
    public void Attribute()
    {
        Damage += GameValue.instance.RangedTowerDamage;
        Range += GameValue.instance.TowerRangeUpgrade;
       
    }

    public void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position,Range);
    }
}
