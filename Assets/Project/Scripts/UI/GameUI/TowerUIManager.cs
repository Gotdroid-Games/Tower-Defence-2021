using System.Collections.Generic;
using UnityEngine;

public class TowerUIManager : MonoBehaviour
{
    public  Dictionary<GameObject, GameObject> towerUITable = new Dictionary<GameObject, GameObject>();

    public void SetActiveTowerUI(GameObject tower, GameObject towerUI)
    {
        // Eğer başka bir kule UI'sı aktifse kapat
        foreach (var kvp in towerUITable)
        {
            kvp.Value.SetActive(false);
        }

        // Kule UI'sını ekleyin veya güncelleyin
        if (towerUITable.ContainsKey(tower))
        {
            towerUITable[tower] = towerUI;
        }
        else
        {
            towerUITable.Add(tower, towerUI);
        }

        // Kule UI'sını açın
        towerUITable[tower].SetActive(true);
    }
    private void Update()
    {
        Debug.Log(towerUITable);
    }
}
