using System;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    
    private Transform target;

    public float speed = 70f;
    public int damage = 50;
    public float explosionRadius = 0f;
    public GameObject impactEffect;

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

        if(dir.magnitude <= distanceThisFrame)
        {
            //HitTarget();
 
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
    }

    void HitTarget()
    {
        //if(Enemy.instantiate.currentHealth <= 0)
        //{
        //    GameObject effectIns = Instantiate(impactEffect, transform.position, transform.rotation);
        //    Destroy(effectIns, 2f);
        //    Destroy(target.gameObject);
        //}

        Debug.Log("sasa");
        //Enemy.TakeDamage(20);
       
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("as");
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();

            enemy.TakeDamage(20);
                
            //HitTarget();
        }
    }




}
