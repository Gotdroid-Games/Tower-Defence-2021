using System.Collections;
using TMPro;
using UnityEngine;

public class StarPoint : MonoBehaviour
{
    Quaity Quaity;
    GameUI GameUI;
    public TextMeshProUGUI starPointText;
    public static int _starPoint = 0;

    private void Start()
    {
        Quaity = FindObjectOfType<Quaity>();
        GameUI = FindObjectOfType<GameUI>();
    }

    private void Update()
    {
        if (Quaity._waveText >= 12)
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
        // Y�ld�zlar�n aktifle�tirilmesi ve her aktif olan y�ld�z kar��l���nda +1 puan kazan�lmas�
        int[] heartLevels = { 1, 10, 17 };
        GameObject[] starButtons = { GameUI._Button.GameUIButtons[10], GameUI._Button.GameUIButtons[11], GameUI._Button.GameUIButtons[12] };

        for (int i = 0; i < heartLevels.Length; i++)
        {
            yield return new WaitForSeconds(i == 0 ? 2f : 1f);

            if (Quaity._heartText >= heartLevels[i] && Quaity._heartText <= 20)
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
