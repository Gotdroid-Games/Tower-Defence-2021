using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    BuildManager BuildManager; // BuildManager sıfırdan bir nesne referans� tan�mlan�yor.
    public bool bombSelected;

    private void Start()
    {
        BuildManager = FindObjectOfType<BuildManager>(); // Oyun başladığında BuildManager nesnesi bulunarak tan�mlan�yor.
    }

    public void PurchaseStandTurret()
    {
        Debug.Log("Stand Turret Selected"); // Standart kule seçildiğinde konsola yazdırılıyor.
        BuildManager.SetTurretToBuild(BuildManager.towerPrefabs[0]); // BuildManager s�n�f�ndaki SetTurretToBuild metodu �a��r�l�yor ve parametre olarak standart kule prefab� g�nderiliyor.
        bombSelected = false;
        Debug.Log(bombSelected);
    }

    public void PurchaseAnotherTurret()
    {
        Debug.Log("Another Turret Selected"); // Ba�ka bir kule seçildiğinde konsola yazdırılıyor.
        BuildManager.SetTurretToBuild(BuildManager.towerPrefabs[1]);
        bombSelected = true;
        Debug.Log(bombSelected);
    }
    public void PurchaseHackerTower()
    {
        Debug.Log("Another Turret Selected"); // Ba�ka bir kule seçildiğinde konsola yazdırılıyor.
        BuildManager.SetTurretToBuild(BuildManager.towerPrefabs[2]);
        bombSelected = false;
        Debug.Log(bombSelected);
    }

    public void PurchaseSoldierTower()
    {
        Debug.Log("Another Turret Selected"); // Ba�ka bir kule seçildiğinde konsola yazdırılıyor.
        BuildManager.SetTurretToBuild(BuildManager.towerPrefabs[3]);
        bombSelected = false;
        Debug.Log(bombSelected);
    }
}
