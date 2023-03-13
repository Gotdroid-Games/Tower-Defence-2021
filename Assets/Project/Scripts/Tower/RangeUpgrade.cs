using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeUpgrade : MonoBehaviour
{
    public static RangeUpgrade instance;
    public int Damage = 15;
    public float Range = 15f;

    private void Awake()
    {
        if (instance==null)
        {
            instance = this;
        }
    }
    public void Attribute()
    {
        TowerMenu.instance.Tower.GetComponent<RangeUpgrade>().Damage+=15;
        TowerMenu.instance.Tower.GetComponent<RangeUpgrade>().Range+=15;
        OnDrawGizmosSelected();
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, Range);
    }
}
