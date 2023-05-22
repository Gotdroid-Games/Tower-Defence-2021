using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;
using System.Linq;

public class WaveSpawner : MonoBehaviour
{
    Quaity Quaity;
    GameUI GameUI;
    GameManager GameManager;

    [SerializeField] private GameObject _startWave;

    [Header("Enemy Prefabs")]
    [SerializeField] private Transform basicRobotPrefab;
    [SerializeField] private Transform gorillaRobotPrefab;
    [SerializeField] private Transform smartHomeRobotPrefab;
    [SerializeField] private Transform DronePrefab;

    [SerializeField] private Transform spawnPoint;

    
    [Header("Wave Texts")]
    [SerializeField] private TextMeshProUGUI waveCountdownText;
    [SerializeField] private TextMeshProUGUI waveStartInfoText;

    [Header("Time Control Variables")]
    public float waveCountdown;
    public float spawnTime;
    public int waveIndex = 0;
    private bool startWaveControl;
    public float[] timeBetweenWaves;
    string waveStartInfo;
    int totalEnemies = 0;
    int spawnedEnemies = 0;




    [Header("Enemy List")]
    public int[] basicRobot;
    public int[] gorillaRobot;
    public int[] smarthomeRobot;
    public int[] DroneRobot;

    [Header("Enemy Spawn Info")]
    public string[] basicRobotWaveInfo;
    public string[] gorillaRobotWaveInfo;
    public string[] smarthomeRobotWaveInfo;
    public string[] droneRobotWaveInfo;

    public GameObject Arrowprefab;

    private void Start()
    {
        startWaveControl = false;
        waveCountdown = timeBetweenWaves[0];
        Quaity = FindObjectOfType<Quaity>();
        GameUI = FindObjectOfType<GameUI>();
        GameManager = FindObjectOfType<GameManager>();

        basicRobotWaveInfo = new string[basicRobot.Length];
        gorillaRobotWaveInfo = new string[gorillaRobot.Length];
        smarthomeRobotWaveInfo = new string[smarthomeRobot.Length];
        droneRobotWaveInfo = new string[DroneRobot.Length];

    }

    private void Update()
    {
        WaveInfo(GameManager);

        //GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Enemy");
        //GameObject[] objectsWithTag1 = GameObject.FindGameObjectsWithTag("GorillaRobot");
        //GameObject[] objectsWithTag2 = GameObject.FindGameObjectsWithTag("SupurgeRobot");

        if (startWaveControl == true && spawnedEnemies == totalEnemies)
        {

            if (waveIndex <= 11)
            {
                waveCountdown -= Time.deltaTime;
                waveCountdownText.text = Mathf.Round(waveCountdown).ToString();
            }
        }

        else
        {
            //_startWave.SetActive(true);
        }

        if (waveIndex <= 11 && waveCountdown <= 0f && spawnedEnemies == totalEnemies)
        {
            Debug.Log("otomatik çalýþtý");
            Debug.Log(totalEnemies);
            Debug.Log(spawnedEnemies);
            waveIndex++;
            Quaity.WaveValue(1);
            StartCoroutine(SpawnWave());
            waveCountdown = timeBetweenWaves[waveIndex - 1];

            _startWave.SetActive(false);
            if (waveIndex >= 11)
            {
                _startWave.SetActive(false);
            }
        }






    }

    public void StartWave()
    {
        if (waveIndex <= 11)
        {
            Debug.Log("basma çalýþtý");
            waveIndex++;
            startWaveControl = true;
            _startWave.SetActive(false);
            Quaity.WaveValue(1);
            waveCountdown = timeBetweenWaves[waveIndex];
            StartCoroutine(SpawnWave());


        }
    }

