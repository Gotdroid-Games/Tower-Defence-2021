using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StarPoint : MonoBehaviour
{
    public static StarPoint Instance;
    public TextMeshProUGUI starPointText;
    public int _starPoint = 0;
    int starvalue = 1;


    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        _starPoint = 0;
        starvalue = 1;
    }

    private void Update()
    {
        if (Quaity.Instance._waveText >= 1)
        {
            StartCoroutine(Waitfor());
        }
        Debug.Log(_starPoint);
    }
    

    public void Star()
    {
        _starPoint += starvalue;
        starPointText.text = _starPoint.ToString();
    }

    public void StarScore()
    {

        if (GameUI.Instance._Button.GameUIButtons[10].activeSelf && Quaity.Instance._heartText <= 20)
        {
            Star();
            if (_starPoint >= 1)
            {
                _starPoint = 1;
            }
        }

        if (GameUI.Instance._Button.GameUIButtons[11].activeSelf && Quaity.Instance._heartText <= 20)
        {
            Star();
            if (_starPoint >= 2)
            {
                _starPoint = 2;
            }
        }

        if (GameUI.Instance._Button.GameUIButtons[12].activeSelf && Quaity.Instance._heartText <= 20)
        {
            Star();
            if (_starPoint >= 3)
            {
                _starPoint = 3;
            }
        }
    }

    IEnumerator Waitfor()
    {
        for (int i = 0; i <= 3; i++)
        {
            if (i == 1)
            {
                yield return new WaitForSeconds(2f);
                GameUI.Instance._Button.GameUIButtons[10].SetActive(true);
                StarScore();
            }

            if (i == 2)
            {
                yield return new WaitForSeconds(1f);
                GameUI.Instance._Button.GameUIButtons[11].SetActive(true);
                StarScore();
            }

            if (i == 3)
            {
                yield return new WaitForSeconds(1f);
                GameUI.Instance._Button.GameUIButtons[12].SetActive(true);
                StarScore(); 
            }
        }
    }
}
