using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class UIController : MonoBehaviour
{
    public int StarMenuUI;
    public TextMeshProUGUI StarMenuText;

    private void Update()
    {
        StarMenuUI = StarPoint._starPoint;
        StarMenuText.text=StarMenuUI.ToString();
    }
}
