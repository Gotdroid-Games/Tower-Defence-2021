using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.IO;
[System.Serializable]
public class TotalStarPoints
{
    public int totalstarpoints;
}
public class UIController : MonoBehaviour
{
    public int StarMenuUI;
    public int totalStarPoints = 0;
    public TextMeshProUGUI StarMenuText;

    private void Start()
    {
        LoadTotalPoints();
        totalStarPoints += StarPoint._starPoint;
        UpdateStarPoints();
    }
    private void Update()
    {

        
        //  StarMenuUI = StarPoint._starPoint;
        StarMenuText.text = totalStarPoints.ToString();
        SaveTotalPoints();

    }
    private void UpdateStarPoints()
    {
        StarMenuText.text = totalStarPoints.ToString();
    }
    private void SaveTotalPoints()
    {
        TotalStarPoints data = new TotalStarPoints();
        data.totalstarpoints = totalStarPoints;
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.dataPath + "/totalStarPoints.json", json);
    }

    private void LoadTotalPoints()
    {
        if (File.Exists(Application.dataPath + "/totalStarPoints.json"))
        {
            string json = File.ReadAllText(Application.dataPath + "/totalStarPoints.json");
            TotalStarPoints data = JsonUtility.FromJson<TotalStarPoints>(json);
            totalStarPoints = data.totalstarpoints;
        }
    }
}
