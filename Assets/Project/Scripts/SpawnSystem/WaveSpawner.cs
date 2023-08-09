using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;
using System.Linq;

public class WaveSpawner : MonoBehaviour
{
    GameUI GameUI;
    GameManager GameManager;

    [SerializeField] private GameObject _startWave;

    [Header("Enemy Prefabs")]
    [SerializeField] private Transform basicRobotPrefab;
    [SerializeField] private Transform gorillaRobotPrefab;
    [SerializeField] private Transform smartHomeRobotPrefab;
    [SerializeField] private Transform DronePrefab;
    [SerializeField] private Transform HealerRobotPrefab;

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
    public int totalenemiescheck = 0;
    int spawnedEnemies = 0;




    [Header("Enemy List")]
    public int[] basicRobot;
    public int[] gorillaRobot;
    public int[] smarthomeRobot;
    public int[] DroneRobot;
    public int[] HealerRobot;

    [Header("Enemy Spawn Info")]
    public string[] basicRobotWaveInfo;
    public string[] gorillaRobotWaveInfo;
    public string[] smarthomeRobotWaveInfo;
    public string[] droneRobotWaveInfo;
    public string[] healerRobotWaveInfo;



    private void Start()
    {
        startWaveControl = false;
        waveCountdown = timeBetweenWaves[0];
        GameUI = FindObjectOfType<GameUI>();
        GameManager = FindObjectOfType<GameManager>();

        basicRobotWaveInfo = new string[basicRobot.Length];
        gorillaRobotWaveInfo = new string[gorillaRobot.Length];
        smarthomeRobotWaveInfo = new string[smarthomeRobot.Length];
        droneRobotWaveInfo = new string[DroneRobot.Length];
        healerRobotWaveInfo = new string[HealerRobot.Length];

    }

    private void Update()
    {
        Totalenemycheck();
        WaveInfo(GameManager);


        if (startWaveControl == true && spawnedEnemies == totalEnemies)
        {

            if (waveIndex <= 12)
            {
                waveCountdown -= Time.deltaTime;
                waveCountdownText.text = Mathf.Round(waveCountdown).ToString();
            }
        }

        if (waveIndex <= 12 && waveCountdown <= 0f && spawnedEnemies == totalEnemies)
        {
            waveIndex++;
            GameUI.WaveValue(1);
            StartCoroutine(SpawnWave());
            waveCountdown = timeBetweenWaves[waveIndex - 1];

            _startWave.SetActive(false);
            if (waveIndex >= 12)
            {
                _startWave.SetActive(false);
            }
        }

        if (waveIndex >= 12)
        {
            _startWave.SetActive(false);
            GameUI._Button.GameUIButtons[14].SetActive(false);
        }

    }
    public void Totalenemycheck()
    {
        if (waveIndex>=12)
        {
            GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Enemy");
            totalenemiescheck = objectsWithTag.Length;

        }
    }

    public void StartWave()
    {
        if (waveIndex <= 12)
        {
            waveIndex++;
            startWaveControl = true;
            _startWave.SetActive(false);
            GameUI.WaveValue(1);
            waveCountdown = timeBetweenWaves[waveIndex];
            StartCoroutine(SpawnWave());


        }
    }

    public void WaveInfo(GameManager gameManager)
    {
        //Dalga butonunun �zerine fare ile gelindi�inde aktif olan image i�erisine hangi d��mandan ka� adet gelece�ini belirten sistem
        //138 - 141 sat�rlar� aras�nda bulunan kodlar 38 - 41 sat�rlar� aras�nda bulunan dizilerini string olarak d�n��t�r�p basicRobotWaveInfo 138 - 141 aras�nda bulunan de�i�kenlerine atama yap�yor

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
        var healerRobotWaveInfo = gameManager._healerRobot.Select(x => x.ToString()).ToArray();

        var robotInfos = new (string, string[])[]
        {
    ("Temel D��man", basicRobotWaveInfo),
    ("Goril Robot", gorillaRobotWaveInfo),
    ("Ak�ll� Ev S�p�rgesi", smarthomeRobotWaveInfo),
    ("Drone Robot", droneRobotWaveInfo)
        };

        waveStartInfo = string.Join("\n", robotInfos
            .Where(r => r.Item2.Length > waveIndex && r.Item2[waveIndex] != "0")
            .Select(r => $"{r.Item1} {r.Item2[waveIndex]}"));
    }

    private IEnumerator SpawnWave()
    {
        totalEnemies = basicRobot[waveIndex - 1] + gorillaRobot[waveIndex - 1] + smarthomeRobot[waveIndex - 1] + DroneRobot[waveIndex - 1] + HealerRobot[waveIndex -1];
        


        if (waveIndex > 0 && waveIndex <= 12)
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

            for (int i = 0; i < HealerRobot[waveIndex - 1]; i++)
            {
                SpawnEnemy(HealerRobotPrefab);
                yield return new WaitForSeconds(GameManager.EnemyVariables[4].enemySpawnTime);
                spawnedEnemies++;
            }
        }
        if (spawnedEnemies == totalEnemies)
        {
            yield return new WaitForSeconds(GameManager.WaveStartTimeAdjustment);//buradan wavespawn olduktan sonra ka�saniye sonra buton aktif olsun ona bak�yoruz
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
        GameUI._Button.GameUIButtons[16].SetActive(true);
        Debug.Log("�nfo Butonu Aktif");
        
    }

    public void PanelPassive()
    {
        GameUI._Button.GameUIButtons[16].SetActive(false);
    }

    public void StartWaveCoin()
    {
        GameUI.WaveStartCoinFunction();
        StartWave();
    }
}
