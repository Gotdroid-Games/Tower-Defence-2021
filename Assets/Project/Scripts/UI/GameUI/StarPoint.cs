using System.Collections;
using TMPro;
using UnityEngine;

public class StarPoint : MonoBehaviour
{
    public static StarPoint Instance;
    public TextMeshProUGUI starPointText;
    public static int _starPoint = 0;

    private void Awake()
    {
        if(Instance==null)
        {
            Instance = this;
        }
    }

    private void Update()
    {
        if (Quaity.Instance._waveText >= 1)
        {
            StartCoroutine(Waitfor());
        }

        
    }

    public void Star()
    {
        starPointText.text = _starPoint.ToString();
    }

    IEnumerator Waitfor()
    {
        //Yýldýzlarý aktif etme ve her aktif olan yýldýz karþýlýðýnda +1 puan elde etme 
        for (int i = 0; i <= 3; i++)
        {
            if (i == 1)
            {
                yield return new WaitForSeconds(2f);
                GameUI.Instance._Button.GameUIButtons[10].SetActive(true);
                if (GameUI.Instance._Button.GameUIButtons[10].activeSelf && Quaity.Instance._heartText <= 20)
                {
                    if (_starPoint < 1)
                    {
                        _starPoint++;
                        Star();
                    }
                }
            }

            if (i == 2)
            {
                yield return new WaitForSeconds(1f);
                GameUI.Instance._Button.GameUIButtons[11].SetActive(true);
                if (GameUI.Instance._Button.GameUIButtons[11].activeSelf && Quaity.Instance._heartText <= 20)
                {
                    if (_starPoint < 2)
                    {
                        _starPoint++;
                        Star();
                    }
                }
            }

            if (i == 3)
            {
                yield return new WaitForSeconds(1f);
                GameUI.Instance._Button.GameUIButtons[12].SetActive(true);
                if (GameUI.Instance._Button.GameUIButtons[12].activeSelf && Quaity.Instance._heartText <= 20)
                {
                    if (_starPoint < 3)
                    {
                        _starPoint++;
                        Star();
                    }
                }
            }
        }
    }
}
