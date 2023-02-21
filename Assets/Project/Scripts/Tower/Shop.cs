using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    BuildManager buildManager;

    private void Start()
    {
        buildManager = BuildManager.instance;
    }

    public void PurchaseStandTurret ()
   {
        Debug.Log("Stand Turret Selected");
        buildManager.SetTurretToBuild(buildManager.standardTurretPrefab);
   }
     public void PurchaseAnotherTurret ()
    {
       Debug.Log("Another Turret Selected");
      //buildManager.SetTurretToBuild(buildManager.anotherTurretPrefab);
    } 
}
