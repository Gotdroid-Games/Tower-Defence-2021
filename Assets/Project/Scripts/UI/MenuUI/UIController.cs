using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class UIController : MonoBehaviour
{
    public int StarMenuUI;
    public int totalStarPoints = 0;
    public TextMeshProUGUI StarMenuText;

    private void Start()
    {
        totalStarPoints += StarPoint._starPoint;
        UpdateStarPoints();
    }
    private void Update()
    {

        
        //  StarMenuUI = StarPoint._starPoint;
        StarMenuText.text = totalStarPoints.ToString();

    }
    private void UpdateStarPoints()
    {
        StarMenuText.text = totalStarPoints.ToString();
    }
}
