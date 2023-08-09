using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering;
using System.IO;
public class MenuUI : MonoBehaviour
{
    AudioManager AudioManager;
    [SerializeField] private Slider _musicSlider;
    [SerializeField] private Slider _sfxSlider;
    public Image _musicButtonMuteImage;
    public Image _sfxButtonMuteImage;
    public string musicVolumeValue;
    public string sfxVolumeValue;
    public TextMeshProUGUI _musicText;
    public TextMeshProUGUI _sfxText;
    public List<GameObject> _buttons;
    private string dataFilePath;


    [System.Serializable]
    public class VolumeData
    {
        public float musicVolumeValue;
        public float sfxVolumeValue;
    }



    private void Awake()
    {
        dataFilePath = Path.Combine(Application.dataPath, "volumeData.json");
        _buttons[3].SetActive(false);
        _buttons[4].SetActive(false);
    }

    private void Start()
    {
       
        AudioManager = FindObjectOfType<AudioManager>();
        _musicButtonMuteImage.gameObject.SetActive(false);
        _sfxButtonMuteImage.gameObject.SetActive(false);
        _buttons[6].SetActive(false);
        _buttons[7].SetActive(false);
        _buttons[8].SetActive(false);
        _buttons[9].SetActive(false);

        if (!AudioManager.musicSource.mute)
        {
            AudioManager.recordedMusicValue = _musicSlider.value;
            Debug.Log(AudioManager.recordedMusicValue);
        }
        else
        {
            AudioManager.recordedMusicValue2 = AudioManager.recordedMusicValue;
            Debug.Log(AudioManager.recordedMusicValue2);
        }

        if (AudioManager.sfxSource.mute == false)
        {
            AudioManager.recordedSFXValue = _sfxSlider.value;
            Debug.Log(AudioManager.recordedSFXValue);
        }
        else
        {
            AudioManager.recordedSFXValue2 = AudioManager.recordedSFXValue;
            Debug.Log(AudioManager.recordedSFXValue2);
        }
        LoadVolumeData();
    }

    private void LoadVolumeData()
    {
         if (File.Exists(dataFilePath))
        {
            string jsonData = File.ReadAllText(dataFilePath);
            VolumeData volumedata = JsonUtility.FromJson<VolumeData>(jsonData);
            musicVolumeValue = volumedata.musicVolumeValue.ToString("0.00");
            sfxVolumeValue = volumedata.sfxVolumeValue.ToString("0.00");
            _musicSlider.value = volumedata.musicVolumeValue;
            _sfxSlider.value = volumedata.sfxVolumeValue;
        }
    }

    private void SaveVolumeData()
    {
        VolumeData volumedata = new VolumeData
        {
            musicVolumeValue = _musicSlider.value,
            sfxVolumeValue = _sfxSlider.value

        };

        string jsonData = JsonUtility.ToJson(volumedata);
        File.WriteAllText(dataFilePath, jsonData);
    }

    private void Update()
    {
        
        
        
    }

    public void BackButton()
    {
        _buttons[0].SetActive(true);
        _buttons[1].SetActive(true);
        _buttons[2].SetActive(true);
        _buttons[5].SetActive(false);
        _buttons[6].SetActive(false);
        _buttons[7].SetActive(false);
        _buttons[8].SetActive(false);
        _buttons[9].SetActive(false);
    }

    public void OptionsButton()
    {
        _buttons[0].SetActive(false);
        _buttons[1].SetActive(false);
        _buttons[2].SetActive(false);
        _buttons[5].SetActive(true);
        _buttons[6].SetActive(true);
        _buttons[7].SetActive(true);
        _buttons[8].SetActive(true);
        _buttons[9].SetActive(true);
    }

    public void MenuToggleMusic()
    {
        AudioManager.MenuToggleMusic();
        _musicSlider.value = 0;
    }

    public void MenuToggMusicMute()
    {
        AudioManager.MenuToggleMusic();
        _buttons[8].SetActive(true);
        _musicButtonMuteImage.gameObject.SetActive(false);
        _musicSlider.value = AudioManager.recordedMusicValue2;
    }

    public void MenuToggleSFX()
    {
        AudioManager.MenuToggleSFX();
        _sfxSlider.value = 0;
    }

    public void MenuToggleSFXMute()
    {
        AudioManager.MenuToggleSFX();
        _buttons[9].SetActive(true);
        _sfxButtonMuteImage.gameObject.SetActive(false);
        _sfxSlider.value = AudioManager.recordedSFXValue2;
    }

    public void MusicVolume()
    {

        AudioManager.MusicVolume(_musicSlider.value);
        musicVolumeValue = (_musicSlider.value * 100).ToString("0");
        _musicText.text = musicVolumeValue;

        bool isMusicMuted = Mathf.Approximately(_musicSlider.value, 0f);
        _buttons[8].SetActive(!isMusicMuted);
        _musicButtonMuteImage.gameObject.SetActive(isMusicMuted);

        if (!AudioManager.musicSource.mute)
        {
            AudioManager.recordedMusicValue = _musicSlider.value;
            Debug.Log(AudioManager.recordedMusicValue);
        }
        else
        {
            AudioManager.recordedMusicValue2 = AudioManager.recordedMusicValue;
            Debug.Log(AudioManager.recordedMusicValue2);
        }
        SaveVolumeData();
    }

    public void SFXVolume()
    {
        AudioManager.SFXVolume(_sfxSlider.value);
        sfxVolumeValue = (_sfxSlider.value * 100).ToString("0");
        _sfxText.text = sfxVolumeValue;

        bool isSFXMuted = Mathf.Approximately(_sfxSlider.value, 0f);
        _buttons[9].SetActive(!isSFXMuted);
        _sfxButtonMuteImage.gameObject.SetActive(isSFXMuted);

        if (AudioManager.sfxSource.mute == false)
        {
            AudioManager.recordedSFXValue = _sfxSlider.value;
            Debug.Log(AudioManager.recordedSFXValue);
        }
        else
        {
            AudioManager.recordedSFXValue2 = AudioManager.recordedSFXValue;
            Debug.Log(AudioManager.recordedSFXValue2);
        }
        SaveVolumeData();
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
