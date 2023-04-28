using System.Collections;
using UnityEngine;
using TMPro;

public class WaveSpawner : MonoBehaviour
{
    Quaity Quaity;

    [SerializeField] private GameObject _startWave;
    [SerializeField] private Transform enemyPrefab;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private TextMeshProUGUI waveCountdownText;

    private bool startWaveControl;
    private float timeBetweenWaves = 5f;
    public float countdown = 2f;
    private int waveIndex = 0;

    private void Start()
    {
        startWaveControl = false;
        Quaity=FindObjectOfType<Quaity>();
    }

    private void Update()
    {
        if (startWaveControl)
        {
            countdown -= Time.deltaTime;
            waveCountdownText.text = Mathf.Round(countdown).ToString();
        }
        else
        {
            _startWave.SetActive(true);
        }

        if (countdown <= 0f)
        {
            SpawnWave();
            countdown = timeBetweenWaves;
            startWaveControl = false;
        }
    }

    public void StartWave()
    {
        startWaveControl = true;
        _startWave.SetActive(false);
        Quaity.WaveValue(1);
    }

    private void SpawnWave()
    {
        waveIndex++;

        for (int i = 0; i < waveIndex; i++)
        {
            Invoke("SpawnEnemy", 0.5f * i);
        }
    }

    private void SpawnEnemy()
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}

