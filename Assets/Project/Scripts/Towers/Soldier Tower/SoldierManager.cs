using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierManager : MonoBehaviour
{
    [Header("Transforms")]

    [SerializeField] Transform SoldierSpawnPoint;
    [SerializeField] Transform[] SoldierDefaultPositions;

    [Header("Soldiers")]

    [SerializeField] GameObject[] Soldiers;


    private void Start()
    {
        for (int i = 0; i < SoldierDefaultPositions.Length; i++)
            Soldiers[i].GetComponent<Soldiers>().DefaultPoint = SoldierDefaultPositions[i].transform;
    }

    void SpawnSoldier()
    {
        for (int i = 0; i < Soldiers.Length; i++)
        {
            if (!Soldiers[i].activeSelf)
            {
                Soldiers[i].SetActive(true);
                Soldiers[i].transform.position = SoldierSpawnPoint.position;
            }
        }
    }

    public void Upgrade(int Level)
    {
        for (int i = 0; i < Soldiers.Length; i++)
        {
            Soldiers[i].GetComponent<Soldiers>().Upgrade(Level);
        }
    }
}