    public void WaveInfo(GameManager gameManager)
    {
        //Dalga butonunun üzerine fare ile gelindiðinde aktif olan image içerisine hangi düþmandan kaç adet geleceðini belirten sistem
        //138 - 141 satýrlarý arasýnda bulunan kodlar 38 - 41 satýrlarý arasýnda bulunan dizilerini string olarak dönüþtürüp basicRobotWaveInfo 138 - 141 arasýnda bulunan deðiþkenlerine atama yapýyor

        if (waveIndex < 0)
        {
            waveIndex = 0;
        }
        else if (waveIndex > 12)
        {
            waveIndex = 12;
        }

        waveStartInfoText.text = waveStartInfo;

        var basicRobotWaveInfo = gameManager._basicRobot.Select(x => x.ToString()).ToArray();
        var gorillaRobotWaveInfo = gameManager._gorillaRobot.Select(x => x.ToString()).ToArray();
        var smarthomeRobotWaveInfo = gameManager._smartHomeRobot.Select(x => x.ToString()).ToArray();
        var droneRobotWaveInfo = gameManager._droneRobot.Select(x => x.ToString()).ToArray();

        var robotInfos = new (string, string[])[]
        {
    ("Temel Düþman", basicRobotWaveInfo),
    ("Goril Robot", gorillaRobotWaveInfo),
    ("Akýllý Ev Süpürgesi", smarthomeRobotWaveInfo),
    ("Drone Robot", droneRobotWaveInfo)
        };

        waveStartInfo = string.Join("\n", robotInfos
            .Where(r => r.Item2.Length > waveIndex && r.Item2[waveIndex] != "0")
            .Select(r => $"{r.Item1} {r.Item2[waveIndex]}"));
    }

    private IEnumerator SpawnWave()
    {
        totalEnemies = basicRobot[waveIndex - 1] + gorillaRobot[waveIndex - 1] + smarthomeRobot[waveIndex - 1] + DroneRobot[waveIndex - 1];



        if (waveIndex > 0 && waveIndex <= 11)
        {
            for (int i = 0; i < basicRobot[waveIndex - 1]; i++)
            {
                SpawnEnemy(basicRobotPrefab);
                yield return new WaitForSeconds(GameManager.EnemyVariables[0].enemySpawnTime);
                spawnedEnemies++;
            }

            for (int i = 0; i < gorillaRobot[waveIndex - 1]; i++)
            {
                SpawnEnemy(gorillaRobotPrefab);
                yield return new WaitForSeconds(GameManager.EnemyVariables[1].enemySpawnTime);
                spawnedEnemies++;
            }

            for (int i = 0; i < smarthomeRobot[waveIndex - 1]; i++)
            {
                SpawnEnemy(smartHomeRobotPrefab);
                yield return new WaitForSeconds(GameManager.EnemyVariables[2].enemySpawnTime);
                spawnedEnemies++;
            }
            for (int i = 0; i < DroneRobot[waveIndex - 1]; i++)
            {
                SpawnEnemy(DronePrefab);
                yield return new WaitForSeconds(GameManager.EnemyVariables[3].enemySpawnTime);
                spawnedEnemies++;
            }
        }
        if (spawnedEnemies == totalEnemies)
        {
            yield return new WaitForSeconds(GameManager.WaveStartTimeAdjustment);//buradan wavespawn olduktan sonra kaçsaniye sonra buton aktif olsun ona bakýyoruz
            _startWave.SetActive(true);

        }
        totalEnemies = 0;
        spawnedEnemies = 0;

    }

    private void SpawnEnemy(Transform enemyPrefab)
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
        GameManager.Instance.RefreshRobotList();
    }

    public void PanelActive()
    {
        GameUI._Button.GameUIButtons[14].SetActive(true);
        Debug.Log("Ýnfo Butonu Aktif");
        if (GameUI._Button.GameUIButtons[14].activeSelf)
        {
           Arrowprefab.gameObject.SetActive(true);
        }
    }

    public void PanelPassive()
    {
        GameUI._Button.GameUIButtons[14].SetActive(false);
        Debug.Log("Ýnfo Butonu Pasif");
    }

    public void StartWaveCoin()
    {
        Quaity.WaveStartCoinFunction();
        StartWave();
    }
}
