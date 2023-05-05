using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class WaveSpawner : MonoBehaviour
{
    Quaity Quaity;
    GameUI GameUI;

    [SerializeField] private GameObject _startWave;
    [SerializeField] private Transform enemyPrefab1;
    [SerializeField] private Transform enemyPrefab2;
    [SerializeField] private Transform enemyPrefab3;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private TextMeshProUGUI waveCountdownText;
    [SerializeField] private TextMeshProUGUI waveStartInfoText;

    private bool startWaveControl;
    public float[] timeBetweenWaves;
    public float waveCountdown;
    public int waveIndex = 0;
    public string waveStartInfo;
    public int[] enemy1Counts;
    public int[] enemy2Counts;
    public int[] enemy3Counts;
    public string[] enemy1CountsAsString;
    public string[] enemy2CountsAsString;
    public string[] enemy3CountsAsString;

    

    private void Start()
    {

        startWaveControl = false;
        waveCountdown = timeBetweenWaves[0];
        Quaity = FindObjectOfType<Quaity>();
        GameUI = FindObjectOfType<GameUI>();
        enemy1CountsAsString = new string[enemy1Counts.Length];
        enemy2CountsAsString = new string[enemy2Counts.Length];
        enemy3CountsAsString = new string[enemy3Counts.Length];

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
            _startWave.SetActive(true);
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
        string[] enemy1CountsAsString = Array.ConvertAll(enemy1Counts, x => x.ToString());
        string[] enemy2CountsAsString = Array.ConvertAll(enemy2Counts, x => x.ToString());
        string[] enemy3CountsAsString = Array.ConvertAll(enemy3Counts, x => x.ToString());

        if (waveIndex >= 0 && waveIndex <= 12)
        {
            waveStartInfoText.text = waveStartInfo;
            waveStartInfo = "Temel Düþman " + enemy1CountsAsString[waveIndex] + "\nGoril Robot " + enemy2CountsAsString[waveIndex] + "\nAkýllý Ev Süpürgesi " + enemy3CountsAsString[waveIndex];
        }
    }



    private IEnumerator SpawnWave()
    {


        if (waveIndex <= 11)
        {


            if (waveIndex > 0)
            {
                for (int i = 0; i < enemy1Counts[waveIndex - 1]; i++)
                {
                    SpawnEnemy(enemyPrefab1);
                    yield return new WaitForSeconds(0.5f);

                }

                for (int i = 0; i < enemy2Counts[waveIndex - 1]; i++)
                {
                    SpawnEnemy(enemyPrefab2);
                    yield return new WaitForSeconds(0.5f);
                }

                for (int i = 0; i < enemy3Counts[waveIndex - 1]; i++)
                {
                    SpawnEnemy(enemyPrefab3);
                    yield return new WaitForSeconds(0.5f);
                }
            }
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
