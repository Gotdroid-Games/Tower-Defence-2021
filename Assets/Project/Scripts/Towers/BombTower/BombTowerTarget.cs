using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BombTowerTarget : MonoBehaviour
{
    private GameValue gameValue;
    private RangeUpgrade rangeUpgrade;
    [SerializeField] Transform target;

    public int bombTowerDamage;
    public int bombTowerRange;

    public float bombTowerFireRate;
    private float bombTowerFireCountdown;

    public GameObject bombTowerBulletPrefab;
    public Transform bombTowerFirePoint;

    private void Start()
    {
        gameValue = FindObjectOfType<GameValue>();
        rangeUpgrade = FindObjectOfType<RangeUpgrade>();
        InvokeRepeating("BombTowerUpdateTarget", 0f, 0.5f);
    }

    private void Update()
    {
        if (target == null)
        {
           
            return;
        }

        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);

        if (bombTowerFireCountdown <= 0f)
        {
            Shoot();
            bombTowerFireCountdown = bombTowerFireRate;
        }

        bombTowerFireCountdown -= Time.deltaTime;
    }

    private void BombTowerUpdateTarget()
    {
        GameObject[] robots = GameObject.FindGameObjectsWithTag("Enemy");

        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in robots)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && shortestDistance <= rangeUpgrade.Range)
        {
            target = nearestEnemy.transform;
        }
        else
        {
            target = null;
        }
    }

    private void Shoot()
    {
       
            GameObject bulletGo = Instantiate(bombTowerBulletPrefab, bombTowerFirePoint.position, bombTowerFirePoint.rotation);
            Bullet bullet = bulletGo.GetComponent<Bullet>();

            if (bullet != null)
            {
                Debug.Log("girdi");
                bullet.Seek(target);
            }
        
    }
}
