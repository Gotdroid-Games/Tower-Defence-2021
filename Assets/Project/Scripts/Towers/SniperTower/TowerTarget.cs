using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class TowerTarget : MonoBehaviour
{
    private GameValue gameValue;
    private RangeUpgrade rangeUpgrade;
    [SerializeField] Transform target;
    GameManager GameManager;
    Enemy Enemy;
    [Header("Attributes")]
    public float fireRate;
    public float fireCountdown;
    public int critValue;

    [Header("Unity Setup Fields")]
    public Transform partToRotate;
    public float turnSpeed;
    public GameObject bulletPrefab;
    public Transform firePoint;

    private void Start()
    {
        gameValue = FindObjectOfType<GameValue>();
        rangeUpgrade = FindObjectOfType<RangeUpgrade>();
        GameManager = FindObjectOfType<GameManager>();
        Enemy = FindObjectOfType<Enemy>();
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    private void UpdateTarget()
    {
        GameObject[] Robots = GameObject.FindGameObjectsWithTag("Enemy");

        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in Robots)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        target = nearestEnemy != null && shortestDistance <= rangeUpgrade.Range ? nearestEnemy.transform : null;
    }

    private void Update()
    {

        if (target == null)
            return;

        // Target lock on
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);

        // Crit chance
        if (fireCountdown <= 0f)
        {
            Shoot();
            critValue = Random.Range(1, 101);
            fireCountdown = fireRate;

            //if (gameValue.NewFireCountDown == 0.2f)
            //{
            //    fireCountdown = 0.2f / fireRate;
            //}

        }
        fireCountdown -= Time.deltaTime;

    }

    private void Shoot()
    {
        GameObject bulletGo = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletGo.GetComponent<Bullet>();

        if (bullet != null)
        {
            bullet.Seek(target);
        }
    }
}
