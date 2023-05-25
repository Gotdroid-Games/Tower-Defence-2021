using TMPro;
using UnityEngine;

public class InfoMenu : MonoBehaviour
{
    UpgradeMenu UpgradeMenu;
    public TextMeshProUGUI InfoTextUI;
    public string InfoText;
    public GameObject[] UpgradeMenuButtons = new GameObject[7];
    public GameObject InfoBackGround, ResetButton, RateOnFireDoneButton, SaleDoneButton, DamageDoneButton, RangeDoneButton, CritDamageDoneButton;

    void Start()
    {
        UpgradeMenu = FindObjectOfType<UpgradeMenu>();
        UpgradeUIButtons();
        UpgradeMenuButtons[0].SetActive(false);
        UpgradeMenuButtons[1].SetActive(false);
    }

    void UpgradeUIButtons()
    {
        UpgradeMenuButtons[0] = InfoBackGround;
        UpgradeMenuButtons[1] = ResetButton;
        UpgradeMenuButtons[2] = RateOnFireDoneButton;
        UpgradeMenuButtons[3] = SaleDoneButton;
        UpgradeMenuButtons[4] = DamageDoneButton;
        UpgradeMenuButtons[5] = RangeDoneButton;
        UpgradeMenuButtons[6] = CritDamageDoneButton;
    }

    void UpgradeUI(bool[] activeButtons, string infoText)
    {
        InfoTextUI.text = infoText;
        for (int i = 0; i < activeButtons.Length; i++)
        {
            UpgradeMenuButtons[i].SetActive(activeButtons[i]);
        }
    }

    public void RateOnFire()
    {
        bool[] activeButtons = { true, true, true, false, false, false, false };
        InfoText = "%20 saldýrý hýzý artýþý saðlar";
        UpgradeUI(activeButtons, InfoText);
    }

    public void Sale()
    {
        bool[] activeButtons = { true, true, false, true, false, false, false };
        InfoText = "niþancý kulesý -30 daha az altýn ister";
        UpgradeUI(activeButtons, InfoText);
    }

    public void Damage()
    {
        bool[] activeButtons = { true, true, false, false, true, false, false };
        InfoText = "Niþancý kulesinin hasarý %20 artar";
        UpgradeUI(activeButtons, InfoText);
    }

    public void Range()
    {
        bool[] activeButtons = { true, true, false, false, false, true, false };
        InfoText = "Niþancý kulesinin menzili %20 artar";
        UpgradeUI(activeButtons, InfoText);
    }

    public void CritDamage()
    {
        bool[] activeButtons = { true, true, false, false, false, false, true };
        InfoText = "Niþancý kulesinin kritik hasarý %20 artar";
        UpgradeUI(activeButtons, InfoText);
    }

    public void InfoBack()
    {
        UpgradeMenuButtons[0].SetActive(false);
        UpgradeMenuButtons[1].SetActive(false);
    }
}
