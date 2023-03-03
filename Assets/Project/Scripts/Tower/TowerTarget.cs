using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class TowerTarget : MonoBehaviour
{
    public static TowerTarget instance;

    private Transform Target;
    
    [Header("Attributes")]
    public float fireRate = 100f;
    public float fireCountdown = 1f;
    public float NewFireCountDown = 0f; 

    [Header("Unity Setup Fields")]
    

    public string enemyTag = "Enemy";

    public Transform partToRotate;
    public float turnspeed;

    public GameObject bulletPrefab;
    public Transform firePoint;

    
    private void Awake()
    {
        if (instance == null)
            instance = this;
    }
    private void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distanceToenemy=Vector3.Distance(transform.position, enemy.transform.position);
            if(distanceToenemy < shortestDistance)
            {
                shortestDistance = distanceToenemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && shortestDistance <= RangeUpgrade.instance.Range)
        {
            Target = nearestEnemy.transform;
        }
        else
        {
            Target = null;
        }

    }


    private void Update()
    {
        if (Target == null)
        return;

        //Target lock on (Hedef kilitleme aktif)

        Vector3 dir =Target.position-transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnspeed).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);

        if (fireCountdown <= 0f)
        {
            Shoot();
            fireCountdown = 1f / fireRate;
        }

        fireCountdown -= Time.deltaTime;
    }
    

    void Shoot()
    {
        GameObject bulletGo= (GameObject) Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletGo.GetComponent<Bullet>();

        if (bullet != null)
        {
            bullet.Seek(Target);
        }

    }

    public void Sell()
    {
        Destroy(gameObject);
    }


    //private void OnDrawGizmosSelected()
    //{
    //    Gizmos.color = Color.green;
    //    Gizmos.DrawWireSphere(transform.position, Range);
    //}

    


}
