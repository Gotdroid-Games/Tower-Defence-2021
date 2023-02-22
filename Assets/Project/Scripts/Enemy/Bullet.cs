using System;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public static Bullet Instance;
    private Transform target;

    public float speed = 70f;
    public float explosionRadius = 0f;
    public GameObject impactEffect;


    private void Awake()
    {
        Instance = this;
    }
    public void Seek (Transform _target)
    {
        target = _target;
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


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            
            enemy.TakeDamage();
                
            
        }
    }




}
