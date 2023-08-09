using System;
using System.Collections;
using Newtonsoft.Json.Linq;
using UnityEngine;
using UnityEngine.UI;


public class Enemy : MonoBehaviour
{

    public EnemyManager.EnemyType RobotType;


    [Header("")]

    //[SerializeField] TowerMenu TowerMenu;
    [SerializeField] Healthbar _healthbar;
    WaveSpawner waveSpawner;
    GameValue GameValue;
    TowerTarget TowerTarget;
    HackTowerTarget HackTowerTarget;
    GameManager GameManager;
    BombTowerMenu BombTowerMenu;
    TowerMenu Towermenu;
    GameUI GameUI;
    Enemy enemy;
    int maxHealth;
    public int currentHealth;
    public float RobotSpeed;
    public int RobotDamage;
    private Transform target;
    private int wavepointIndex = 0;
    public int EnemyKillCoinValue;
    public bool inside = false;
    private float timer = 0f;
    public float interval = 1.5f;
    public float slowedSpeed = 5f;
    [HideInInspector]

    public float worth = 50;

    [Header("Unity Stuff")]
    public Slider healthBar;

    [Header("Waypoint Variables")]

    public int NextWaypointNumber;
    public float NextWaypointDistance;

    private void Start()
    {
        GameValue = FindObjectOfType<GameValue>();
        GameManager = FindObjectOfType<GameManager>();
        waveSpawner = FindObjectOfType<WaveSpawner>();
        BombTowerMenu = FindObjectOfType<BombTowerMenu>();
        Towermenu = FindObjectOfType<TowerMenu>();
        GameUI = FindObjectOfType<GameUI>();
        enemy = FindObjectOfType<Enemy>();
        HackTowerTarget = FindObjectOfType<HackTowerTarget>();

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
        if (RobotType == EnemyManager.EnemyType.HealerRobot)
        {
            maxHealth = GameManager.EnemyVariables[4]._EnemyHealth;
            currentHealth = maxHealth;
            _healthbar.SetMaxHealth(maxHealth);
            EnemyKillCoinValue = GameManager.EnemyVariables[4].EnemyKillCoin;
            RobotSpeed = GameManager.EnemyVariables[4]._EnemySpeed;
            RobotDamage = GameManager.EnemyVariables[4]._EnemyDamage;
        }

    }


    public void TakeDamage()
    {
        TowerTarget = FindObjectOfType<TowerTarget>();
        Towermenu = FindObjectOfType<TowerMenu>();
        BombTowerMenu = FindObjectOfType<BombTowerMenu>();

        if (Towermenu != null)
        {
            if (Towermenu.TowerType == EnemyManager.TowerType.sniperTower)
            {
                if (enemy.inside == true)
                {
                    currentHealth -= GameManager.TowerVaribles[0].TowerDamage + (Towermenu.sniperTowerDamageIncreasePercentage);
                    Debug.Log("Hacker Kulesinin efekti aktif ve lazer kulesi extra hasar vuruyor");
                }
                else
                {
                    currentHealth -= GameManager.TowerVaribles[0].TowerDamage;
                    Debug.Log("Hacker Kulesinin efekti deaktif ve lazer kulesi extra hasar vurmuyor");
                }

            }
        }
        if (BombTowerMenu != null)
        {
            if (BombTowerMenu.TowerType == EnemyManager.TowerType.bombTower)
            {
                if (enemy.inside == true)
                {
                    currentHealth -= GameManager.TowerVaribles[1].TowerDamage + (BombTowerMenu.bombTowerDamageIncreasePercentage);
                }
                else
                {
                    currentHealth -= GameManager.TowerVaribles[1].TowerDamage;
                }
            }
        }
        _healthbar.SetHealth(currentHealth);

        //if (TowerTarget.critValue >= 1 && TowerTarget.critValue <= 10)
        //{
        //    currentHealth -= RangeUpgrade.Damage + GameValue.RangedTowerCritDamage;
        //    _healthbar.SetHealth(currentHealth);
        //}

    }

    private void Update()
    {

        target = WayPoints.points[wavepointIndex];
        Vector3 dir1 = target.position - transform.position;
        transform.Translate(dir1.normalized * RobotSpeed * Time.deltaTime, Space.World);
        transform.rotation = Quaternion.LookRotation(dir1);

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

        NextWaypointDistance = Vector3.Distance(transform.position, target.position);
        NextWaypointNumber = wavepointIndex;

        if (Vector3.Distance(transform.position, target.position) <= 0.1f)
        {
            GetNextWayPoint();
        }
        if (inside == true)
        {
            StartCoroutine(SlowDownCoroutine());
            //  RobotSpeed = 5f;
        }
        else
        {
            if (RobotType == EnemyManager.EnemyType.BasicRobot)
            {
                RobotSpeed = GameManager.EnemyVariables[0]._EnemySpeed;
            }
            if (RobotType == EnemyManager.EnemyType.GorillaRobot)
            {
                RobotSpeed = GameManager.EnemyVariables[1]._EnemySpeed;
            }
            if (RobotType == EnemyManager.EnemyType.SmartHomeRobot)
            {
                RobotSpeed = GameManager.EnemyVariables[2]._EnemySpeed;
            }
            if (RobotType == EnemyManager.EnemyType.DroneRobot)
            {
                RobotSpeed = GameManager.EnemyVariables[3]._EnemySpeed;
            }
        }


        Coin();
    }
    IEnumerator SlowDownCoroutine()
    {
        float initialSpeed = RobotSpeed;

        // float slowSpeed = 5f;
        float interval = 1.5f;

        while (true)
        {
            RobotSpeed = slowedSpeed;
            yield return new WaitForSeconds(interval);
            if (!inside)
            {
                break;
            }

            if (RobotType == EnemyManager.EnemyType.BasicRobot)
            {
                RobotSpeed = GameManager.EnemyVariables[0]._EnemySpeed;
            }
            if (RobotType == EnemyManager.EnemyType.GorillaRobot)
            {
                RobotSpeed = GameManager.EnemyVariables[1]._EnemySpeed;
            }
            if (RobotType == EnemyManager.EnemyType.SmartHomeRobot)
            {
                RobotSpeed = GameManager.EnemyVariables[2]._EnemySpeed;
            }
            if (RobotType == EnemyManager.EnemyType.DroneRobot)
            {
                RobotSpeed = GameManager.EnemyVariables[3]._EnemySpeed;
            }
            yield return new WaitForSeconds(interval);
        }
    }

    void GetNextWayPoint()
    {
        if (wavepointIndex >= WayPoints.points.Length - 1)
        {
            GameUI.HearthDamage(RobotDamage);
            Destroy(gameObject);


            return;
        }
        wavepointIndex++;
    }

    void Coin()
    {
        if (currentHealth <= 0)
        {
            GameUI.IncreaseCoinValue(EnemyKillCoinValue);
        }
    }

}
