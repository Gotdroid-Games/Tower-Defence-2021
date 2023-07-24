using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soldiers : MonoBehaviour
{
    public float health;
    public float speed;
    private float attackTime = 0;
    private GameObject currentEnemy; // Þu anda hedeflenen düþman
    public float enemyattackrange;
    public float soldierenemydistance;

    private void FixedUpdate()
    {
        if(health<=0)
        {
            Destroy(gameObject);
        }
        // Hedeflenen düþman yoksa veya hedeflenen düþmanýn saðlýðý sýfýrsa, yeni bir düþman belirle
        if (currentEnemy == null || currentEnemy.GetComponent<Enemy>().currentHealth <= 0)
        {
            currentEnemy = FindNearestEnemy();
        }

        if (currentEnemy != null)
        {
            // Düþmana doðru hareket et
            transform.position += (currentEnemy.transform.position - transform.position) * speed * Time.deltaTime;

            // Düþmana yaklaþýldýðýnda saldýrý gerçekleþtir
            if (Vector3.Distance(transform.position, currentEnemy.transform.position) < 5f)
            {
                //currentEnemy.GetComponent<Enemy>().Soldierinside = true;
                attackTime += Time.fixedDeltaTime;

                
                if (Vector3.Distance(transform.position, currentEnemy.transform.position) < soldierenemydistance)
                {
                    transform.position = currentEnemy.transform.position + (transform.position - currentEnemy.transform.position).normalized * soldierenemydistance;
                }

                if (attackTime >= 1f)
                {
                    attackTime = 0;
                    currentEnemy.GetComponent<Enemy>().TakeDamage();
                }
            }
        }
    }

    private GameObject FindNearestEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        float minDistance = enemyattackrange;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            // Düþmanýn saðlýðý sýfýrdan büyük olduðunda ve askere olan uzaklýk daha önceki en yakýn düþmandan daha yakýnsa, yeni düþmaný ata
            if (enemy.GetComponent<Enemy>().currentHealth > 0 && Vector3.Distance(transform.position, enemy.transform.position) < minDistance)
            {
                minDistance = Vector3.Distance(transform.position, enemy.transform.position);
                nearestEnemy = enemy;
            }
        }

        return nearestEnemy;
    }
}
