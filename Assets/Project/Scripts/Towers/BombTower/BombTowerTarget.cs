using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Unity.VisualScripting;

public class BombTowerTarget : MonoBehaviour
{
    private GameValue gameValue;
    private RangeUpgrade rangeUpgrade;
    GameManager GameManager;
    [SerializeField] Transform target;

    public int bombTowerDamage;
    public int bombTowerRange;
    private float bombTowerFireCountdown;

    public GameObject bombTowerBulletPrefab;
    public Transform bombTowerFirePoint;

    private void Start()
    {
        gameValue = FindObjectOfType<GameValue>();
        rangeUpgrade = FindObjectOfType<RangeUpgrade>();
        GameManager = FindObjectOfType<GameManager>();
        InvokeRepeating("BombTowerUpdateTarget", 0f, 0.5f);
    }

    private void Update()
    {
        if (target == null)
            return;


        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);

        if (bombTowerFireCountdown <= 0f)
        {
            Shoot();
            bombTowerFireCountdown = GameManager.TowerVaribles[1].FireRate;
        }

        bombTowerFireCountdown -= Time.deltaTime;
    }

    private void BombTowerUpdateTarget()
    {
        GameObject[] robots = GameManager.Instance.ActiveRobots;

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
        Bombbullet bullet = bulletGo.GetComponent<Bombbullet>();

        bullet.Seek(target);
        bullet.transform.DOJump(new Vector3(target.position.x, 0f, target.position.z), 10f, 1, 1f);
    }


}
