using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public GameObject[] towerPrefabs;
    public AudioManager AudioManager;
    public GameObject turretToBuild;

    private void Start()
    {
        
    }
    public GameObject GetTurretToBuild()
    {
        
        return turretToBuild;
        
    }

    public void SetTurretToBuild (GameObject turret)
    {
        Debug.Log("Set �al��t�");
        turretToBuild = turret;
    }
}