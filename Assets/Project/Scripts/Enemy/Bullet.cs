using System;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;
    public float speed = 70f;
    public float explosionRadius = 0f;
    public GameObject impactEffect;


   
    public void Seek (Transform _target)
    {
        target = _target;
    }

    private void Start()
    {
        
    }
    private void Update()
    {
        if(target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);

        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("BasicRobot")|| other.gameObject.CompareTag("GorillaRobot") || other.gameObject.CompareTag("SupurgeRobot") || other.gameObject.CompareTag("DroneRobot"))
        {
            Enemy enemy = other.gameObject.GetComponent<Enemy>();
            enemy.TakeDamage();
            Destroy(gameObject);
        }
    }

}
