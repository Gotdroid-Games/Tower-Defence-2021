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
    public Transform bombTowerfirePoint;

    private void Start()
    {
        gameValue = FindObjectOfType<GameValue>();
        rangeUpgrade = FindObjectOfType<RangeUpgrade>();
        InvokeRepeating("BombTowerUpdateTarget", 0f, 0.5f);
    }

    private void Update()
    {
        if (target != null)
            return;
        {
            Vector3 dir = target.position - transform.position;
            Quaternion lookRotation = Quaternion.LookRotation(dir);

            // Crit chance
            if (bombTowerFireCountdown <= 0f)
            {
                Shoot();
                bombTowerFireCountdown = bombTowerFireRate;

                //if (gameValue.NewFireCountDown == 0.2f)
                //{
                //    fireCountdown = 0.2f / fireRate;
                //}
            }

            bombTowerFireCountdown -= Time.deltaTime;
        }
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
        if (bombTowerBulletPrefab != null && bombTowerfirePoint != null && target != null)
        {
            GameObject bulletGo = Instantiate(bombTowerBulletPrefab, bombTowerfirePoint.position, bombTowerfirePoint.rotation);
            Bullet bullet = bulletGo.GetComponent<Bullet>();

            if (bullet != null)
            {
                bullet.Seek(target);
            }
        }
    }
}
#region
//public GameObject bombBulletPrefab;
//public List<GameObject> enemyList = new List<GameObject>();
//public float detectionRadius;
////private float distanceToEnemy;
//private Transform target;
//private RangeUpgrade rangeUpgrade;
////private List<Collider> enemyCollider = new List<Collider>();
//Collider[] enemyCollider;
//// Start is called before the first frame update
//void Start()
//{
//    rangeUpgrade = FindObjectOfType<RangeUpgrade>();
//    InvokeRepeating("BombShooting", 0f, 0.5f);
//}

//// Update is called once per frame
//void Update()
//{

//}
//private void BombShooting()
//{
//    BombTargetCalculator();

//    // enemyTarget.transform.position - zýplama poziyonu , 3 - zýplama gücü , 1 - zýplama sayýsý , 1 - süre(saniye)
//    if (_enemy != null)
//    {
//        float distanceToEnemy = Vector3.Distance(transform.position, _enemy.transform.position); //HATAAAAAAAAAAAAAAAAAAAAAAAAAAAAA
//        GameObject bombBullet = Instantiate(bombBulletPrefab, transform.position, transform.rotation);
//        enemyCollider = Physics.OverlapSphere(bombBullet.transform.position, detectionRadius);
//        bombBullet.GetComponent<Rigidbody>().DOJump(target.transform.position, 3, 1, 1).OnComplete(() =>
//        {
//            for (int i = 0; i < enemyCollider.Length; i++)
//            {
//                Debug.Log(enemyCollider[i]);
//                enemyCollider[i].GetComponent<Enemy>().currentHealth -= 15;
//            }
//            Destroy(bombBullet, 1f);
//        }
//    }
//}
//public void BombTargetCalculator()
//{
//    GameObject[] Robots = GameObject.FindGameObjectsWithTag("Enemy");

//    float shortestDistance = Mathf.Infinity;
//    GameObject nearestEnemy = null;
//    foreach (GameObject enemy in Robots)
//    {
//        float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
//        if (distanceToEnemy < shortestDistance)
//        {
//            shortestDistance = distanceToEnemy;
//            nearestEnemy = enemy;
//        }

//    }
//foreach (GameObject enemy in GorillaRobotTag)
//{
//    float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
//    if (distanceToEnemy < shortestDistance)
//    {
//        shortestDistance = distanceToEnemy;
//        nearestEnemy = enemy;
//        _enemy = enemy;
//    }
//}
//foreach (GameObject enemy in SmartHomeRobotTag)
//{
//    float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
//    if (distanceToEnemy < shortestDistance)
//    {
//        shortestDistance = distanceToEnemy;
//        nearestEnemy = enemy;
//        _enemy = enemy;
//    }
//}
//foreach (GameObject enemy in DroneRobotTag)
//{

//    float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
//    if (distanceToEnemy < shortestDistance)
//    {
//        shortestDistance = distanceToEnemy;
//        nearestEnemy = enemy;
//        _enemy = enemy;
//    }
//}
//target = nearestEnemy != null && shortestDistance <= rangeUpgrade.Range ? nearestEnemy.transform : null;
//}
#endregion
