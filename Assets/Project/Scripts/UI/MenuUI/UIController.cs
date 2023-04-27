using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class UIController : MonoBehaviour
{
    public static UIController instance;
    public int StarMenuUI;
    public TextMeshProUGUI StarMenuText;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    private void Update()
    {
        StarMenuUI = StarPoint._starPoint;
        StarMenuText.text=StarMenuUI.ToString();
    }

    public void BackMenu()
    {
        SceneManager.LoadScene(0);
    }
}
