using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HackTowerRange : MonoBehaviour
{
    HackerTowerMenu hackmenu;
    GameManager gamemanager;
    private GameObject targets;
    public bool inside = false;
    void Start()
    {
        targets = GameObject.FindGameObjectWithTag("Enemy");
        hackmenu = FindObjectOfType<HackerTowerMenu>();
        gamemanager = FindObjectOfType<GameManager>();
    }

    
    void Update()
    {
        // Tüm objeleri kontrol etmek yerine sadece belirli bir tag'e sahip objeleri kontrol edebilirsiniz.
        GameObject[] objectsToDestroy = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (GameObject obj in objectsToDestroy)
        {
            if (obj != null )
            {
                float distance = Vector3.Distance(transform.position, obj.transform.position);

                if (distance <= hackmenu.hackerTowerRange)
                {
                    gamemanager.EnemyVariables[0]._EnemySpeed = 5;
                }
            }
            
        }
    }
}

