using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameUI : MonoBehaviour
{
    AudioManager AudioManager;
    [SerializeField] public ButtonAssignments _Button;
    public Slider _musicSlider, _sfxSlider;

    #region Button
    [System.Serializable]
    

    //Oyun içerisinde bulunan tüm butonlar diziye atandý
    public class ButtonAssignments
    {
        public GameObject[] GameUIButtons = new GameObject[14];

        void GameUIButton(GameObject _pauseButton, GameObject _resumeButton, GameObject _restartButton, GameObject _quitButton, GameObject _gameBG, GameObject _optionsBG, GameObject _exitButton, GameObject _musicButton, GameObject _sfxButton, GameObject _continueButton,GameObject _firstStar, GameObject _secondStar, GameObject _thirdStar, GameObject _continueButtonEndGame)

        {
            GameUIButtons[0] = _pauseButton;
            GameUIButtons[1] = _resumeButton;
            GameUIButtons[2] = _restartButton;
            GameUIButtons[3] = _quitButton;
            GameUIButtons[4] = _gameBG;
            GameUIButtons[5] = _optionsBG;
            GameUIButtons[6] = _exitButton;
            GameUIButtons[7] = _musicButton;
            GameUIButtons[8] = _sfxButton;
            GameUIButtons[9] = _continueButton;
            GameUIButtons[10] = _firstStar;
            GameUIButtons[11] = _secondStar;
            GameUIButtons[12] = _thirdStar;
            GameUIButtons[13] = _continueButtonEndGame;
        }
    }
    #endregion
    private void Start()
    {
        AudioManager = FindObjectOfType<AudioManager>();
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

    private void Awake()
    {
        //Pause (Durdurma) butonu dýþýnda ki tüm butonlar pasif halde
        
        for (int i = 0; i < _Button.GameUIButtons.Length; i++)
        {
            _Button.GameUIButtons[i].SetActive(false);
        }
        _Button.GameUIButtons[0].SetActive(true);

    }

    public void PauseButton()
    {
        //Oyunu durdurma ve Pause (Durdurma) butonu dýþýnda ki tüm butonlar aktif halde
        Time.timeScale = 0;
        for (int i = 0; i < _Button.GameUIButtons.Length; i++)
        {
            _Button.GameUIButtons[i].SetActive(true);
        }
        _Button.GameUIButtons[0].SetActive(false);
        _Button.GameUIButtons[9].SetActive(false);
        _Button.GameUIButtons[10].SetActive(false);
        _Button.GameUIButtons[11].SetActive(false);
        _Button.GameUIButtons[12].SetActive(false);
        _Button.GameUIButtons[13].SetActive(false);

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
        AudioManager.ToggleMusic();
    }

    public void ToggleSFX()
    {
        //Ses efektlerini susturma ve aktif etme
        AudioManager.ToggleSFX();
    }

    public void MusicVolume()
    {
        //Kaydýrýcý ile ses düzeyini ayarlama (Arttýrma ve kýsma)
        AudioManager.MusicVolume(_musicSlider.value);
    }

    public void SFXVolume()
    {
        //Kaydýrýcý ile ses düzeyini ayarlama (Arttýrma ve kýsma)
        AudioManager.SFXVolume(_sfxSlider.value);
    }

    public void ContinueButton()
    {
        QuitButton();
    }
    #endregion
}
