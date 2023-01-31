using UnityEngine;
using UnityEngine.UI;


public class Enemy : MonoBehaviour
{
    public static Enemy Instance;

    public float startSpeed = 10f;
    private Transform target;
    private int wavepointIndex = 0;

    [HideInInspector]
    public float speed;

    public float health = 100;

    public float worth = 50;

    [Header("Unity Stuff")]
    public Image healthBar;
    private void Start()
    {
        speed = startSpeed;
        target = WayPoints.points[0];
    }

    public void TakeDamage(int amont)
    {
        health -= amont;
        healthBar.fillAmount = health / 100f;


        if (health<=0)
        {
             Die();
            Debug.Log(health);

        }

           
    }

    public void Die()
    {

        Destroy(gameObject);
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
