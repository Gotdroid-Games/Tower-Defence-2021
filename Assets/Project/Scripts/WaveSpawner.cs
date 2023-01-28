using System.Collections;
using UnityEngine;
using TMPro;

public class WaveSpawner : MonoBehaviour
{
    public Transform enemyPrefab;

    public Transform spawnPoint;

    public float timeBetweenWaves = 5f;
    float countdown = 2f;

    public TextMeshProUGUI waweCountdownText;

    int waweIndex = 0;

    private void Update()
    {
        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
        }

        countdown-=Time.deltaTime;

        waweCountdownText.text= Mathf.Round(countdown).ToString();
    }

    IEnumerator SpawnWave()
    {
        waweIndex++;

        for (int i = 0; i < waweIndex; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }


        void SpawnEnemy()
        {
            Instantiate(enemyPrefab,spawnPoint.position,spawnPoint.rotation);
        }
    }
}
