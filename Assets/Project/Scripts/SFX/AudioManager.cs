using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    GameUI GameUI;
    MenuUI MenuUI;
    public float recordedMusicValue;
    public float recordedMusicValue2;
    public float recordedSFXValue;
    public float recordedSFXValue2;
    public Sound[] musicSounds, sfxSounds;
    public AudioSource musicSource, sfxSource;




    private void Start()
    {
        GameUI = FindObjectOfType<GameUI>();
        MenuUI = FindObjectOfType<MenuUI>();
        PlayMusic("backgroundmusic");
    }


    public void PlayMusic(string name)
    {
        //Sound musicSound = Array.Find(musicSounds, x => x.name == name);

        Sound musicSound = null;
        foreach (Sound sound in musicSounds)
        {
            if (sound.name == name)
            {
                musicSound = sound;
                break;
            }
        }

        if (musicSound == null)
        {
            Debug.Log("Sound Not Found");
        }
        else
        {
            musicSource.clip = musicSound.clip;
            musicSource.Play();
        }
    }

    public void PlaySFX(string name)
    {
        Sound sfxSound = Array.Find(sfxSounds, x => x.name == name);

        if (sfxSound == null)
        {
            Debug.Log("Sound Not Found");
        }
        else
        {
            sfxSource.PlayOneShot(sfxSound.clip);
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
        GameUI._sfxButtonMuteImage.gameObject.SetActive(true);
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

        if (volume == 0)
        {

            musicSource.mute = true;
        }
        else
        {
            musicSource.mute = false;
        }
    }

    public void SFXVolume(float volume)
    {
        sfxSource.volume = volume;

        if (volume == 0)
        {
            sfxSource.mute = true;
        }
        else
        {
            sfxSource.mute = false;
        }
    }
}
