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
        DroneRobot

    }

    public enum TowerType
    {
        sniperTower,
        bombTower
    }

    public GameObject[] Enemies;
}
