using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    GameUI GameUI;
    MenuUI MenuUI;
    int deneme;
    public Sound[] musicSounds, sfxSounds;
    public AudioSource musicSource, sfxSource;



    private void Start()
    {
        GameUI = FindObjectOfType<GameUI>();
        MenuUI = FindObjectOfType<MenuUI>();
        PlayMusic("Theme");
    }


    public void PlayMusic(string name)
    {
        Sound s = Array.Find(musicSounds, x => x.name == name);

        if (s == null)
        {
            Debug.Log("Sound Not Found");
        }
        else
        {
            musicSource.clip = s.clip;
            musicSource.Play();
        }
    }

    public void PlaySFX(string name)
    {
        Sound s = Array.Find(sfxSounds, x => x.name == name);

        if (s == null)
        {
            Debug.Log("Sound Not Found");
        }
        else
        {
            sfxSource.PlayOneShot(s.clip);
        }
    }


    public void GameToggleMusic()
    {
        musicSource.mute = !musicSource.mute;
        GameUI._Button.GameUIButtons[9].SetActive(false);
        GameUI._musicButtonMuteImage.gameObject.SetActive(true);
        Debug.Log("mute edildi");
    }
    public void GameToggleSFX()
    {
        sfxSource.mute = !sfxSource.mute;
        GameUI._Button.GameUIButtons[10].SetActive(false);
        GameUI._sfxButtonMute.gameObject.SetActive(true);
        Debug.Log("SFX Mute");
    }
    public void MenuToggleMusic()
    {
        musicSource.mute = !musicSource.mute;
        MenuUI._buttons[8].SetActive(false);
        MenuUI._musicButtonMuteImage.gameObject.SetActive(true);
        Debug.Log("mute edildi");
    }
    
    public void MenuToggleSFX()
    {
        sfxSource.mute = !sfxSource.mute;
        MenuUI._buttons[9].SetActive(false);
        MenuUI._sfxButtonMuteImage.gameObject.SetActive(true);
        Debug.Log("SFX Mute");
    }

    public void MusicVolume(float volume)
    {
        musicSource.volume = volume;
    }

    public void SFXVolume(float volume)
    {
        sfxSource.volume = volume;
    }
}
