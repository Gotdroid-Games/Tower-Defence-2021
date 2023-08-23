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
    [SerializeField] int DamageCooldown;
    [SerializeField] bool Fight;

    [Header("Levels")]

    [SerializeField] int Level;
    [SerializeField] Transform[] Levels;



    private void Start()
    {
        InvokeRepeating("GetEnemy", 0f, 0.5f);
    }

    private void Update()
    {
        if (CurrentEnemy == null)
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, DefaultPoint.position, Speed * Time.deltaTime);
            this.transform.LookAt(DefaultPoint.position);
        }

        else
        {

            this.transform.position = Vector3.MoveTowards(this.transform.position, CurrentEnemy.position, Speed * Time.deltaTime);
            this.transform.LookAt(CurrentEnemy.position);
            CurrentEnemy.GetComponent<Enemy>().SoldierTransform = this.transform;

            // Fight

            CurrentEnemy.GetComponent<Enemy>().Aim = true;

            if (Vector3.Distance(this.transform.position, CurrentEnemy.position) < 1f)
            {
                CurrentEnemy.GetComponent<Enemy>().Fight = true;
            }

            if (Vector3.Distance(this.transform.position, Tower.position) > Range)
            {
                CurrentEnemy.GetComponent<Enemy>().Aim = false;
                CurrentEnemy.GetComponent<Enemy>().Fight = false;
                CurrentEnemy.GetComponent<Enemy>().SoldierTransform = null;
                CurrentEnemy = null;
            }
        }
    }

    public void TakeDamage(int damage)
    {
        Heath -= damage;

        if (Heath <= 0)
            Destroy(this.gameObject);
    }

    public void GiveDamage(int damage)
    {
        CurrentEnemy.GetComponent<Enemy>().TakeDamageFromSoldier(damage);
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

                if (CurrentEnemy.GetComponent<Enemy>().Aim && CurrentEnemy.GetComponent<Enemy>().SoldierTransform != this.transform)
                    CurrentEnemy = null;
            }
        }
    }
}
