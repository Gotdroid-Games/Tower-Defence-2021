using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor.Experimental.RestService;
using Newtonsoft.Json.Linq;
using Unity.VisualScripting;

public class MenuUI : MonoBehaviour
{
    [Header("Button System") ]
    [SerializeField] GameObject playButton;
    [SerializeField] GameObject optionsButton;
    [SerializeField] GameObject QuitButton;
    [SerializeField] GameObject _backButton;
    [SerializeField] GameObject _musicButton,_sfxButton;
    [SerializeField] Slider _musicSlider, _sfxSlider;



    private void Awake()
    {
        _backButton.SetActive(false);
        _musicButton.SetActive(false);
        _sfxButton.SetActive(false);
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

    public void BackButton()
    {
        playButton.SetActive(true);
        optionsButton.SetActive(true);
        QuitButton.SetActive(true);
        _backButton.SetActive(false);
        _sfxButton.SetActive(false);
        _musicButton.SetActive(false);
    }

    public void PlayButton()
    {
        SceneManager.LoadScene("Metehan");
    }

    public void OptionsButton()
    {
        playButton.SetActive(false);
        optionsButton.SetActive(false);
        QuitButton.SetActive(false);
        _backButton.SetActive(true);
        _sfxButton.SetActive(true);
        _musicButton.SetActive(true);
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
