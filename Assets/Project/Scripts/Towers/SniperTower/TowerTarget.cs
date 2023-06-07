using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class TowerTarget : MonoBehaviour
{
    private GameValue gameValue;
    private RangeUpgrade rangeUpgrade;
    TowerMenu TowerMenu;
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
    AudioSource source;

    private void Awake()
    {

        //source = GameManager.AudioVaribles.AudioSource;
        //voices = GameManager.AudioVaribles.AudioClip;
    }
    private void Start()
    {

        gameValue = FindObjectOfType<GameValue>();
        rangeUpgrade = FindObjectOfType<RangeUpgrade>();
        GameManager = FindObjectOfType<GameManager>();
        Enemy = FindObjectOfType<Enemy>();
        TowerMenu = FindObjectOfType<TowerMenu>();
        source = GameManager.gameObject.GetComponent<AudioSource>();
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
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
            shortestDistance = Vector3.Distance(this.transform.position, Robots[i].transform.position);

            if(Robots[i].GetComponent<Enemy>().NextWaypointNumber >= ActiveWaypointNumber && Robots[i].GetComponent<Enemy>().NextWaypointDistance <= ActiveWaypointDistance && shortestDistance <= TowerMenu.sniperTowerRange)
            {
                TargetEnemy = Robots[i];
                ActiveWaypointDistance = Robots[i].GetComponent<Enemy>().NextWaypointDistance;
                ActiveWaypointNumber = Robots[i].GetComponent<Enemy>().NextWaypointNumber;
            }
        }

        if (TargetEnemy != null && Vector3.Distance(this.transform.position, TargetEnemy.transform.position) <= TowerMenu.sniperTowerRange)
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
        source.clip = GameManager.TowerVaribles[0].TowerAttackSFX;
        source.Play();
        Bullet bullet = bulletGo.GetComponent<Bullet>();

        if (bullet != null)
        {
            bullet.Seek(target);
        }
    }



}
