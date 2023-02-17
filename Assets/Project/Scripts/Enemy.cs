using UnityEngine;

public class Enemy : MonoBehaviour
{
    public static Enemy Instance;

    public float speed = 10f;
    private Transform target;
    private int wavepointIndex = 0;

    

    private void Start()
    {
        target = WayPoints.points[0];
        Instance = this;
    }
    private void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

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
