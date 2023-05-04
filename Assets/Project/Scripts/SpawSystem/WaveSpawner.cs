using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
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
    public int waveIndex = 0;
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
        
        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject[] objectsWithTag1 = GameObject.FindGameObjectsWithTag("GorillaRobot");
        GameObject[] objectsWithTag2 = GameObject.FindGameObjectsWithTag("SupurgeRobot");
        
        if (startWaveControl&& (objectsWithTag.Length==0 && objectsWithTag1.Length == 0&&objectsWithTag2.Length == 0))
        {   if (waveIndex <= 11)
            {
                waveCountdown -= Time.deltaTime;
                waveCountdownText.text = Mathf.Round(waveCountdown).ToString();
                
            }
        }
        else
        {
            //_startWave.SetActive(true);
        }



        if (waveIndex <= 11 && waveCountdown <= 0f&&(objectsWithTag.Length == 0 && objectsWithTag1.Length == 0 && objectsWithTag2.Length == 0))
        {
            Debug.Log("otomatik çalýþtý");
                waveIndex++;
                Quaity.WaveValue(1);
                StartCoroutine(SpawnWave());
                waveCountdown = timeBetweenWaves[waveIndex - 1];
                //startWaveControl = false;
                _startWave.SetActive(true);
                if(waveIndex>=11)
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
}
