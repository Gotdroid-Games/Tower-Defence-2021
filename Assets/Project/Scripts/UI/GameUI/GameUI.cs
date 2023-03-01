using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class GameUI : MonoBehaviour
{
    [SerializeField] public ButtonAssignments _Button;
    public static GameUI Instance;
    public Slider _musicSlider, _sfxSlider;

    #region Button
    [System.Serializable]
    

    //Oyun içerisinde bulunan tüm butonlar diziye atandý
    public class ButtonAssignments
    {
        public GameObject[] GameUIButtons = new GameObject[13];

        void GameUIButton(GameObject _pauseButton, GameObject _resumeButton, GameObject _restartButton, GameObject _quitButton, GameObject _gameBG, GameObject _optionsBG, GameObject _exitButton, GameObject _musicButton, GameObject _sfxButton, GameObject _continueButton,GameObject _firstStar, GameObject _secondStar, GameObject _thirdStar)

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
        }
    }
    private void Start()
    {
        Instance = this;
    }
    #endregion

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
        _Button.GameUIButtons[0].SetActive(true);
        _Button.GameUIButtons[1].SetActive(false);
        _Button.GameUIButtons[2].SetActive(false);
        _Button.GameUIButtons[3].SetActive(false);
        _Button.GameUIButtons[4].SetActive(false);
        _Button.GameUIButtons[5].SetActive(false);
        _Button.GameUIButtons[6].SetActive(false);
        _Button.GameUIButtons[7].SetActive(false);
        _Button.GameUIButtons[8].SetActive(false);
        _Button.GameUIButtons[9].SetActive(false);
        _Button.GameUIButtons[10].SetActive(false);
        _Button.GameUIButtons[11].SetActive(false);
        _Button.GameUIButtons[12].SetActive(false);

    }

    public void PauseButton()
    {
        //Oyunu durdurma ve Pause (Durdurma) butonu dýþýnda ki tüm butonlar aktif halde
        Time.timeScale = 0;
        _Button.GameUIButtons[0].SetActive(false);
        _Button.GameUIButtons[1].SetActive(true);
        _Button.GameUIButtons[2].SetActive(true);
        _Button.GameUIButtons[3].SetActive(true);
        _Button.GameUIButtons[4].SetActive(true);
        _Button.GameUIButtons[5].SetActive(true);
        _Button.GameUIButtons[6].SetActive(true);
        _Button.GameUIButtons[7].SetActive(true);
        _Button.GameUIButtons[8].SetActive(true);
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

    public void ResumeButton()
    {
        //Oyunu devam ettirme ve Pause (Durdurma) butonu dýþýnda ki tüm butonlar pasif halde
        Time.timeScale = 1;
        _Button.GameUIButtons[0].SetActive(true);
        _Button.GameUIButtons[1].SetActive(false);
        _Button.GameUIButtons[2].SetActive(false);
        _Button.GameUIButtons[3].SetActive(false);
        _Button.GameUIButtons[4].SetActive(false);
        _Button.GameUIButtons[5].SetActive(false);
        _Button.GameUIButtons[6].SetActive(false);
        _Button.GameUIButtons[7].SetActive(false);
        _Button.GameUIButtons[8].SetActive(false);
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

    public void ToggleMusic()
    {
        //Müzik sesini susturma ve aktif etme
        AudioManager.Instance.ToggleMusic();
    }

    public void ToggleSFX()
    {
        //Ses efektlerini susturma ve aktif etme
        AudioManager.Instance.ToggleSFX();
    }

    public void MusicVolume()
    {
        //Kaydýrýcý ile ses düzeyini ayarlama (Arttýrma ve kýsma)
        AudioManager.Instance.MusicVolume(_musicSlider.value);
    }

    public void SFXVolume()
    {
        //Kaydýrýcý ile ses düzeyini ayarlama (Arttýrma ve kýsma)
        AudioManager.Instance.SFXVolume(_sfxSlider.value);
    }

    public void ContinueButton()
    {
        QuitButton();
    }
}
