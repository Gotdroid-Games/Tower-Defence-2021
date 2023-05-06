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
    

    
    [Header("Enemy List")]
    public int[] basicRobot;
    public int[] gorillaRobot;
    public int[] smarthomeRobot;
    public int[] DroneRobot;

    [Header("Enemy Spawn Info")]
    string[] basicRobotWaveInfo;
    string[] gorillaRobotWaveInfo;
    string[] smarthomeRobotWaveInfo;
    string[] droneRobotWaveInfo;



    private void Start()
    {
       
        startWaveControl = false;
        waveCountdown = timeBetweenWaves[0];
        Quaity = FindObjectOfType<Quaity>();
        GameUI = FindObjectOfType<GameUI>();
        basicRobotWaveInfo = new string[basicRobot.Length];
        gorillaRobotWaveInfo = new string[gorillaRobot.Length];
        smarthomeRobotWaveInfo = new string[smarthomeRobot.Length];
        droneRobotWaveInfo = new string[DroneRobot.Length];

    }

    private void Update()
    {
        
        
        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject[] objectsWithTag1 = GameObject.FindGameObjectsWithTag("GorillaRobot");
        GameObject[] objectsWithTag2 = GameObject.FindGameObjectsWithTag("SupurgeRobot");

        if (startWaveControl && (objectsWithTag.Length == 0 && objectsWithTag1.Length == 0 && objectsWithTag2.Length == 0))
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

        if (waveIndex <= 11 && waveCountdown <= 0f && (objectsWithTag.Length == 0 && objectsWithTag1.Length == 0 && objectsWithTag2.Length == 0))
        {
            Debug.Log("otomatik çalýþtý");
            waveIndex++;
            Quaity.WaveValue(1);
            StartCoroutine(SpawnWave());
            waveCountdown = timeBetweenWaves[waveIndex - 1];
            //startWaveControl = false;
            _startWave.SetActive(false);
            if (waveIndex >= 11)
            {
                _startWave.SetActive(false);
            }
        }

        

        WaveInfo();
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

    public void WaveInfo()
    {
        //Dalga butonunun üzerine fare ile gelindiðinde aktif olan image içerisine hangi düþmandan kaç adet geleceðini belirten sistem
        //113 - 114 satýrlarý arasýnda bulunan kodlar 33 - 35 satýrlarý arasýnda bulunan dizilerini string olarak dönüþtürüp basicRobotWaveInfo 113 - 114 arasýnda bulunan deðiþkenlerine atama yapýyor

        string[] basicRobotWaveInfo = Array.ConvertAll(basicRobot, x => x.ToString());
        string[] gorillaRobotWaveInfo = Array.ConvertAll(gorillaRobot, x => x.ToString());
        string[] smarthomeRobotWaveInfo = Array.ConvertAll(smarthomeRobot, x => x.ToString());
        string[] droneRobotWaveInfo = Array.ConvertAll(DroneRobot, x => x.ToString());

        if (waveIndex >= 0 && waveIndex <= 12)
        {
            waveStartInfoText.text = waveStartInfo;

            var robotInfos = new (string, string[])[]
            {
        ("Temel Düþman", basicRobotWaveInfo),
        ("Goril Robot", gorillaRobotWaveInfo),
        ("Akýllý Ev Süpürgesi", smarthomeRobotWaveInfo),
        ("Drone Robot", droneRobotWaveInfo)
            };

            waveStartInfo = string.Join("\n", robotInfos
                .Where(r => r.Item2[waveIndex] != "0")
                .Select(r => $"{r.Item1} {r.Item2[waveIndex]}"));
        }
    }



    private IEnumerator SpawnWave()
    {
        int totalEnemies = basicRobot[waveIndex - 1] + gorillaRobot[waveIndex - 1] + smarthomeRobot[waveIndex - 1] + DroneRobot[waveIndex - 1];
        int spawnedEnemies = 0;
        

        if (waveIndex > 0 && waveIndex <= 11)
        {
            for (int i = 0; i < basicRobot[waveIndex - 1]; i++)
            {
                SpawnEnemy(basicRobotPrefab);
                yield return new WaitForSeconds(spawnTime);
                spawnedEnemies++;   
            }

            for (int i = 0; i < gorillaRobot[waveIndex - 1]; i++)
            {
                SpawnEnemy(gorillaRobotPrefab);
                yield return new WaitForSeconds(spawnTime);
                spawnedEnemies++;
            }

            for (int i = 0; i < smarthomeRobot[waveIndex - 1]; i++)
            {
                SpawnEnemy(smartHomeRobotPrefab);
                yield return new WaitForSeconds(spawnTime);
                spawnedEnemies++;
            }
            for (int i = 0; i < DroneRobot[waveIndex - 1]; i++)
            {
                SpawnEnemy(DronePrefab);
                yield return new WaitForSeconds(spawnTime);
                spawnedEnemies++;
            }
        }
        if (spawnedEnemies == totalEnemies)
        {
            yield return new WaitForSeconds(3f);
            _startWave.SetActive(true);
            
        }


    }

    private void SpawnEnemy(Transform enemyPrefab)
    {   
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
        
        
        
    }

    public void PanelActive()
    {
        GameUI._Button.GameUIButtons[14].SetActive(true);
        Debug.Log("Ýnfo Butonu Aktif");
    }

    public void PanelPassive()
    {
        GameUI._Button.GameUIButtons[14].SetActive(false);
        Debug.Log("Ýnfo Butonu Pasif");
    }
}
