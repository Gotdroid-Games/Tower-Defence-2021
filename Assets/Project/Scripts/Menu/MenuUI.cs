using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuUI : MonoBehaviour
{
    
    [SerializeField] Slider _musicSlider, _sfxSlider;
    [SerializeField] Buttonassignments _Buttons;


    #region Buttons
        [System.Serializable]
    public class Buttonassignments
    {
        public GameObject[] Buttons = new GameObject[7];

        void Button(GameObject playButton, GameObject optionsButton, GameObject QuitButton, GameObject _yesButton, GameObject _noButton, GameObject _backButton, GameObject _musicButton, GameObject _sfxButton)
        {
            Buttons[0] = playButton;
            Buttons[1] = optionsButton;
            Buttons[2] = QuitButton;
            Buttons[3] = _yesButton;
            Buttons[4] = _noButton;
            Buttons[5] = _backButton;
            Buttons[6] = _musicButton;
            Buttons[7] = _sfxButton;
        }
        
    }
    #endregion


    private void Awake()
    {
        
        _Buttons.Buttons[3].SetActive(false);
        _Buttons.Buttons[4].SetActive(false);
    }

    //[0] (playButton)
    //[1] (optionsButton)
    //[2] (QuitButton)
    //[3] (_yesButton)
    //[4] (_noButton)
    //[5] (_backButton)
    //[6] (_musicButton)
    //[7] (_sfxButton)

    public void BackButton()
    {
        _Buttons.Buttons[0].SetActive(true);
        _Buttons.Buttons[1].SetActive(true);
        _Buttons.Buttons[2].SetActive(true);
        _Buttons.Buttons[5].SetActive(false);
        _Buttons.Buttons[6].SetActive(false);
        _Buttons.Buttons[7].SetActive(false);

    }

    
    public void OptionsButton()
    {
        _Buttons.Buttons[0].SetActive(false);
        _Buttons.Buttons[1].SetActive(false);
        _Buttons.Buttons[2].SetActive(false);
        _Buttons.Buttons[5].SetActive(true);
        _Buttons.Buttons[6].SetActive(true);
        _Buttons.Buttons[7].SetActive(true);
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

    

    public void PlayButton()
    {
        SceneManager.LoadScene("Metehan");
    }

    public void QuitButton()
    {
        _Buttons.Buttons[3].SetActive(true);
        _Buttons.Buttons[4].SetActive(true);
    }


    public void NoButton()
    {
        _Buttons.Buttons[3].SetActive(false);
        _Buttons.Buttons[4].SetActive(false);
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
