using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealerRobot : MonoBehaviour
{
    //Enemy enemy;
    Healthbar healtbar;
    public float MainDistance = 12f;
    public float HealthInterval = 1.5f;
    public float Timer = 0;
    private Enemy enemyy;
    private void Awake()
    {
        enemyy = FindObjectOfType<Enemy>();
        healtbar = FindObjectOfType<Healthbar>();
    }
    void Start()
    {
        
      //  enemy = FindObjectOfType<Enemy>();
    }
    void Update()
    {
        Timer += Time.deltaTime;
        if (Timer > HealthInterval )
        {
            Timer = 0f;
            GameObject[] objectsToDestroy = GameObject.FindGameObjectsWithTag("Enemy");

            foreach (GameObject obj in objectsToDestroy)
            {
                if (obj != null)
                {
                    float distance = Vector3.Distance(transform.position, obj.transform.position);
                    Enemy enemy = obj.GetComponent<Enemy>();
                    if (enemy != null && distance < MainDistance && !enemy.isHealer)
                    {
                       
                        if (  enemy.currentHealth < 100)
                        {
                            enemy.currentHealth += 10;
                            enemy.TakeHealth();
                           // healtbar.SetHealth(enemy.currentHealth);
                        }
                    }
                    else
                    { 
                        ParticleSystem healingEffect = enemy.GetComponentInChildren<ParticleSystem>();
                        if (healingEffect != null)
                        {
                            healingEffect.Stop();
                            healingEffect.Clear();
                        }
                        
                    }
                }

            }
        }

    } 
    private void OnDestroy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (GameObject enemy in enemies)
        {
            // Her düşmanı kontrol edin ve içindeki ParticleSystem'leri bulun
            ParticleSystem healingEffect = enemy.GetComponentInChildren<ParticleSystem>();

            if (healingEffect != null)
            {
                // Eğer bir ParticleSystem bulunursa, etkisini durdurun ve temizleyin
                healingEffect.Stop();
                healingEffect.Clear();
            }
        }
    }

        private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, MainDistance);
    }

}
