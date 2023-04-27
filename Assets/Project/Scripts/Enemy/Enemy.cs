using UnityEngine;
using UnityEngine.UI;


public class Enemy : MonoBehaviour
{
    [SerializeField] TowerMenu TowerMenu;
    [SerializeField] Healthbar _healthbar;
    TowerTarget TowerTarget;

    public int maxHealth = 100;
    public int currentHealth;

    public float startSpeed = 10f;
    private Transform target;
    private int wavepointIndex = 0;

    [HideInInspector]
    public float speed;
    public float worth = 50;

    [Header("Unity Stuff")]
    public Slider healthBar;
   
    private void Start()
    {   
        TowerTarget = TowerTarget.instance;
        speed = startSpeed;
        target = WayPoints.points[0];
        currentHealth = maxHealth;
    }


    public void TakeDamage()
    {
        currentHealth -= RangeUpgrade.instance.Damage;
        _healthbar.SetHealth(currentHealth);
        if (TowerTarget.instance.CritValue >= 1 && TowerTarget.instance.CritValue <= 10)
        {
            currentHealth -= RangeUpgrade.instance.Damage + GameValue.instance.RangedTowerCritDamage;
            _healthbar.SetHealth(currentHealth);
        }
    }

    private void Update()
    {
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Destroy(gameObject);
        }
         
        if (target == null)
        {
            return;
        }

        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);
        transform.rotation = Quaternion.LookRotation(dir);
        if (gameObject.CompareTag("GorillaRobot"))
        {
            transform.rotation *= Quaternion.Euler(-90, 0, 0);
        }
            if(Vector3.Distance(transform.position, target.position) <= 0.2f)
        {
            GetNextWayPoint();
        }

        target = WayPoints.points[wavepointIndex];
        Coin();
    }

    void GetNextWayPoint()
    {
        if (wavepointIndex >= WayPoints.points.Length - 1)
        {
            Destroy(gameObject);

            return;
        }
        wavepointIndex++;
    }

    void Coin()
    {
        if(currentHealth<=0)
        {
            Quaity.Instance.CoinValue(10);
        }
    }
}
