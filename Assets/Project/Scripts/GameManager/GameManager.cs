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

    [Space(5f)]
    [Header("TowerTarget Attributes")]

    public float _fireRate;
    public int _critValue;

    [Space(5f)]
    [Header("Quality Attributes")]

    public int coinText;
    public int heartText;
    public int waveText;

    [Space(5f)]
    [Header("Money Controls")]
    //Product WaveSpawner s�n�f� i�erisinde bulunan WaveCountDown de�eriyle Quality s�n�f� i�erisinde bulunan Product de�i�keninin �arp�p zamana g�re extra para kazanmaya yar�yor
    public int _Product;
    [Header(" ")]

    public int _sniperTowerBuyMoney;
    public int[] _sniperTowerMoneySell;
    public int[] _sniperTowerUpgradeMoney;

    [Header(" ")]

    public int _bombTowerBuyMoney;
    public int[] _bombTowerMoneySell;
    public int[] _bombTowerUpgradeMoney;


    [Space(5f)]
    [Header("Enemy List")]
    public int[] _basicRobot;
    public int[] _gorillaRobot;
    public int[] _smartHomeRobot;
    public int[] _droneRobot;

    [Space(5f)]
    [Header("Enemy Spawn Info")]
    string[] _basicRobotWaveInfo;
    string[] _gorillaRobotWaveInfo;
    string[] _smarthomeRobotWaveInfo;
    string[] _droneRobotWaveInfo;

    [Space(5f)]
    [Header("Enemy Time Control Variables")]

    public float _spawnTime;
    public float[] _timeBetweenWaves;


    private void Start()
    {
        WaveSpawner = FindObjectOfType<WaveSpawner>();
        Quaity = FindObjectOfType<Quaity>();
        
        Enemy = FindObjectOfType<Enemy>();

        //Kule �z Nitelikleri




        //Oyun ��i Bilgi Alan� �z Nitelikleri
        Quaity._coinText = coinText;
        Quaity._heartText = heartText;
        Quaity._waveText = waveText;

        //Para De�erleri
        Quaity.Product = _Product;

        //D��man Dizileri
        WaveSpawner.basicRobot = _basicRobot;
        WaveSpawner.gorillaRobot = _gorillaRobot;
        WaveSpawner.smarthomeRobot = _smartHomeRobot;
        WaveSpawner.DroneRobot = _droneRobot;

        //D��man Bilgi Dizileri
        WaveSpawner.basicRobotWaveInfo = _basicRobotWaveInfo;
        WaveSpawner.gorillaRobotWaveInfo = _gorillaRobotWaveInfo;
        WaveSpawner.smarthomeRobotWaveInfo = _smarthomeRobotWaveInfo;
        WaveSpawner.droneRobotWaveInfo = _droneRobotWaveInfo;

        //Zaman De�erleri
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
