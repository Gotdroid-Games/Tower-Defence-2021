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

    private void Start()
    {
        Damage += GameValue.instance.RangedTowerDamage;
        Range += GameValue.instance.TowerRangeUpgrade;
    }
    public void Attribute()
    {
        Damage += GameValue.instance.RangedTowerDamage;
        Range += GameValue.instance.TowerRangeUpgrade;
        TowerMenu.instance.Tower.GetComponent<RangeUpgrade>().Damage += 15;
        TowerMenu.instance.Tower.GetComponent<RangeUpgrade>().Range += 15;
        
    }

    //public void OnDrawGizmosSelected()
    //{
    //    Gizmos.color = Color.green;
    //    Gizmos.DrawWireSphere(transform.position, Range);
    //}
}
