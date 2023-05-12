using Newtonsoft.Json.Linq;
using UnityEngine;
using UnityEngine.UI;


public class Enemy : MonoBehaviour
{
    [SerializeField] TowerMenu TowerMenu;
    [SerializeField] Healthbar _healthbar;
    RangeUpgrade RangeUpgrade;
    Quaity Quaity;
    GameValue GameValue;
    TowerTarget TowerTarget;
    GameManager GameManager;

    int maxHealth;
    int currentHealth;

    public float startSpeed;
    private Transform target;
    private int wavepointIndex = 0;
    public int EnemyKillCoinValue;
    
    [HideInInspector]

    public float worth = 50;

    [Header("Unity Stuff")]
    public Slider healthBar;

    private void Start()
    {
        TowerTarget = FindObjectOfType<TowerTarget>();
        Quaity = FindObjectOfType<Quaity>();
        GameValue = FindObjectOfType<GameValue>();
        RangeUpgrade = FindObjectOfType<RangeUpgrade>();
        GameManager = FindObjectOfType<GameManager>();
        target = WayPoints.points[0];
        
        //currentHealth = maxHealth;

        if (GameObject.FindGameObjectWithTag("BasicRobot"))
        {
            maxHealth = GameManager.EnemyHealth[0]._EnemyHealth;
            currentHealth = maxHealth;
            _healthbar.SetMaxHealth(maxHealth);
            EnemyKillCoinValue = GameManager._EnemyKillCoin[0].EnemyKillCoin;
        }

        if (GameObject.FindGameObjectWithTag("GorillaRobot"))
        {
            maxHealth = GameManager.EnemyHealth[1]._EnemyHealth;
            currentHealth = maxHealth;
            _healthbar.SetMaxHealth(maxHealth);
            EnemyKillCoinValue = GameManager._EnemyKillCoin[1].EnemyKillCoin;
        }

        if (GameObject.FindGameObjectWithTag("SupurgeRobot"))
        {
            maxHealth = GameManager.EnemyHealth[2]._EnemyHealth;
            currentHealth = maxHealth;
            _healthbar.SetMaxHealth(maxHealth);
            EnemyKillCoinValue = GameManager._EnemyKillCoin[2].EnemyKillCoin;
        }

        if (GameObject.FindGameObjectWithTag("DroneRobot"))
        {
            maxHealth = GameManager.EnemyHealth[3]._EnemyHealth;
            currentHealth = maxHealth;
            _healthbar.SetMaxHealth(maxHealth);
            EnemyKillCoinValue = GameManager._EnemyKillCoin[3].EnemyKillCoin;
        }

    }


    public void TakeDamage()
    {
        RangeUpgrade = FindObjectOfType<RangeUpgrade>();
        TowerTarget = FindObjectOfType<TowerTarget>();
        currentHealth -= RangeUpgrade.Damage;
        _healthbar.SetHealth(currentHealth);
        if (TowerTarget.critValue >= 1 && TowerTarget.critValue <= 10)
        {
            currentHealth -= RangeUpgrade.Damage + GameValue.RangedTowerCritDamage;
            _healthbar.SetHealth(currentHealth);
        }
    }

    private void Update()
    {
        if (gameObject.CompareTag("BasicRobot"))
        {
            target = WayPoints.points[wavepointIndex];
            Vector3 dir1 = target.position - transform.position;
            transform.Translate(dir1.normalized * GameManager.EnemySpeed[0]._EnemySpeed * Time.deltaTime, Space.World);
            transform.rotation = Quaternion.LookRotation(dir1);
        }

        if (gameObject.CompareTag("GorillaRobot"))
        {
            target = WayPoints.points[wavepointIndex];
            Vector3 dir2 = target.position - transform.position;
            transform.Translate(dir2.normalized * GameManager.EnemySpeed[1]._EnemySpeed * Time.deltaTime, Space.World);
            transform.rotation = Quaternion.LookRotation(dir2);
        }

        if (gameObject.CompareTag("SupurgeRobot"))
        {
            target = WayPoints.points[wavepointIndex];
            Vector3 dir3 = target.position - transform.position;
            transform.Translate(dir3.normalized * GameManager.EnemySpeed[2]._EnemySpeed * Time.deltaTime, Space.World);
            transform.rotation = Quaternion.LookRotation(dir3);
        }

        if (gameObject.CompareTag("DroneRobot"))
        {
            target = WayPoints.points[wavepointIndex];
            Vector3 dir4 = target.position - transform.position;
            transform.Translate(dir4.normalized * GameManager.EnemySpeed[3]._EnemySpeed * Time.deltaTime, Space.World);
            transform.rotation = Quaternion.LookRotation(dir4);
        }
        

        Quaity = FindObjectOfType<Quaity>();
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Destroy(gameObject);
        }

        if (target == null)
        {
            return;
        }

        //target = WayPoints.points[wavepointIndex];
        //Vector3 dir = target.position - transform.position;
        //transform.Translate(dir.normalized * startSpeed * Time.deltaTime, Space.World);
        //transform.rotation = Quaternion.LookRotation(dir);
        if (gameObject.CompareTag("GorillaRobot"))
        {
            transform.rotation *= Quaternion.Euler(-90, 0, 0);
        }
        if (Vector3.Distance(transform.position, target.position) <= 0.2f)
        {
            GetNextWayPoint();
        }

        
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
        if (currentHealth <= 0)
        {
            Quaity.CoinValue(EnemyKillCoinValue);
        }
    }

}
