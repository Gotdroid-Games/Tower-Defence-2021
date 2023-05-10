using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    BuildManager BuildManager; // BuildManager s�n�f�ndan bir nesne referans� tan�mlan�yor.
    public bool bombSelected;

    private void Start()
    {
        BuildManager = FindObjectOfType<BuildManager>(); // Oyun ba�lad���nda BuildManager nesnesi bulunarak tan�mlan�yor.
    }

    public void PurchaseStandTurret()
    {
        Debug.Log("Stand Turret Selected"); // Standart kule se�ildi�inde konsola yazd�r�l�yor.
        BuildManager.SetTurretToBuild(BuildManager.standardTurretPrefab); // BuildManager s�n�f�ndaki SetTurretToBuild metodu �a��r�l�yor ve parametre olarak standart kule prefab� g�nderiliyor.
        bombSelected = false;
        Debug.Log(bombSelected);
    }

    public void PurchaseAnotherTurret()
    {
        Debug.Log("Another Turret Selected"); // Ba�ka bir kule se�ildi�inde konsola yazd�r�l�yor.
        BuildManager.SetTurretToBuild(BuildManager.anotherTurretPrefab);
        bombSelected = true;
        Debug.Log(bombSelected);
    }
}
