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
        Instance = this;
    }

    private void Update()
    {
        if (Quaity.Instance._waveText >= 12)
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
        // Yýldýzlarýn aktifleþtirilmesi ve her aktif olan yýldýz karþýlýðýnda +1 puan kazanýlmasý
        int[] heartLevels = { 1, 10, 17 };
        GameObject[] starButtons = { GameUI.Instance._Button.GameUIButtons[10], GameUI.Instance._Button.GameUIButtons[11], GameUI.Instance._Button.GameUIButtons[12] };

        for (int i = 0; i < heartLevels.Length; i++)
        {
            yield return new WaitForSeconds(i == 0 ? 2f : 1f);

            if (Quaity.Instance._heartText >= heartLevels[i] && Quaity.Instance._heartText <= 20)
            {
                starButtons[i].SetActive(true);
                if (_starPoint < i + 1)
                {
                    _starPoint = i + 1;
                    Star();
                }
            }
        }
    }
}
