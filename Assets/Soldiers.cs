using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soldiers : MonoBehaviour
{
    public float health;
    public float speed;
    private float attackTime = 0;
    private GameObject currentEnemy; // �u anda hedeflenen d��man
    public float enemyattackrange;
    public float soldierenemydistance;

    private void FixedUpdate()
    {
        if(health<=0)
        {
            Destroy(gameObject);
        }
        // Hedeflenen d��man yoksa veya hedeflenen d��man�n sa�l��� s�f�rsa, yeni bir d��man belirle
        if (currentEnemy == null || currentEnemy.GetComponent<Enemy>().currentHealth <= 0)
        {
            currentEnemy = FindNearestEnemy();
        }

        if (currentEnemy != null)
        {
            // D��mana do�ru hareket et
            transform.position += (currentEnemy.transform.position - transform.position) * speed * Time.deltaTime;

            // D��mana yakla��ld���nda sald�r� ger�ekle�tir
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
            // D��man�n sa�l��� s�f�rdan b�y�k oldu�unda ve askere olan uzakl�k daha �nceki en yak�n d��mandan daha yak�nsa, yeni d��man� ata
            if (enemy.GetComponent<Enemy>().currentHealth > 0 && Vector3.Distance(transform.position, enemy.transform.position) < minDistance)
            {
                minDistance = Vector3.Distance(transform.position, enemy.transform.position);
                nearestEnemy = enemy;
            }
        }

        return nearestEnemy;
    }
}
