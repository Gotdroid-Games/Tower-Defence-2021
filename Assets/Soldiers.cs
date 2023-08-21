using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soldiers : MonoBehaviour
{
    public Transform DefaultPoint;
    public Transform CurrentEnemy;
    public Transform Tower;

    [Header("Variables")]

    [SerializeField] int Heath;
    [SerializeField] int Speed;
    [SerializeField] int Damage;
    [SerializeField] int Range;

    [Header("Levels")]

    [SerializeField] int Level;
    [SerializeField] Transform[] Levels;



    private void Start()
    {
        InvokeRepeating("GetEnemy", 0f, 0.5f);
    }

    private void Update()
    {
        if(CurrentEnemy == null)
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, DefaultPoint.position, Speed * Time.deltaTime);
            this.transform.LookAt(DefaultPoint.position);
        }

        else
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, CurrentEnemy.position, Speed * Time.deltaTime);
            this.transform.LookAt(CurrentEnemy.position);

            if (Vector3.Distance(this.transform.position, Tower.position) > Range)
                CurrentEnemy = null;
        }
    }

    public void TakeDamage (int damage)
    {
        Heath -= damage;

        if (Heath <= 0)
            Destroy(this.gameObject);
    }

    public void Upgrade(int level)
    {
        Level = level;

        for (int i = 0; i < Levels.Length; i++)
        {
            if (i == Level)
                Levels[i].gameObject.SetActive(true);
            else
                Levels[i].gameObject.SetActive(false);

        }
    }

    public void GetEnemy()
    {
        GameObject[] Enemies = GameObject.FindGameObjectsWithTag("Enemy");

        for (int i = 0; i < Enemies.Length; i++)
        {
            if (Vector3.Distance(this.transform.position, Enemies[i].transform.position) <= Range)
            {
                CurrentEnemy = Enemies[i].transform;
            }
        }
    }
}
