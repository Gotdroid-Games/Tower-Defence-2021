using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    WaveSpawner WaveSpawner;
    Quaity Quaity;
    TowerTarget TowerTarget;
    Enemy Enemy;

    [Header("TowerTarget Attributes")]

    public float _fireRate;
    public int _critValue;

    [Header("Quality Attributes")]

    public int coinText;
    public int heartText;
    public int waveText;

    [Header("Money Controls")]
    //Product WaveSpawner sýnýfý içerisinde bulunan WaveCountDown deðeriyle Quality sýnýfý içerisinde bulunan Product deðiþkeninin çarpýp zamana göre extra para kazanmaya yarýyor
    public int _Product;



    [Header("Enemy List")]
    public int[] _basicRobot;
    public int[] _gorillaRobot;
    public int[] _smartHomeRobot;
    public int[] _droneRobot;


    [Header("Enemy Spawn Info")]
    string[] _basicRobotWaveInfo;
    string[] _gorillaRobotWaveInfo;
    string[] _smarthomeRobotWaveInfo;
    string[] _droneRobotWaveInfo;

    [Header("Enemy Time Control Variables")]

    public float _spawnTime;
    public float[] _timeBetweenWaves;

    private void Awake()
    {

    }

    private void Start()
    {
        WaveSpawner = FindObjectOfType<WaveSpawner>();
        Quaity = FindObjectOfType<Quaity>();
        
        Enemy = FindObjectOfType<Enemy>();

        //Kule Öz Nitelikleri




        //Oyun Ýçi Bilgi Alaný Öz Nitelikleri
        Quaity._coinText = coinText;
        Quaity._heartText = heartText;
        Quaity._waveText = waveText;

        //Para Deðerleri
        Quaity.Product = _Product;

        //Düþman Dizileri
        WaveSpawner.basicRobot = _basicRobot;
        WaveSpawner.gorillaRobot = _gorillaRobot;
        WaveSpawner.smarthomeRobot = _smartHomeRobot;
        WaveSpawner.DroneRobot = _droneRobot;

        //Düþman Bilgi Dizileri
        WaveSpawner.basicRobotWaveInfo = _basicRobotWaveInfo;
        WaveSpawner.gorillaRobotWaveInfo = _gorillaRobotWaveInfo;
        WaveSpawner.smarthomeRobotWaveInfo = _smarthomeRobotWaveInfo;
        WaveSpawner.droneRobotWaveInfo = _droneRobotWaveInfo;

        //Zaman Deðerleri
        WaveSpawner.spawnTime = _spawnTime;
        WaveSpawner.timeBetweenWaves = _timeBetweenWaves;


    }

    private void Update()
    {
        TowerTarget = FindObjectOfType<TowerTarget>();
        if ( TowerTarget != null )
        {
            TowerTarget.fireRate = _fireRate;
            TowerTarget.critValue = _critValue;
        }
        
    }
}
