using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;
using System;
using System.Collections.Generic;
using System.IO;
using static GameUI;

public class GameUI : MonoBehaviour
{

    [Header("references")]
    //Referanslar
    AudioManager AudioManager;
    WaveSpawner WaveSpawner;
    GameManager GameManager;
    public List<CoinValues> coinValues;
    public ButtonAssignments _Button;

    //Kayd�ra�lar
    public Slider _musicSlider, _sfxSlider;

    //Resimler
    public Image wavestartinfopanel, _musicButtonMuteImage, _sfxButtonMuteImage, WaveCounterInducator;

    //Metin De�i�kenleri
    public TextMeshProUGUI _musicText, _sfxText, heartText, WaveText, CoinText;
    public string musicVolumeValue;
    public string sfxVolumeValue;

    //Say�sal De�erler
    public int _coinText;
    public int _heartText;
    public int _waveText;
    public float Product;
    public string dataFilePath;
    //Kontrol De�i�kenleri
    public bool defeatMenuControl;

    VolumeData loadeddata;
    string jsonData;


    // private const string musicSettingsFilePath = "music_settings.json"; -1-
    /*
     [Serializable]
     public class MusicSettingsData
     {
         public float musicSliderValue;
     }

     private void SaveMusicSettings()
     {
         MusicSettingsData musicsettingsdata = new MusicSettingsData
         {
             musicSliderValue = _musicSlider.value
         };
         string jsonData = JsonUtility.ToJson(musicsettingsdata);
         File.WriteAllText(Application.persistentDataPath + "/" + musicSettingsFilePath, jsonData);

     }

     public void SaveMusicSliderValue()
     {
         SaveMusicSettings();
     }

     private void LoadMusicSettings()
     {
         if (File.Exists(Application.persistentDataPath + "/" + musicSettingsFilePath))
         {
             string jsonData = File.ReadAllText(Application.persistentDataPath + "/" + musicSettingsFilePath);
             MusicSettingsData musicsettingsdata = JsonUtility.FromJson<MusicSettingsData>(jsonData);
             _musicSlider.value = musicsettingsdata.musicSliderValue;
         }
     }
    */

    #region Button
    [System.Serializable]
    //Oyun i�erisinde bulunan t�m butonlar diziye atand�
    public class ButtonAssignments
    {
        public GameObject[] GameUIButtons = new GameObject[17];

        void GameUIButton(GameObject _pauseButton, GameObject _resumeButton, GameObject _restartButton, GameObject _quitButton, GameObject _gameBG, GameObject _optionsBG, GameObject _exitButton, GameObject _musicSlider, GameObject _sfxSlider, GameObject _musicMuteButton, GameObject _sfxMuteButton, GameObject _continueButton, GameObject _firstStar, GameObject _secondStar, GameObject _thirdStar, GameObject _continueButtonEndGame, GameObject _waveStartButtonInfoPanel)

        {
            GameUIButtons[0] = _pauseButton;
            GameUIButtons[1] = _resumeButton;
            GameUIButtons[2] = _restartButton;
            GameUIButtons[3] = _quitButton;
            GameUIButtons[4] = _gameBG;
            GameUIButtons[5] = _optionsBG;
            GameUIButtons[6] = _exitButton;
            GameUIButtons[7] = _musicSlider;
            GameUIButtons[8] = _sfxSlider;
            GameUIButtons[9] = _musicMuteButton;
            GameUIButtons[10] = _sfxMuteButton;
            GameUIButtons[11] = _continueButton;
            GameUIButtons[12] = _firstStar;
            GameUIButtons[13] = _secondStar;
            GameUIButtons[14] = _thirdStar;
            GameUIButtons[15] = _continueButtonEndGame;
            GameUIButtons[16] = _waveStartButtonInfoPanel;
        }
    }
    #endregion

    private void Awake()
    {
        
        dataFilePath = Path.Combine(Application.dataPath, "volumeData.json");
        jsonData = File.ReadAllText(dataFilePath);
        loadeddata = JsonUtility.FromJson<VolumeData>(jsonData);

        //Pause (Durdurma) butonu d���nda ki t�m butonlar pasif halde

        for (int i = 0; i < _Button.GameUIButtons.Length; i++)
        {
            _Button.GameUIButtons[i].SetActive(false);

        }
        _Button.GameUIButtons[0].SetActive(true);
    }
    [System.Serializable]
    public class VolumeData //Bu kodda Json için tanımlamaları yaptık
    {
        public float musicVolumeValue;
        public float sfxVolumeValue;
    }

