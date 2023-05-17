using Newtonsoft.Json.Linq;
using UnityEngine;
using UnityEngine.UI;


public class Enemy : MonoBehaviour
{

    public EnemyManager.EnemyType RobotType;

    [Header("")]
     
    [SerializeField] TowerMenu TowerMenu;
    [SerializeField] Healthbar _healthbar;
    RangeUpgrade RangeUpgrade;
    Quaity Quaity;
    GameValue GameValue;
    TowerTarget TowerTarget;
    GameManager GameManager;

    int maxHealth;
    int currentHealth;

    public float RobotSpeed;
    public int RobotDamage;
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

        if (RobotType == EnemyManager.EnemyType.BasicRobot)
        {
            maxHealth = GameManager.EnemyVariables[0]._EnemyHealth;
            currentHealth = maxHealth;
            _healthbar.SetMaxHealth(maxHealth);
            EnemyKillCoinValue = GameManager.EnemyVariables[0].EnemyKillCoin;
            RobotSpeed = GameManager.EnemyVariables[0]._EnemySpeed;
            RobotDamage = GameManager.EnemyVariables[0]._EnemyDamage;
        }

        if (RobotType == EnemyManager.EnemyType.GorillaRobot)
        {
            maxHealth = GameManager.EnemyVariables[1]._EnemyHealth;
            currentHealth = maxHealth;
            _healthbar.SetMaxHealth(maxHealth);
            EnemyKillCoinValue = GameManager.EnemyVariables[1].EnemyKillCoin;
            RobotSpeed = GameManager.EnemyVariables[1]._EnemySpeed;
            RobotDamage = GameManager.EnemyVariables[1]._EnemyDamage;
        }

        if (RobotType == EnemyManager.EnemyType.SmartHomeRobot)
        {
            maxHealth = GameManager.EnemyVariables[2]._EnemyHealth;
            currentHealth = maxHealth;
            _healthbar.SetMaxHealth(maxHealth);
            EnemyKillCoinValue = GameManager.EnemyVariables[2].EnemyKillCoin;
            RobotSpeed = GameManager.EnemyVariables[2]._EnemySpeed;
            RobotDamage = GameManager.EnemyVariables[2]._EnemyDamage;
        }

        if (RobotType == EnemyManager.EnemyType.DroneRobot)
        {
            maxHealth = GameManager.EnemyVariables[3]._EnemyHealth;
            currentHealth = maxHealth;
            _healthbar.SetMaxHealth(maxHealth);
            EnemyKillCoinValue = GameManager.EnemyVariables[3].EnemyKillCoin;
            RobotSpeed = GameManager.EnemyVariables[3]._EnemySpeed;
            RobotDamage = GameManager.EnemyVariables[3]._EnemyDamage;
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
        target = WayPoints.points[wavepointIndex];
        Vector3 dir1 = target.position - transform.position;
        transform.Translate(dir1.normalized * RobotSpeed * Time.deltaTime, Space.World);
        transform.rotation = Quaternion.LookRotation(dir1);   

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

        if (Vector3.Distance(transform.position, target.position) <= 0.1f)
        {
            GetNextWayPoint();
        }

        
        Coin();
    }

    void GetNextWayPoint()
    {
        if (wavepointIndex >= WayPoints.points.Length - 1)
        {
            Quaity.Instance.Damage(RobotDamage);
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
