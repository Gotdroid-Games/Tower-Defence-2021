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

    private void Awake()
    {
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

                    if (distance < MainDistance)
                    {
                        Enemy enemy = obj.GetComponent<Enemy>();
                        if (enemy != null && enemy.currentHealth < 100)
                        {
                            enemy.currentHealth += 10;
                            healtbar.SetHealth(enemy.currentHealth);
                        }
                    }
                }

            }
        }
        

    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, MainDistance);
    }

}
