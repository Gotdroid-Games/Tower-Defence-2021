using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static sniperTowerMoneySell;


[System.Serializable]
public class sniperTowerMoneySell
{

    //Niþancý Kulesi Satma
    [HideInInspector]
    public string name;
    public int _sniperTowerMoneySell;
}

[System.Serializable]
public class SniperTowerUpgradeMoney
{
    //Niþancý Kulesi Geliþtirme
    [HideInInspector]
    public string name;
    public int _sniperTowerUpgradeMoney;
}

[System.Serializable]
public class BombTowerMoneySell
{
    //Bomba Kulesi Satma
    [HideInInspector]
    public string name;
    public int _bombTowerMoneySell;
}

[System.Serializable]
public class BombTowerUpgradeMoney
{
    //Bomba Kulesi Geliþtirme
    [HideInInspector]
    public string name;
    public int _bombTowerUpgradeMoney;
}

[System.Serializable]
public class EnemyDamage
{
    //Düþman Son Nokta Geçiþ Hasarý
    [HideInInspector]
    public string name;
    public int _EnemyDamage;
}

[System.Serializable]
public class EnemyHealth
{
    //Düþman Caný
    [HideInInspector]
    public string name;
    public int _EnemyHealth;
}

[System.Serializable]
public class EnemySpeed
{
    //Düþman Hareket Hýzý
    [HideInInspector]
    public string name;
    public float _EnemySpeed;
}

[System.Serializable]
public class EnemyKillCoinValue
{
    //Düþman Öldürme Para Miktarý
    //[HideInInspector]
    public string name;
    public int EnemyKillCoin;
}

[System.Serializable]
public class EnemySpawnTime
{
    //Düþman Öldürme Para Miktarý
    //[HideInInspector]
    public string name;
    public float enemySpawnTime;
}


public class GameManager : MonoBehaviour
{
    WaveSpawner WaveSpawner;
    Quaity Quaity;
    TowerTarget TowerTarget;

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
    //Product WaveSpawner sýnýfý içerisinde bulunan WaveCountDown deðeriyle Quality sýnýfý içerisinde bulunan Product deðiþkeninin çarpýp zamana göre extra para kazanmaya yarýyor
    public int _Product;
    [Header(" ")]

    public int _sniperTowerBuyMoney;
    public SniperTowerUpgradeMoney[] _sniperTowerUpgradeMoney;
    public sniperTowerMoneySell[] _sniperTowerMoneySell;

    [Header(" ")]

    public int _bombTowerBuyMoney;
    public BombTowerUpgradeMoney[] _bombTowerUpgradeMoney;
    public BombTowerMoneySell[] _bombTowerMoneySell;


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
    [Header("Time Control Variables")]

    public EnemySpawnTime[] EnemySpawnTime;
    public float[] _timeBetweenWaves;
    [Header(" ")]
    public float WaveStartTimeAdjustment;



    [Header("Enemy Attributes")]
    public EnemyDamage[] EnemyDamage;
    public EnemyHealth[] EnemyHealth;
    public EnemySpeed[] EnemySpeed;
    public EnemyKillCoinValue[] _EnemyKillCoin;
    private void Start()
    {
        WaveSpawner = FindObjectOfType<WaveSpawner>();
        Quaity = FindObjectOfType<Quaity>();


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
        WaveSpawner.timeBetweenWaves = _timeBetweenWaves;


    }



    private void Update()
    {
        TowerTarget = FindObjectOfType<TowerTarget>();
        if (TowerTarget != null)
        {
            TowerTarget.fireRate = _fireRate;
            TowerTarget.critValue = _critValue;
        }
    }


}







