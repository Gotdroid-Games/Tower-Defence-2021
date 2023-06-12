//using System.Collections;
//using System.Collections.Generic;
//using Unity.VisualScripting;
//using UnityEngine;
//using UnityEngine.UI;

//public class TowerTarget : MonoBehaviour
//{
//    private GameValue gameValue;
//    TowerMenu TowerMenu;
//    [SerializeField] Transform target;
//    GameManager GameManager;
//    Enemy Enemy;
//    [Header("Attributes")]
//    public float fireRate;
//    public float fireCountdown;
//    public int critValue;

//    [Header("Unity Setup Fields")]
//    public Transform partToRotate;
//    public Transform partToBarrel;
//    public float turnSpeed;
//    public GameObject bulletPrefab;
//    public Transform firePoint;
//    AudioSource source;

//    private void Awake()
//    {

//        //source = GameManager.AudioVaribles.AudioSource;
//        //voices = GameManager.AudioVaribles.AudioClip;
//    }
//    private void Start()
//    {

//        gameValue = FindObjectOfType<GameValue>();
//        GameManager = FindObjectOfType<GameManager>();
//        Enemy = FindObjectOfType<Enemy>();
//        TowerMenu = FindObjectOfType<TowerMenu>();
//        source = GameManager.gameObject.GetComponent<AudioSource>();
//        InvokeRepeating("UpdateTarget", 0f, 0.5f);
//    }


//    private void UpdateTarget()
//    {
//        GameObject[] Robots = GameObject.FindGameObjectsWithTag("Enemy");

//        float shortestDistance = Mathf.Infinity;
//        GameObject TargetEnemy = null;
//        int ActiveWaypointNumber = 0;
//        float ActiveWaypointDistance = 1000f;

//        for (int i = 0; i < Robots.Length; i++)
//        {
//            shortestDistance = Vector3.Distance(this.transform.position, Robots[i].transform.position);

//            if(Robots[i].GetComponent<Enemy>().NextWaypointNumber >= ActiveWaypointNumber && Robots[i].GetComponent<Enemy>().NextWaypointDistance <= ActiveWaypointDistance && shortestDistance <= TowerMenu.sniperTowerRange)
//            {
//                TargetEnemy = Robots[i];
//                ActiveWaypointDistance = Robots[i].GetComponent<Enemy>().NextWaypointDistance;
//                ActiveWaypointNumber = Robots[i].GetComponent<Enemy>().NextWaypointNumber;
//            }
//        }

//        if (TargetEnemy != null && Vector3.Distance(this.transform.position, TargetEnemy.transform.position) <= TowerMenu.sniperTowerRange)
//            target = TargetEnemy.transform;

//        else
//            target = null;
//    }

//    private void Update()
//    {

//        if (target == null)
//            return;

//        // Target lock on
//        Vector3 dir = target.position - transform.position;
//        Quaternion lookRotation = Quaternion.LookRotation(dir);
//        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation,lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
//        partToRotate.rotation = Quaternion.Euler(-90f, rotation.y, 0f);
//        Quaternion barrelRotation = Quaternion.Euler(rotation.x, partToBarrel.rotation.eulerAngles.y, partToBarrel.rotation.eulerAngles.z);
//        partToBarrel.rotation = Quaternion.Lerp(partToBarrel.rotation, barrelRotation, Time.deltaTime * turnSpeed);

//        // Crit chance
//        if (fireCountdown <= 0f)
//        {
//            Shoot();
//            critValue = Random.Range(1, 101);
//            fireCountdown = fireRate;

//            //if (gameValue.NewFireCountDown == 0.2f)
//            //{
//            //    fireCountdown = 0.2f / fireRate;
//            //}

//        }
//        fireCountdown -= Time.deltaTime;

//    }

//    private void Shoot()
//    {
//        GameObject bulletGo = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
//        source.clip = GameManager.TowerVaribles[0].TowerAttackSFX;
//        source.Play();
//        Bullet bullet = bulletGo.GetComponent<Bullet>();

//        if (bullet != null)
//        {
//            bullet.Seek(target);
//        }
//    }



//}

using System.Collections;
using UnityEngine;

public class TowerTarget : MonoBehaviour
{
    private GameValue gameValue;
    TowerMenu TowerMenu;
    [SerializeField] Transform target;
    GameManager GameManager;
    Enemy Enemy;
    [Header("Attributes")]
    public float fireRate;
    public float fireCountdown;
    public int critValue;
    public int angle;

    [Header("Tower Movements")]
    public Transform partToBody;
    public Transform partToBarrel;
    public float bodyTurnSpeed;
    int barrelTurnSpeed = 1;
    public GameObject bulletPrefab;
    public Transform[] muzzleStartingPosition;
    public Transform[] _muzzleStartingPosition;
    [Header("Tower Bullet Points")]
    public Transform[] firePoints;
    public int firePointIndex = 0;
    public int recoil = 100;

    AudioSource source;

    private void Awake()
    {
        //source = GameManager.AudioVaribles.AudioSource;
        //voices = GameManager.AudioVaribles.AudioClip;
    }