    private void Start()
    {
        //dataFilePath = Path.Combine(Application.dataPath, "volumeData.json");
        //jsonData = File.ReadAllText(dataFilePath);
        //loadeddata = JsonUtility.FromJson<VolumeData>(jsonData);
        AudioManager = FindObjectOfType<AudioManager>();

        _musicButtonMuteImage.gameObject.SetActive(false);
        _sfxButtonMuteImage.gameObject.SetActive(false);
        _Button.GameUIButtons[9].SetActive(false);
        _Button.GameUIButtons[10].SetActive(false);

        WaveSpawner = FindObjectOfType<WaveSpawner>();
        GameManager = FindObjectOfType<GameManager>();
        defeatMenuControl = false;
        //LoadMusicSettings(); -3-
        if (AudioManager.musicSource.mute == false)
        {

            _musicSlider.value = loadeddata.musicVolumeValue;
        }
        else
        {
            AudioManager.recordedMusicValue2 = _musicSlider.value;
        }

        if (AudioManager.sfxSource.mute == false)
        {

            _sfxSlider.value = loadeddata.sfxVolumeValue;
            Debug.Log(loadeddata.sfxVolumeValue + "sfxvolume");
        }
        else
        {
            AudioManager.recordedSFXValue2 = _sfxSlider.value;
            Debug.Log(AudioManager.recordedSFXValue2);
        }
    }

    private void Update()
    {
        WaveText.text = _waveText.ToString() + "/" + GameManager._basicRobot.Length.ToString();
        CoinText.text = _coinText.ToString();

        if (_heartText < 0)
        {
            _heartText = 0;
            heartText.text = _heartText.ToString();
        }
        heartText.text = _heartText.ToString();

        if (_coinText <= 0)
        {
            _coinText = 0;
        }
        
        WaveCounter();
        Winning();

        if (_heartText <= 0)
        {
            _heartText = 0;
            defeatMenuControl = true;
            DefeatMenu();
        }

        if (defeatMenuControl == true)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }

        if (AudioManager.sfxSource.mute == false)
        {
            _Button.GameUIButtons[10].SetActive(true);
        }

        if (AudioManager.sfxSource.volume == 0 && !_Button.GameUIButtons[5].activeSelf)
        {
            _sfxButtonMuteImage.gameObject.SetActive(false);
        }
        else if (AudioManager.sfxSource.volume == 0 && _Button.GameUIButtons[5].activeSelf)
        {
            _sfxButtonMuteImage.gameObject.SetActive(true);
        }

        if (AudioManager.musicSource.volume == 0 && !_Button.GameUIButtons[5].activeSelf)
        {
            _musicButtonMuteImage.gameObject.SetActive(false);
        }
        else if (AudioManager.musicSource.volume == 0 && _Button.GameUIButtons[5].activeSelf)
        {
            _musicButtonMuteImage.gameObject.SetActive(true);
        }

