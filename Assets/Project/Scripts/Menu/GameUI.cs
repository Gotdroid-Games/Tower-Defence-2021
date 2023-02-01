using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameUI : MonoBehaviour
{
    [SerializeField] GameObject _pauseButton;
    [SerializeField] GameObject _resumeButton;
    [SerializeField] GameObject _restartButton;
    [SerializeField] GameObject _quitButton;
    [SerializeField] GameObject _gameBG;
    [SerializeField] GameObject _optionsBG;
    [SerializeField] GameObject _exitButton;
    [SerializeField] GameObject _musicButton;
    [SerializeField] GameObject _sfxButton;

    public Slider _musicSlider, _sfxSlider;

    private void Awake()
    {
        _pauseButton.SetActive(true);
        _resumeButton.SetActive(false);
        _restartButton.SetActive(false);
        _quitButton.SetActive(false);
        _gameBG.SetActive(false);
        _optionsBG.SetActive(false);
        _exitButton.SetActive(false);
        _musicButton.SetActive(false);
        _sfxButton.SetActive(false);

    }
    public void PauseButton()
    {
        Time.timeScale = 0;
        _pauseButton.SetActive(false);
        _resumeButton.SetActive(true);
        _restartButton.SetActive(true);
        _quitButton.SetActive(true);
        _gameBG.SetActive(true);
        _optionsBG.SetActive(true);
        _exitButton.SetActive(true);
        _musicButton.SetActive(true);
        _sfxButton.SetActive(true);
    }

    public void ResumeButton()
    {
        Time.timeScale = 1;
        _pauseButton.SetActive(true);
        _resumeButton.SetActive(false);
        _restartButton.SetActive(false);
        _quitButton.SetActive(false);
        _gameBG.SetActive(false);
        _optionsBG.SetActive(false);
        _exitButton.SetActive(false);
        _musicButton.SetActive(false);
        _sfxButton.SetActive(false);
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
