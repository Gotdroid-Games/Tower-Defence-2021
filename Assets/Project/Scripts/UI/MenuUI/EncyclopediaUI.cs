using UnityEngine;
using TMPro;

public class EncyclopediaUI : MonoBehaviour
{
    public TextMeshProUGUI EncyclopediaText;
    public GameObject _encyclopediaBackButton;
    public GameObject _encyclopediaImage;
    public string _weakEnemyText;
    public string _gorillaRobotText;
    public string _smartHomeVacuum;

    

    private void Start()
    {
        _encyclopediaImage.SetActive(false);
        _encyclopediaBackButton.SetActive(false);
    }

    public void WeakEnemy()
    {
        _weakEnemyText = "Deneme metni";
        EncyclopediaText.text = _weakEnemyText;
        _encyclopediaImage.SetActive(true);
        _encyclopediaBackButton.SetActive(true);
    }

    public void GorillaRobot()
    {
        _gorillaRobotText = "Deneme metni goril";
        EncyclopediaText.text = _gorillaRobotText;
        _encyclopediaImage.SetActive(true);
        _encyclopediaBackButton.SetActive(true);
    }

    public void SmartHomeVacuum()
    {
        _smartHomeVacuum = "Deneme metni ev süpürgesi";
        EncyclopediaText.text = _smartHomeVacuum;
        _encyclopediaImage.SetActive(true);
        _encyclopediaBackButton.SetActive(true);
    }

    public void EncyclopediaBackButton()
    {
        _encyclopediaImage.SetActive(false);
        _encyclopediaBackButton.SetActive(false);
    }
}