    private void Start()
    {
        gameValue = FindObjectOfType<GameValue>();
        GameManager = FindObjectOfType<GameManager>();
        Enemy = FindObjectOfType<Enemy>();
        TowerMenu = FindObjectOfType<TowerMenu>();
        source = GameManager.gameObject.GetComponent<AudioSource>();
        InvokeRepeating("UpdateTarget", 0f, 0.5f);

        muzzleStartingPosition[0].position = _muzzleStartingPosition[0].position;
        muzzleStartingPosition[1].position = _muzzleStartingPosition[1].position;
        muzzleStartingPosition[2].position = _muzzleStartingPosition[2].position;
        muzzleStartingPosition[3].position = _muzzleStartingPosition[3].position;
        muzzleStartingPosition[4].position = _muzzleStartingPosition[4].position;
        muzzleStartingPosition[5].position = _muzzleStartingPosition[5].position;

    }

    private void UpdateTarget()
    {
        GameObject[] Robots = GameObject.FindGameObjectsWithTag("Enemy");

        float shortestDistance = Mathf.Infinity;
        GameObject TargetEnemy = null;
        int ActiveWaypointNumber = 0;
        float ActiveWaypointDistance = 1000f;

        for (int i = 0; i < Robots.Length; i++)
        {
            shortestDistance = Vector3.Distance(transform.position, Robots[i].transform.position);

            if (Robots[i].GetComponent<Enemy>().NextWaypointNumber >= ActiveWaypointNumber && Robots[i].GetComponent<Enemy>().NextWaypointDistance <= ActiveWaypointDistance && shortestDistance <= TowerMenu.sniperTowerRange)
            {
                TargetEnemy = Robots[i];
                ActiveWaypointDistance = Robots[i].GetComponent<Enemy>().NextWaypointDistance;
                ActiveWaypointNumber = Robots[i].GetComponent<Enemy>().NextWaypointNumber;
            }
        }

        if (TargetEnemy != null && Vector3.Distance(transform.position, TargetEnemy.transform.position) <= TowerMenu.sniperTowerRange)
            target = TargetEnemy.transform;
        else
            target = null;
    }

    private void Update()
    {

        if (target == null)
            return;

        // Target lock on
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(partToBody.rotation, lookRotation, Time.deltaTime * bodyTurnSpeed).eulerAngles;
        partToBody.rotation = Quaternion.Euler(0, rotation.y, 0f);

        // Barrel rotation towards the target
        Vector3 barrelDir = target.position - partToBarrel.position;
        Quaternion barrelLookRotation = Quaternion.LookRotation(barrelDir);
        Vector3 barrelEulerAngles = barrelLookRotation.eulerAngles;


        // Yeni rotasyonu hesapla
        Quaternion barrelRotation = Quaternion.Euler(barrelEulerAngles.x, barrelEulerAngles.y, barrelEulerAngles.z);
        partToBarrel.rotation = Quaternion.Lerp(partToBarrel.rotation, barrelRotation, Time.deltaTime * (barrelTurnSpeed));

        // Crit chance
        if (fireCountdown <= 0f)
        {
            Shoot();
            //critValue = Random.Range(1, 101);
            fireCountdown = fireRate;
        }

        fireCountdown -= Time.deltaTime;
    }

    private void Shoot()
    {
        if (TowerMenu.sniperTowerCount == 0)
        {
            SpawnBullet(firePoints[0]);
            MoveFirePointBackwards();
            
        }

        if (TowerMenu.sniperTowerCount == 1)
        {
            if (firePointIndex == 0)
            {
                SpawnBullet(firePoints[2]);
                firePointIndex++;
            }

            else if (firePointIndex == 1)
            {
                SpawnBullet(firePoints[1]);
                firePointIndex = 0;
            }
        }

        if (TowerMenu.sniperTowerCount == 2)
        {

            if (firePointIndex == 0)
            {
                firePointIndex++;
                SpawnBullet(firePoints[3]);
            }

            else if (firePointIndex == 1)
            {
                firePointIndex++;
                SpawnBullet(firePoints[4]);
            }

            else if (firePointIndex == 2)
            {
                firePointIndex = 0;
                SpawnBullet(firePoints[5]);

            }
        }

        source.clip = GameManager.TowerVaribles[0].TowerAttackSFX;
        source.Play();

        

    }

    private void SpawnBullet(Transform firePoint)
    {
        GameObject bulletGO = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletGO.GetComponent<Bullet>();

        if (bullet != null)
        {
            bullet.Seek(target);
        }
        //firePointLevel1.transform.localPosition = FirePointPositionLevel1;
    }

    void MoveFirePointBackwards()
    {
        muzzleStartingPosition[0].transform.Translate(Vector3.back * Time.deltaTime * recoil);
        muzzleStartingPosition[1].transform.Translate(Vector3.back * Time.deltaTime * recoil);
        muzzleStartingPosition[2].transform.Translate(Vector3.back * Time.deltaTime * recoil);
        muzzleStartingPosition[3].transform.Translate(Vector3.back * Time.deltaTime * recoil);
        muzzleStartingPosition[4].transform.Translate(Vector3.back * Time.deltaTime * recoil);
        muzzleStartingPosition[5].transform.Translate(Vector3.back * Time.deltaTime * recoil);

        

    }

}





