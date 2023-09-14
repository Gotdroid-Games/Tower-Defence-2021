using System.Collections;
using TMPro;
using UnityEngine;
using System.IO;

[System.Serializable]
public class StarPointData
{
    public int StarPoints;
}

public class StarPoint : MonoBehaviour
{
    public StarPointData starpointdata;
    GameUI GameUI;
    WaveSpawner waveSpawner;
    public TextMeshProUGUI starPointText;
    public static int _starPoint = 0;

   
    private void Start()
    {
        starpointdata = new StarPointData();
        GameUI = FindObjectOfType<GameUI>();
        waveSpawner = FindObjectOfType<WaveSpawner>();
        LoadStarPoints();
    }

    private void Update()
    {
        if (GameUI._waveText >= 2 && waveSpawner.totalenemiescheck == 0)
        {
            StartCoroutine(Waitfor());
        }
        SaveStarPoints();
        Debug.Log(_starPoint);
    }

    public void Star()
    {
        starPointText.text = starpointdata.StarPoints.ToString();

    }
    private void SaveStarPoints()
    {
        starpointdata.StarPoints = _starPoint;
        string jsondata = JsonUtility.ToJson(starpointdata);
        File.WriteAllText(Application.dataPath + "/StarPointdata.json", jsondata);
        try
        {
            File.WriteAllText(Application.dataPath + "/StarPointdata.json", jsondata);
            Debug.Log("Başarıyla kaydedildi: " + Application.dataPath + "/StarPointdata.json");
        }
        catch (System.Exception e)
        {
            Debug.LogError("Kaydetme Hatası: " + e.Message);
        }
    }

    private void LoadStarPoints()
    {
        if (File.Exists(Application.dataPath + "/StarPointdata.json"))
        {
            string jsonData = File.ReadAllText(Application.dataPath+ "/StarPointdata.json");
            starpointdata = JsonUtility.FromJson<StarPointData>(jsonData);
            _starPoint = starpointdata.StarPoints;
            Star(); // Yüklenen puanı ekranda göster
        }
    }

    IEnumerator Waitfor()
    {
        // Y�ld�zlar�n aktifle�tirilmesi ve her aktif olan y�ld�z kar��l���nda +1 puan kazan�lmas�
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
                    starpointdata.StarPoints = _starPoint;
                    Star();
                    Debug.Log("3. Y�ld�z aktif oldu");
                }
            }
        }
    }
}
