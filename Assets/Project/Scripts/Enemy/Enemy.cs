using UnityEngine;
using UnityEngine.UI;


public class Enemy : MonoBehaviour
{
    
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

    private void Awake()
    {
        TowerTarget = GetComponent<TowerTarget>();
    }
    private void Start()
    {
        speed = startSpeed;
        target = WayPoints.points[0];
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {

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
