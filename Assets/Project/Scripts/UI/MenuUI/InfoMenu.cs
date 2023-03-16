using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class InfoMenu : MonoBehaviour
{
    
    public GameObject InfoBackGround;
    public GameObject ResetButton;
    [Header("Done Buttons")]
    public GameObject RateOnFireDoneButton;
    public GameObject SaleDoneButton;
    public GameObject DamageDoneButton;
    public GameObject RangeDoneButton;
    public GameObject CritDamageDoneButton;
    public TextMeshProUGUI InfoTextUI;

    public string InfoText;

    private void Awake()
    {
        InfoBackGround.SetActive(false);
        ResetButton.SetActive(false);
        
    }

    public void RateOnFire()
    {
        InfoText = "%20 sald�r� h�z� art��� sa�lar";
        InfoTextUI.text = InfoText;
        RateOnFireDoneButton.SetActive(true);
        SaleDoneButton.SetActive(false);
        DamageDoneButton.SetActive(false);
        RangeDoneButton.SetActive(false);
        CritDamageDoneButton.SetActive(false);
        InfoBackGround.SetActive(true);
        ResetButton.SetActive(true);
    }

    public void Sale()
    {
        InfoText = "ni�anc� kules� -30 daha az alt�n ister";
        InfoTextUI.text = InfoText;
        RateOnFireDoneButton.SetActive(false);
        SaleDoneButton.SetActive(true);
        DamageDoneButton.SetActive(false);
        RangeDoneButton.SetActive(false);
        CritDamageDoneButton.SetActive(false);
        InfoBackGround.SetActive(true);
        ResetButton.SetActive(true);
    }

    public void Damage()
    {
        InfoText = "ni�anc� kules� -30 daha az alt�n ister";
        InfoTextUI.text = InfoText;
        RateOnFireDoneButton.SetActive(false);
        SaleDoneButton.SetActive(false);
        DamageDoneButton.SetActive(true);
        RangeDoneButton.SetActive(false);
        CritDamageDoneButton.SetActive(false);
        InfoBackGround.SetActive(true);
        ResetButton.SetActive(true);
    }

    public void Range()
    {
        InfoText = "ni�anc� kules� -30 daha az alt�n ister";
        InfoTextUI.text = InfoText;
        RateOnFireDoneButton.SetActive(false);
        SaleDoneButton.SetActive(false);
        DamageDoneButton.SetActive(false);
        RangeDoneButton.SetActive(true);
        CritDamageDoneButton.SetActive(false);
        InfoBackGround.SetActive(true);
        ResetButton.SetActive(true);
    }

    public void CritDamage()
    {
        InfoText = "ni�anc� kules� -30 daha az alt�n ister";
        InfoTextUI.text = InfoText;
        RateOnFireDoneButton.SetActive(false);
        SaleDoneButton.SetActive(false);
        DamageDoneButton.SetActive(false);
        RangeDoneButton.SetActive(false);
        CritDamageDoneButton.SetActive(true);
        InfoBackGround.SetActive(true);
        ResetButton.SetActive(true);
    }

    public void InfoBack()
    {
        InfoBackGround.SetActive(false);
        ResetButton.SetActive(false);
    }
}
