using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class GameUI : MonoBehaviour
{
    AudioManager AudioManager;
    [SerializeField] public ButtonAssignments _Button;
    public Slider _musicSlider, _sfxSlider;
    public Image wavestartinfopanel;
    public Image _musicButtonMuteImage;
    public Image _sfxButtonMute;
    public TextMeshProUGUI _musicText;
    public TextMeshProUGUI _sfxText;
    public string musicVolumeValue;
    public string sfxVolumeValue;

    #region Button
    [System.Serializable]


    //Oyun içerisinde bulunan tüm butonlar diziye atandý
    public class ButtonAssignments
    {
        public GameObject[] GameUIButtons = new GameObject[15];

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
        //Pause (Durdurma) butonu dýþýnda ki tüm butonlar pasif halde


        for (int i = 0; i < _Button.GameUIButtons.Length; i++)
        {
            _Button.GameUIButtons[i].SetActive(false);
        }
        _Button.GameUIButtons[0].SetActive(true);

    }
    private void Start()
    {
        AudioManager = FindObjectOfType<AudioManager>();
        _musicButtonMuteImage.gameObject.SetActive(false);
        _sfxButtonMute.gameObject.SetActive(false);

        if (AudioManager.musicSource.mute == false)
        {
            AudioManager.recordedMusicValue = _musicSlider.value;
        }
        else
        {
            AudioManager.recordedMusicValue2 = _musicSlider.value;
        }

        if (AudioManager.sfxSource.mute == false)
        {
            AudioManager.recordedSFXValue = _sfxSlider.value;
        }
        else
        {
            AudioManager.recordedSFXValue2 = _sfxSlider.value;
            Debug.Log(AudioManager.recordedSFXValue2);
        }
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
    // [9] (_continueButton)
    // [10] (_firstStart)
    // [11] (_secondStart)
    // [12] (_thirdStar)

    public void PauseButton()
    {
        //Oyunu durdurma ve Pause (Durdurma) butonu dýþýnda ki tüm butonlar aktif halde
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
        //Oyunu devam ettirme ve Pause (Durdurma) butonu dýþýnda ki tüm butonlar pasif halde
        Time.timeScale = 1;
        for (int i = 0; i < _Button.GameUIButtons.Length; i++)
        {
            _Button.GameUIButtons[i].SetActive(false);
        }
        _Button.GameUIButtons[0].SetActive(true);
    }

    public void RestartButton()
    {
        //Oyunu yeniden baþlatma
        Scene scene;
        scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
        Time.timeScale = 1;
    }

    public void DefeatMenu()
    {
        //Can deðeri 0 olduktan sonra oyunu durdurma ve restart (Tekrar Baþlat), Quit (Çýkýþ Yapmak) butonlarýný aktif hale getirme
        Time.timeScale = 0;
        _Button.GameUIButtons[2].SetActive(true);
        _Button.GameUIButtons[3].SetActive(true);
    }

    public void QuitButton()
    {
        //Ana menüye döndürme
        SceneManager.LoadScene("Menu");
    }

    public void ExitButton()
    {
        //Çarpý ikonu oyuna devam etme
        ResumeButton();
    }

    #endregion

    #region Volume function
    public void ToggleMusic()
    {
        //Müzik sesini susturma ve aktif etme
        AudioManager.GameToggleMusic();
        _musicSlider.value = 0;
    }
    public void ToggleMusicMute()
    {
        AudioManager.GameToggleMusic();
        _Button.GameUIButtons[9].SetActive(true);
        _musicButtonMuteImage.gameObject.SetActive(false);
        _musicSlider.value = AudioManager.recordedMusicValue;
        Debug.Log("mute kaldýrýldý");
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
        _sfxButtonMute.gameObject.SetActive(false);
        _sfxSlider.value = AudioManager.recordedSFXValue;

    }

    public void MusicVolume()
    {
        ////Kaydýrýcý ile ses düzeyini ayarlama (Arttýrma ve kýsma)
        //AudioManager.MusicVolume(_musicSlider.value);
        //musicVolumeValue = (_musicSlider.value * 100).ToString("0");
        //_musicText.text = musicVolumeValue;

        //if (_musicSlider.value == 0)
        //{
        //    _Button.GameUIButtons[9].SetActive(false);
        //    _musicButtonMuteImage.gameObject.SetActive(true);
        //}
        //else
        //{
        //    _Button.GameUIButtons[9].SetActive(true);
        //    _musicButtonMuteImage.gameObject.SetActive(false);
        //}

        //if (AudioManager.musicSource.mute == false)
        //{
        //    AudioManager.recordedMusicValue = _musicSlider.value;
        //    Debug.Log(AudioManager.recordedMusicValue);
        //}
        //else
        //{
        //    AudioManager.recordedMusicValue2 = _musicSlider.value;
        //    Debug.Log(AudioManager.recordedMusicValue2);
        //}

        //Kaydýrýcý ile ses düzeyini ayarlama (Arttýrma ve kýsma)
        AudioManager.MusicVolume(_musicSlider.value);
        musicVolumeValue = (_musicSlider.value * 100).ToString("0");
        _musicText.text = musicVolumeValue;

        bool isMusicMuted = _musicSlider.value == 0;
        _Button.GameUIButtons[9].SetActive(!isMusicMuted);
        _musicButtonMuteImage.gameObject.SetActive(isMusicMuted);

        if (AudioManager.musicSource.mute == false)
        {
            AudioManager.recordedMusicValue = _musicSlider.value;
        }
        else
        {
            AudioManager.recordedMusicValue2 = _musicSlider.value;
        }

        Debug.Log(AudioManager.musicSource.mute ? AudioManager.recordedMusicValue2 : AudioManager.recordedMusicValue);

    }

    public void SFXVolume()
    {
        ////Kaydýrýcý ile ses düzeyini ayarlama (Arttýrma ve kýsma)
        //AudioManager.SFXVolume(_sfxSlider.value);

        //sfxVolumeValue = (_sfxSlider.value * 100).ToString("0");
        //_sfxText.text = sfxVolumeValue;

        //if (_sfxSlider.value == 0)
        //{
        //    _Button.GameUIButtons[10].SetActive(false);
        //    _sfxButtonMute.gameObject.SetActive(true);
        //}

        //else
        //{
        //    _Button.GameUIButtons[10].SetActive(true);
        //    _sfxButtonMute.gameObject.SetActive(false);
        //}

        //if (AudioManager.sfxSource.mute == false)
        //{
        //    AudioManager.recordedSFXValue = _sfxSlider.value;
        //}
        //else
        //{
        //    AudioManager.recordedSFXValue2 = _sfxSlider.value;
        //    Debug.Log(AudioManager.recordedSFXValue2);
        //}

        AudioManager.SFXVolume(_sfxSlider.value);

        sfxVolumeValue = (_sfxSlider.value * 100).ToString("0");
        _sfxText.text = sfxVolumeValue;

        bool isSFXMuted = Mathf.Approximately(_sfxSlider.value, 0f);
        _Button.GameUIButtons[10].SetActive(!isSFXMuted);
        _sfxButtonMute.gameObject.SetActive(isSFXMuted);

        if (AudioManager.sfxSource.mute == false)
        {
            AudioManager.recordedSFXValue = _sfxSlider.value;
        }
        else
        {
            AudioManager.recordedSFXValue2 = _sfxSlider.value;
            Debug.Log(AudioManager.recordedSFXValue2);
        }
    }

    public void ContinueButton()
    {
        QuitButton();
    }
    #endregion
}
