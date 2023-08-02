using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public enum EnemyType
    {
        BasicRobot,
        GorillaRobot,
        SmartHomeRobot,
        DroneRobot,
        HealerRobot

    }

    public enum TowerType
    {
        sniperTower,
        bombTower,
        hackerTower,
        soldierTower
    }

    public GameObject[] Enemies;
}
