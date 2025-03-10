using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HackTowerTarget : MonoBehaviour
{
    HackerTowerMenu hackmenu;
    TowerMenu TowerMenu;
    GameManager gamemanager;
    Enemy enemy;
    private GameObject targets;
    public bool inside = false;
    void Start()
    {
        TowerMenu = FindObjectOfType<TowerMenu>();
        targets = GameObject.FindGameObjectWithTag("Enemy");
        hackmenu = FindObjectOfType<HackerTowerMenu>();
        gamemanager = FindObjectOfType<GameManager>();
        enemy = FindObjectOfType<Enemy>();

    }


    void Update()
    {
        GameObject[] objectsToDestroy = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (GameObject obj in objectsToDestroy)
        {
            if (obj != null)
            {
                float distance = Vector3.Distance(transform.position, obj.transform.position);

                if (distance <= hackmenu.hackerTowerRange)
                {
                    obj.GetComponent<Enemy>().inside = true;
                }
                else
                {
                    obj.GetComponent<Enemy>().inside = false;
                }
            }

        }
    }
}

