using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Shop : MonoBehaviour
{
    public BuildManager BuildManager; // BuildManager sıfırdan bir nesne referans� tan�mlan�yor.
    public AudioManager AudioManager;
    public bool bombSelected;

    private void Start()
    {
        //BuildManager = FindObjectOfType<BuildManager>(); // Oyun başladığında BuildManager nesnesi bulunarak tan�mlan�yor.
    }

    public void PurchaseStandTurret()
    {
        Debug.Log("Lazer kulesi seçildi"); // Lazer kulesi seçildiğinde konsola yazdırılıyor.
        BuildManager.SetTurretToBuild(BuildManager.towerPrefabs[0]); // BuildManager s�n�f�ndaki SetTurretToBuild metodu �a��r�l�yor ve parametre olarak standart kule prefab� g�nderiliyor.
    }

    public void PurchaseAnotherTurret()
    {
        Debug.Log("Bomba kulesi seçildi"); // Bomba kulesi seçildiğinde konsola yazdırılıyor.
        BuildManager.SetTurretToBuild(BuildManager.towerPrefabs[1]);
    }
    public void PurchaseHackerTower()
    {
        Debug.Log("Hacker kulesi seçildi"); // Hacker kulesi seçildiğinde konsola yazdırılıyor.
        BuildManager.SetTurretToBuild(BuildManager.towerPrefabs[2]); 
    }

    public void PurchaseSoldierTower()
    {
        Debug.Log("Birlik kulesi seçildi"); // Birlik kulesi seçildiğinde konsola yazdırılıyor.
        BuildManager.SetTurretToBuild(BuildManager.towerPrefabs[3]);
    }
}
