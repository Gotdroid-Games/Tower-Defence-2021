using System.Collections;
using TMPro;
using UnityEngine;

public class StarPoint : MonoBehaviour
{
    
    GameUI GameUI;
    WaveSpawner waveSpawner;
    public TextMeshProUGUI starPointText;
    public static int _starPoint = 0;

    private void Start()
    {
        GameUI = FindObjectOfType<GameUI>();
        waveSpawner = FindObjectOfType<WaveSpawner>();
    }

    private void Update()
    {
        if (GameUI._waveText >= 12 && waveSpawner.totalenemiescheck == 0)
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
        GameObject[] starButtons = { GameUI._Button.GameUIButtons[12], GameUI._Button.GameUIButtons[13], GameUI._Button.GameUIButtons[14] };

        for (int i = 0; i < heartLevels.Length; i++)
        {
            yield return new WaitForSeconds(i == 0 ? 2f : 1f);

            if (GameUI._heartText >= heartLevels[i] && GameUI._heartText <= 20)
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
