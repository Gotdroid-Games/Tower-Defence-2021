using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public GameObject standardTurretPrefab;


   
    //public GameObject anotherTurretPrefab;

     GameObject turretToBuild;

    public GameObject GetTurretToBuild()
    {
        return turretToBuild;
    }

    public void SetTurretToBuild (GameObject turret)
    {
        turretToBuild = turret;
    }
}