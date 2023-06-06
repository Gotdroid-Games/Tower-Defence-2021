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

    [Header("Wave Texts")]
    [SerializeField] private TextMeshProUGUI waveCountdownText;
    [SerializeField] private TextMeshProUGUI waveStartInfoText;

    [Header("Time Control Variables")]
    public float waveCountdown;
    public float spawnTime;
    public int waveIndex = 0;
    private bool startWaveControl;
    string waveStartInfo;
    int totalEnemies = 0;
    public int totalenemiescheck = 0;
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

    GameObject SelectedRobot;
    float WaitForSec;



    private void Start()
    {
        Quaity = FindObjectOfType<Quaity>();
        GameUI = FindObjectOfType<GameUI>();
        GameManager = FindObjectOfType<GameManager>();
        startWaveControl = false;
        waveCountdown = GameManager.Waves[0].TimeBetweenWaves;

        basicRobotWaveInfo = new string[basicRobot.Length];
        gorillaRobotWaveInfo = new string[gorillaRobot.Length];
        smarthomeRobotWaveInfo = new string[smarthomeRobot.Length];
        droneRobotWaveInfo = new string[DroneRobot.Length];

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

        if (waveIndex <= 12 && waveCountdown <= 0f && spawnedEnemies == totalEnemies && startWaveControl == true)
        {
            waveIndex++;
            Quaity.WaveValue();
            StartCoroutine(SpawnWave());
            waveCountdown = GameManager.Waves[waveIndex - 1].TimeBetweenWaves;
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
        if (waveIndex >= 12)
        {
            GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Enemy");
            totalenemiescheck = objectsWithTag.Length;

        }
    }

    public void StartWave()
    {
        if (waveIndex <= GameManager.Waves.Count)
        {
            waveIndex++;
            startWaveControl = true;
            _startWave.SetActive(false);
            Quaity.WaveValue();
            waveCountdown = GameManager.Waves[waveIndex].TimeBetweenWaves;
            StartCoroutine(SpawnWave());
        }
    }

    public void WaveInfo(GameManager gameManager)
    {/*
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
        */
    }

        private IEnumerator SpawnWave()
    {   
        if (waveIndex > 0 && waveIndex <= GameManager.Waves.Count)
        {
            for (int i = 0; i < GameManager.Waves[waveIndex - 1].WaveVariables.Count; i++)
            {
                for (int a = 0; a < GameManager.Waves[waveIndex - 1].WaveVariables[i].SpawnerEnemy; a++)
                {
                    for (int x = 0; x < EnemyManager.Instance.Enemies.Length; x++)
                    {
                        if (GameManager.Waves[waveIndex - 1].WaveVariables[i].EnemyType == EnemyManager.Instance.Enemies[x].GetComponent<Enemy>().RobotType)
                            SelectedRobot = EnemyManager.Instance.Enemies[x];
                    }

                    for (int y = 0; y < GameManager.EnemyVariables.Count; y++)
                    {
                        if (GameManager.Waves[waveIndex - 1].WaveVariables[i].EnemyType == GameManager.EnemyVariables[y].enemyType)
                            WaitForSec = GameManager.EnemyVariables[y].enemySpawnTime;
                    }

                    SpawnEnemy(SelectedRobot, GameManager.Waves[waveIndex - 1].WaveVariables[i].ActiveSpawner);
                    yield return new WaitForSeconds(WaitForSec);
                }
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

    private void SpawnEnemy(GameObject enemyPrefab, Transform spawnPoint)
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
        GameManager.Instance.RefreshRobotList();
    }

    public void PanelActive()
    {
        GameUI._Button.GameUIButtons[14].SetActive(true);
        Debug.Log("Ýnfo Butonu Aktif");
        
    }

    public void PanelPassive()
    {
        GameUI._Button.GameUIButtons[14].SetActive(false);
    }

    public void StartWaveCoin()
    {
        Quaity.WaveStartCoinFunction();
        StartWave();
    }
}
