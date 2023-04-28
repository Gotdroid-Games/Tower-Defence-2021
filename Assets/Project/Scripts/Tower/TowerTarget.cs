using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class TowerTarget : MonoBehaviour
{
        private GameValue gameValue;
        private RangeUpgrade rangeUpgrade;
        private Transform target;

        [Header("Attributes")]
        public float fireRate = 100f;
        public float fireCountdown = 1f;
        public int critValue;

        [Header("Unity Setup Fields")]
        public string enemyTag = "Enemy";
        public Transform partToRotate;
        public float turnSpeed;
        public GameObject bulletPrefab;
        public Transform firePoint;

        private void Start()
        {
            gameValue = FindObjectOfType<GameValue>();
            rangeUpgrade = FindObjectOfType<RangeUpgrade>();
            InvokeRepeating("UpdateTarget", 0f, 0.5f);
        }

        private void UpdateTarget()
        {   
            GameObject[] enemies1 = GameObject.FindGameObjectsWithTag("GorillaRobot");
            
            GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
            float shortestDistance = Mathf.Infinity;
            GameObject nearestEnemy = null;

            foreach (GameObject enemy in enemies)
            {
                float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
                if (distanceToEnemy < shortestDistance)
                {
                    shortestDistance = distanceToEnemy;
                    nearestEnemy = enemy;
                }
            }

            foreach (GameObject enemy in enemies1)
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
                critValue = Random.Range(1, 101);
                Shoot();
                fireCountdown = gameValue.NewFireCountDown == 0.2f ? 0.2f / fireRate : 1f / fireRate;
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

        public void Sell()
        {
            Destroy(gameObject);
        }
    }
