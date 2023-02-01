using UnityEngine;
using UnityEngine.UI;


public class Enemy : MonoBehaviour
{
    [SerializeField] Healthbar _healthbar;

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
        speed = startSpeed;
        target = WayPoints.points[0];
        _healthbar.SetSlider(healthBar);
        SetHealth(100f);
        //healthBar.value = health;
    }

    void SetHealth(float amont)
    {
        //healthBar.value = health/100;
        _healthbar.SetHealth(amont / 100f);
    }



    public void TakeDamage(int amont)
    {
        // health -= amont;
        // healthBar.value = health / 100f;


        // if (health<=0)
              Debug.Log("sasa");
        //  }
        _healthbar.SetHealth(20);

    }

   

    private void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * startSpeed * Time.deltaTime, Space.World);

        if(Vector3.Distance(transform.position, target.position) <= 0.2f)
        {
            GetNextWayPoint();
        }

        void GetNextWayPoint()
        {
            if(wavepointIndex >= WayPoints.points.Length - 1)
            {
                Destroy(gameObject);
                return;
            }
            wavepointIndex++;
            target = WayPoints.points[wavepointIndex];
        }
    }
}
