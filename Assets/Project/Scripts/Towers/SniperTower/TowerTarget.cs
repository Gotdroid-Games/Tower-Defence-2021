using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class TowerTarget : MonoBehaviour
{
    private GameValue gameValue;
    public TowerMenu TowerMenu;
    [SerializeField] Transform target;
    //GameManager GameManager;
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
    public Transform[] muzzlePosition;
    [Header("Tower Bullet Points")]
    public Transform[] firePoints;
    public sbyte firePointIndex = 0;
    public float recoil;
    public float RecoilSpeed;
    public GameObject Muzzle;

    AudioSource source;
    AudioManager audiomanager;
    private void Start()
    {
        if(TowerMenu.Head != null)
            partToBody.rotation = TowerMenu.Head.rotation;

        gameValue = FindObjectOfType<GameValue>();
        //GameManager = FindObjectOfType<GameManager>();
        Enemy = FindObjectOfType<Enemy>();
        TowerMenu = FindObjectOfType<TowerMenu>();
        audiomanager = FindObjectOfType<AudioManager>();
        source = audiomanager.GetComponent<AudioSource>();
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
        partToBarrel.rotation = Quaternion.Lerp(partToBarrel.rotation, barrelRotation, Time.deltaTime * barrelTurnSpeed);

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
            StartCoroutine(MoveFirePointForwards());
        }

        if (TowerMenu.sniperTowerCount == 1)
        {
            if (firePointIndex == 0)
            {
                SpawnBullet(firePoints[1]);
                MoveFirePointBackwards();
                StartCoroutine(MoveFirePointForwards());
                firePointIndex++;
            }

            else if (firePointIndex == 1)
            {
                SpawnBullet(firePoints[2]);
                MoveFirePointBackwards();
                StartCoroutine(MoveFirePointForwards());
                firePointIndex = 0;
            }
        }

        if (TowerMenu.sniperTowerCount == 2)
        {

            if (firePointIndex == 0)
            {
                SpawnBullet(firePoints[3]);
                MoveFirePointBackwards();
                StartCoroutine(MoveFirePointForwards());
                firePointIndex++;
                Debug.Log("Sol Ateþ Etti");
            }

            else if (firePointIndex == 1)
            {
                SpawnBullet(firePoints[5]);
                MoveFirePointBackwards();
                StartCoroutine(MoveFirePointForwards());
                firePointIndex++;
                Debug.Log("Orta Ateþ Etti");
            }

            else if (firePointIndex == 2)
            {
                SpawnBullet(firePoints[4]);
                MoveFirePointBackwards();
                StartCoroutine(MoveFirePointForwards());
                firePointIndex = 0;
                Debug.Log("Sað Ateþ Etti");
            }
        }

        audiomanager.PlaySFX("AttackSFX");



    }

    private void SpawnBullet(Transform firePoint)
    {
        GameObject bulletGO = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        GameObject MuzzleCopy = Instantiate(Muzzle, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletGO.GetComponent<Bullet>();
        MuzzleCopy.transform.parent = firePoint.transform;
        MuzzleCopy.transform.localScale = Vector3.one;

        Destroy(MuzzleCopy, 5f);

        if (bullet != null)
        {
            bullet.Seek(target);
        }
    }

    void MoveFirePointBackwards()
    {
        switch ((TowerMenu.sniperTowerCount, firePointIndex))
        {
            case (0, _):
                muzzlePosition[0].transform.transform.GetComponent<Recoil>().GunRecoil(recoil, RecoilSpeed);
                break;
            case (1, 0):
                muzzlePosition[1].transform.transform.GetComponent<Recoil>().GunRecoil(recoil, RecoilSpeed);
                break;
            case (1, 1):
                muzzlePosition[2].transform.transform.GetComponent<Recoil>().GunRecoil(recoil, RecoilSpeed);
                break;
            case (2, 0):
                muzzlePosition[3].transform.transform.GetComponent<Recoil>().GunRecoil(recoil, RecoilSpeed);
                break;
            case (2, 2):
                muzzlePosition[4].transform.transform.GetComponent<Recoil>().GunRecoil(recoil, RecoilSpeed);
                break;
            case (2, 1):
                muzzlePosition[5].transform.transform.GetComponent<Recoil>().GunRecoil(recoil, RecoilSpeed);
                break;
        }
    }

    IEnumerator MoveFirePointForwards()
    {
        yield return new WaitForSeconds(0.1f);

        (int sniperTowerCount, int firePointIndeX) = (TowerMenu.sniperTowerCount, firePointIndex);

        muzzlePosition[sniperTowerCount switch
        {
            0 => 0,
            1 when firePointIndex == 1 => 1,
            1 when firePointIndex == 0 => 2,
            2 when firePointIndex == 1 => 3,
            2 when firePointIndex == 0 => 4,
            2 when firePointIndex == 2 => 5,
            _ => -1
        }].transform.GetComponent<Recoil>().GunRecoil(0f, RecoilSpeed / 3);
    }

}





