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
    GameManager GameManager;
    BombTowerMenu BombTowerMenu;
    TowerMenu Towermenu;
    GameUI GameUI;
    Soldiers soldiers;
    int maxHealth;
    public int currentHealth;
    public float RobotSpeed;
    public int RobotDamage;
    private Transform target;
    private int wavepointIndex = 0;
    public int EnemyKillCoinValue;
    public bool inside = false;
    public bool Soldierinside = false;

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
        TowerTarget = FindObjectOfType<TowerTarget>();
        Towermenu = FindObjectOfType<TowerMenu>();
        BombTowerMenu = FindObjectOfType<BombTowerMenu>();
        soldiers = FindObjectOfType<Soldiers>();

        if (Towermenu != null)
        {
            if (Towermenu.TowerType == EnemyManager.TowerType.sniperTower)
            {
                currentHealth -= Towermenu.sniperTowerDamage;
            }
        }
        if (BombTowerMenu != null)
        {
            if (BombTowerMenu.TowerType == EnemyManager.TowerType.bombTower)
            {
                currentHealth -= GameManager.TowerVaribles[1].TowerDamage;
            }
        }
        if (soldiers != null)
        {
            currentHealth -= 10;
           
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
            RobotSpeed = 5f;
        }
        else
        {
            RobotSpeed = 15f;
        }
        if (Soldierinside == true)
        {
            RobotSpeed = 0f;
        }
        

        Coin();
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
