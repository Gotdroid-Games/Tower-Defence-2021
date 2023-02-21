using UnityEngine;
using UnityEngine.UI;


public class Enemy : MonoBehaviour
{
    [SerializeField] Healthbar _healthbar;

    public static Enemy Instance;

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
        Instance = this;
        speed = startSpeed;
        target = WayPoints.points[0];
        //_healthbar.SetSlider(healthBar);
        currentHealth = maxHealth;
        //_healthbar.SetMaxHealth(maxHealth);
        //healthBar.value = health;
    }

    //void SetHealth(int amont)
    //{
    //    //healthBar.value = health/100;
    //    _healthbar.SetHealth(amont / 100);
    //}



    public void TakeDamage(int damage)
    {
        // health -= amont;
        // healthBar.value = health / 100;


        // if (health<=0)
        //      Debug.Log("sasa");
        //  }
        //_healthbar.SetHealth(20);

        currentHealth -= damage;

        _healthbar.SetHealth(currentHealth);
    }

   

    private void Update()
    {
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
         
        if (target == null)
        {
            return;
        }

        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);
        transform.rotation = Quaternion.LookRotation(dir);

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
            Destroy(target.gameObject);

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
