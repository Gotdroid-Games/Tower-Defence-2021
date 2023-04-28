using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    BuildManager BuildManager; // BuildManager sýnýfýndan bir nesne referansý tanýmlanýyor.

    private void Start()
    {
        BuildManager = FindObjectOfType<BuildManager>(); // Oyun baþladýðýnda BuildManager nesnesi bulunarak tanýmlanýyor.
    }

    public void PurchaseStandTurret()
    {
        Debug.Log("Stand Turret Selected"); // Standart kule seçildiðinde konsola yazdýrýlýyor.
        BuildManager.SetTurretToBuild(BuildManager.standardTurretPrefab); // BuildManager sýnýfýndaki SetTurretToBuild metodu çaðýrýlýyor ve parametre olarak standart kule prefabý gönderiliyor.
    }

    public void PurchaseAnotherTurret()
    {
        Debug.Log("Another Turret Selected"); // Baþka bir kule seçildiðinde konsola yazdýrýlýyor.
        //buildManager.SetTurretToBuild(buildManager.anotherTurretPrefab); Yorum satýrý olduðu için bu satýr etkisiz hale getirilmiþtir.
    }
}
