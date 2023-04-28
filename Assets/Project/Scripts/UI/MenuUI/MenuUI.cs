using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuUI : MonoBehaviour
{
    AudioManager AudioManager;
    [SerializeField] private Slider _musicSlider;
    [SerializeField] private Slider _sfxSlider;
    [SerializeField] private List<GameObject> _buttons;

    private void Awake()
    {
        _buttons[3].SetActive(false);
        _buttons[4].SetActive(false);
    }

    private void Start()
    {
        AudioManager = FindObjectOfType<AudioManager>();
    }

    public void BackButton()
    {
        _buttons[0].SetActive(true);
        _buttons[1].SetActive(true);
        _buttons[2].SetActive(true);
        _buttons[5].SetActive(false);
        _buttons[6].SetActive(false);
        _buttons[7].SetActive(false);
    }

    public void OptionsButton()
    {
        _buttons[0].SetActive(false);
        _buttons[1].SetActive(false);
        _buttons[2].SetActive(false);
        _buttons[5].SetActive(true);
        _buttons[6].SetActive(true);
        _buttons[7].SetActive(true);
    }

    public void ToggleMusic()
    {
        AudioManager.ToggleMusic();
    }

    public void ToggleSFX()
    {
        AudioManager.ToggleSFX();
    }

    public void MusicVolume()
    {
        AudioManager.MusicVolume(_musicSlider.value);
    }

    public void SFXVolume()
    {
        AudioManager.SFXVolume(_sfxSlider.value);
    }

    public void PlayButton()
    {
        SceneManager.LoadScene("Levels");
        Time.timeScale = 1;
    }

    public void QuitButton()
    {
        _buttons[3].SetActive(true);
        _buttons[4].SetActive(true);
    }

    public void NoButton()
    {
        _buttons[3].SetActive(false);
        _buttons[4].SetActive(false);
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
