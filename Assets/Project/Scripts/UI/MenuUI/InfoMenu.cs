using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class InfoMenu : MonoBehaviour
{
    public TextMeshProUGUI InfoTextUI;
    public string InfoText;
    public GameObject[] UpgradeMenuButtons=new GameObject[7];

    void UpgradeUIButtons(GameObject InfoBackGround, GameObject ResetButton, GameObject RateOnFireDoneButton, GameObject SaleDoneButton, GameObject DamageDoneButton, GameObject RangeDoneButton, GameObject CritDamageDoneButton)
    {
        UpgradeMenuButtons[0]=InfoBackGround;
        UpgradeMenuButtons[1]=ResetButton;
        UpgradeMenuButtons[2]=RateOnFireDoneButton;
        UpgradeMenuButtons[3]=SaleDoneButton;
        UpgradeMenuButtons[4]=DamageDoneButton;
        UpgradeMenuButtons[5]=RangeDoneButton;
        UpgradeMenuButtons[6]=CritDamageDoneButton;
    }
    

    private void Awake()
    {
       UpgradeMenuButtons[0].SetActive(false);
       UpgradeMenuButtons[1].SetActive(false);
        
    }

    public void RateOnFire()
    {
        InfoText = "%20 saldýrý hýzý artýþý saðlar";
        InfoTextUI.text = InfoText;
        for (int i = 0; i <= 2; i++)
        {
           UpgradeMenuButtons[i].SetActive(true);

        }

        for (int i = 3; i <= 6; i++)
        {
            UpgradeMenuButtons[i].SetActive(false);
        }
    }

    public void Sale()
    {
        InfoText = "niþancý kulesý -30 daha az altýn ister";
        InfoTextUI.text = InfoText;

        for (int i = 0; i <= 1; i++)
        {
            UpgradeMenuButtons[i].SetActive(true);
        }

        UpgradeMenuButtons[2].SetActive(false);
        UpgradeMenuButtons[3].SetActive(true);

        for (int i = 4; i <= 6; i++)
        {
            UpgradeMenuButtons[i].SetActive(false);
        }
    }

    public void Damage()
    {
        InfoText = "Niþancý kulesinin hasarý %20 artar";
        InfoTextUI.text = InfoText;

        for (int i = 0; i <= 1; i++)
        {
            UpgradeMenuButtons[i].SetActive(true);
        }

        for (int i = 2; i <= 3; i++)
        {
            UpgradeMenuButtons[i].SetActive(false);
        }

        UpgradeMenuButtons[4].SetActive(true);

        for (int i = 5; i <=6 ; i++)
        {
            UpgradeMenuButtons[i].SetActive(false);
        }
    }

    public void Range()
    {
        InfoText = "Niþancý kulesinin menzili %20 artar";
        InfoTextUI.text = InfoText;
        UpgradeMenuButtons[0].SetActive(true);
        UpgradeMenuButtons[1].SetActive(true);
        UpgradeMenuButtons[2].SetActive(false);
        UpgradeMenuButtons[3].SetActive(false);
        UpgradeMenuButtons[4].SetActive(false);
        UpgradeMenuButtons[5].SetActive(true);
        UpgradeMenuButtons[6].SetActive(false);
    }

    public void CritDamage()
    {
        InfoText = "Niþancý kulesinin kritik hasarý %20 artar";
        InfoTextUI.text = InfoText;
        UpgradeMenuButtons[0].SetActive(true);
        UpgradeMenuButtons[1].SetActive(true);
        UpgradeMenuButtons[2].SetActive(false);
        UpgradeMenuButtons[3].SetActive(false);
        UpgradeMenuButtons[4].SetActive(false);
        UpgradeMenuButtons[5].SetActive(false);
        UpgradeMenuButtons[6].SetActive(true);
    }

    public void InfoBack()
    {
        UpgradeMenuButtons[0].SetActive(false);
        UpgradeMenuButtons[1].SetActive(false);
    }
}
