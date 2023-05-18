using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[System.Serializable]
public class TowerVaribles
{

    //Niþancý Kulesi Satma
    [HideInInspector]
    public string name;
    //Kulenin
    public int TowerDamage;
    public int TowerDamageIncreaseValue;
    public int TowerRange;
    public int TowerRangeIncreaseValue;
    public float FireRate;
    [Header("")]
    public int TowerMoneyBuy;
    [Header("")]
    public int TowerMoneyUpgradeLevel1;
    public int TowerMoneyUpgradeLevel2;
    [Header("")]
    public int TowerMoneySellLevel1;
    public int TowerMoneySellLevel2;
    public int TowerMoneySellLevel3;
    [Header("")]
    public AudioSource AudioSource;
    public AudioClip TowerAttackSFX;
    public AudioClip EnemyTouchSFX;
}

[System.Serializable]
public class EnemyVariables
{
    //Düþman Caný
    public string name;
    public int _EnemyHealth;
    public int _EnemySpeed;
    public int _EnemyDamage;
    public int EnemyKillCoin;
    public float enemySpawnTime;
}



public class GameManager : MonoBehaviour
{
    WaveSpawner WaveSpawner;
    Quaity Quaity;
    TowerTarget TowerTarget;

    [Space(5f)]
    [Header("TowerTarget Attributes")]

    
    public int _critValue;
    public float bombTowerExplosionRadius;
    public List<TowerVaribles> TowerVaribles;

    [Header("Enemy Attributes")]

    public List<EnemyVariables> EnemyVariables;

    [Space(5f)]
    [Header("Quality Attributes")]

    public int coinText;
    public int heartText;
    public int waveText;

    [Space(5f)]
    [Header("Money Controls")]
    //Product WaveSpawner sýnýfý içerisinde bulunan WaveCountDown deðeriyle Quality sýnýfý içerisinde bulunan Product deðiþkeninin çarpýp zamana göre extra para kazanmaya yarýyor
    public int _Product;


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

    public float[] _timeBetweenWaves;
    [Header(" ")]
    public float WaveStartTimeAdjustment;


    private void Start()
    {
        TowerVaribles[0].AudioSource = GetComponent<AudioSource>();
        //AudioVaribles.AudioClip = GetComponent<AudioClip>();
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
            TowerTarget.fireRate = TowerVaribles[0].FireRate;
            TowerTarget.critValue = _critValue;
        }
    }


}







