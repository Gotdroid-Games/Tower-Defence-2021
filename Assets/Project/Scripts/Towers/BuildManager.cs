using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public GameObject[] towerPrefabs;
    public AudioManager AudioManager;
    public GameObject turretToBuild;

    public GameObject GetTurretToBuild()
    {
        return turretToBuild;
        
    }

    public void SetTurretToBuild (GameObject turret)
    {
        turretToBuild = turret;
    }
}