using System.Collections;
using UnityEngine;
using TMPro;

public class WaveSpawner : MonoBehaviour
{
    Quaity Quaity;

    [SerializeField] private GameObject _startWave;
    [SerializeField] private Transform enemyPrefab1;
    [SerializeField] private Transform enemyPrefab2;
    [SerializeField] private Transform enemyPrefab3;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private TextMeshProUGUI waveCountdownText;

    private bool startWaveControl;
    public float[] timeBetweenWaves;
    public float waveCountdown;
    private int waveIndex = 0;

    public int[] enemy1Counts;
    public int[] enemy2Counts;
    public int[] enemy3Counts;

    private void Start()
    {
        startWaveControl = false;
        waveCountdown = timeBetweenWaves[0];
        Quaity = FindObjectOfType<Quaity>();
    }

    private void Update()
    {
        if (startWaveControl)
        {   if (waveIndex <= 11)
            {
                waveCountdown -= Time.deltaTime;
                waveCountdownText.text = Mathf.Round(waveCountdown).ToString();
            }
        }
        else
        {
            _startWave.SetActive(true);
        }



        if (waveIndex <= 11 && waveCountdown <= 0f)
        {
           
            waveIndex++;
            StartCoroutine(SpawnWave());
            Debug.Log(waveIndex);
            waveCountdown = timeBetweenWaves[waveIndex-1];
            startWaveControl = false;
        }
    }

    public void StartWave()
    {
        startWaveControl = true;
        _startWave.SetActive(false);
        Quaity.WaveValue(1);
        
        
        waveCountdown = timeBetweenWaves[waveIndex];
    }

    private IEnumerator SpawnWave()
    {


        if (waveIndex <= 11)
        {

            

            for (int i = 0; i < enemy1Counts[waveIndex-1]; i++)
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

    private void SpawnEnemy(Transform enemyPrefab)
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