        WaveCounterInducator.fillAmount = (WaveSpawner.waveCountdown / 15);

    }
    public void PauseButton()
    {
        //Oyunu durdurma ve Pause (Durdurma) butonu d���nda ki t�m butonlar aktif halde
        Time.timeScale = 0;
        for (int i = 0; i < _Button.GameUIButtons.Length; i++)
        {
            _Button.GameUIButtons[i].SetActive(true);
        }
        _Button.GameUIButtons[0].SetActive(false);
        _Button.GameUIButtons[11].SetActive(false);
        _Button.GameUIButtons[12].SetActive(false);
        _Button.GameUIButtons[13].SetActive(false);
        _Button.GameUIButtons[14].SetActive(false);
        _Button.GameUIButtons[15].SetActive(false);
        _Button.GameUIButtons[16].SetActive(false);

    }

    // [0] (_pauseButton)
    // [1] (_resumeButton)
    // [2] (_restartButton)
    // [3] (_quitButton)
    // [4] (_gameBG)
    // [5] (_optionsBG)
    // [6] (_exitButton)
    // [7] (_musicButton)
    // [8] (_sfxButton) 
    // [10] (_firstStart)
    // [11] (_secondStart)
    // [12] (_thirdStar)


    #region Button function
    public void ResumeButton()
    {
        //Oyunu devam ettirme ve Pause (Durdurma) butonu d���nda ki t�m butonlar pasif halde
        Time.timeScale = 1;
        for (int i = 0; i < _Button.GameUIButtons.Length; i++)
        {
            _Button.GameUIButtons[i].SetActive(false);
        }
        _Button.GameUIButtons[0].SetActive(true);
    }

    public void RestartButton()
    {
        //Oyunu yeniden ba�latma
        Time.timeScale = 1;
        Scene scene;
        scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

    public void QuitButton()
    {
        //Ana men�ye d�nd�rme
        SceneManager.LoadScene("Menu");
    }

    public void ExitButton()
    {
        //�arp� ikonu oyuna devam etme
        ResumeButton();
    }

    #endregion

    #region Volume function
    public void ToggleMusic()
    {
        //M�zik sesini susturma ve aktif etme
        AudioManager.GameToggleMusic();
        _musicSlider.value = 0;
    }
    public void ToggleMusicMute()
    {
        AudioManager.GameToggleMusic();
        _Button.GameUIButtons[9].SetActive(true);
        _musicButtonMuteImage.gameObject.SetActive(false);
        _musicSlider.value = AudioManager.recordedMusicValue;
        Debug.Log("mute kald�r�ld�");
    }

    public void ToggleSFX()
    {
        //Ses efektlerini susturma ve aktif etme
        AudioManager.GameToggleSFX();
        _sfxSlider.value = 0;
    }

    public void ToggleSFXMute()
    {
        AudioManager.GameToggleSFX();
        _Button.GameUIButtons[10].SetActive(true);
        _sfxSlider.value = AudioManager.recordedSFXValue;
    }

    public void SaveVolumeData()
    {
        VolumeData volumedata = new VolumeData
        {
            musicVolumeValue = _musicSlider.value,
            sfxVolumeValue = _sfxSlider.value

        };

        string jsonData = JsonUtility.ToJson(volumedata);
        File.WriteAllText(dataFilePath, jsonData);
    }

    public void MusicVolume()
    {

        //Kayd�r�c� ile ses d�zeyini ayarlama (Artt�rma ve k�sma)
        AudioManager.MusicVolume(_musicSlider.value);
        musicVolumeValue = (_musicSlider.value * 100).ToString("0");
        _musicText.text = musicVolumeValue;

        bool isMusicMuted = _musicSlider.value == 0;
        //_Button.GameUIButtons[9].SetActive(!isMusicMuted); Bunu açma
        _musicButtonMuteImage.gameObject.SetActive(isMusicMuted);

        if (AudioManager.musicSource.mute == false)
        {
            AudioManager.recordedMusicValue = _musicSlider.value;
        }
        else
        {
            AudioManager.recordedMusicValue2 = _musicSlider.value;
        }

        //if (!_musicButtonMuteImage.gameObject.activeSelf)
        //{
        //    _Button.GameUIButtons[9].SetActive(true);
        //}
        //else
        //{
        //    _Button.GameUIButtons[9].SetActive(false);
        //}
        Debug.Log(AudioManager.musicSource.mute ? AudioManager.recordedMusicValue2 : AudioManager.recordedMusicValue);
        //SaveMusicSliderValue();-4-

        SaveVolumeData();
    }

    public void SFXVolume()
    {
        //Kayd�r�c� ile ses d�zeyini ayarlama (Artt�rma ve k�sma)
        AudioManager.SFXVolume(_sfxSlider.value);

        sfxVolumeValue = (_sfxSlider.value * 100).ToString("0");
        _sfxText.text = sfxVolumeValue;

        bool isSFXMuted = Mathf.Approximately(_sfxSlider.value, 0f);
        //_Button.GameUIButtons[10].SetActive(!isSFXMuted); Bunu açma
        _sfxButtonMuteImage.gameObject.SetActive(isSFXMuted);

        if (AudioManager.sfxSource.mute == false)
        {
            AudioManager.recordedSFXValue = _sfxSlider.value;
        }
        else
        {
            AudioManager.recordedSFXValue2 = _sfxSlider.value;
            Debug.Log(AudioManager.recordedSFXValue2);
        }

        
        SaveVolumeData();
    }

    public void ContinueButton()
    {
        QuitButton();
    }
    #endregion


    #region Coin Values

    [System.Serializable]
    public class CoinValues
    {
        [HideInInspector]
        public string name;
        public int coinIncrease;
        public int coinDecrease;
    }



    public void IncreaseCoinValue(int increase)
    {
        _coinText += increase;
        CoinText.text = _coinText.ToString();
    }

    public void DecreaseCoinValue(int Decrease)
    {
        _coinText -= Decrease;
        CoinText.text = _coinText.ToString();
    }

    public void WaveStartCoinFunction()
    {
        if (WaveSpawner.waveIndex == 0)
        {
            Product = 0;
            return;
        }

        Product = GameManager._Product;
        float count = WaveSpawner.waveCountdown * Product;
        _coinText += (int)count;
        CoinText.text = _coinText.ToString();
    }
    #endregion

    public void Winning()
    {
        //E�er dalga 12 olur ve t�m d��manlar �l�rse restart (Tekrar Ba�lat) ve continue (Devam Et) butonlar�n� aktif hale getirme
        if (_waveText >= 12 && WaveSpawner.totalenemiescheck == 0)
        {
            _Button.GameUIButtons[2].SetActive(true);
            _Button.GameUIButtons[11].SetActive(true);
        }
    }

    public void DefeatMenu()
    {
        //Can de�eri 0 olduktan sonra oyunu durdurma ve restart (Tekrar Ba�lat), Quit (��k�� Yapmak) butonlar�n� aktif hale getirme
        _Button.GameUIButtons[2].SetActive(true);
        _Button.GameUIButtons[3].SetActive(true);
    }

    public void HearthDamage(int damage)
    {
        _heartText -= damage;
        AudioManager.PlaySFX("HeartDamageSound");
        heartText.text = _heartText.ToString();
    }

    public void WaveValue(int wave)
    {
        _waveText += wave;
        WaveText.text = _waveText.ToString() + "/" + GameManager._basicRobot.Length.ToString();
    }
    void WaveCounter()
    {
        if (WaveSpawner.waveCountdown <= 0)
        {
            WaveValue(1);
        }
    }
}
