using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameUI : MonoBehaviour
{
    [SerializeField] ButtonAssignments _Button;
    public static GameUI Instance;
    public Slider _musicSlider, _sfxSlider;

    #region Button
    [System.Serializable]
    
    public class ButtonAssignments
    {
        public GameObject[] GameUIButtons = new GameObject[8];

        void GameUIButton(GameObject _pauseButton, GameObject _resumeButton, GameObject _restartButton, GameObject _quitButton, GameObject _gameBG, GameObject _optionsBG, GameObject _exitButton, GameObject _musicButton, GameObject _sfxButton)

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
        }
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
    private void Awake()
    {
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

    public void PauseButton()
    {
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

    public void ResumeButton()
    {
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
        Scene scene;
        scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
        Time.timeScale = 1;
    }

    public void QuitButton()
    {
        SceneManager.LoadScene("Menu");
    }

    public void ExitButton()
    {
        ResumeButton();
    }

    public void ToggleMusic()
    {
        AudioManager.Instance.ToggleMusic();
    }

    public void ToggleSFX()
    {
        AudioManager.Instance.ToggleSFX();
    }

    public void MusicVolume()
    {
        AudioManager.Instance.MusicVolume(_musicSlider.value);
    }

    public void SFXVolume()
    {
        AudioManager.Instance.SFXVolume(_sfxSlider.value);
    }
}
