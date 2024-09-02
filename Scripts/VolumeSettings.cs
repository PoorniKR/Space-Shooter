using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSettings : MonoBehaviour
{
    [SerializeField] private AudioMixer myMixer;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider SFXSlider;

    public GameObject MusicOnButton;
    public GameObject MusicOffButton;
    public GameObject SFXOnButton;
    public GameObject SFXOffButton;
    public GameObject settingPanel;
    public GameObject exitButton;
    public GameObject close1;
    public GameObject close2;
    public GameObject pausePanel;

    private const string MusicPrefKey = "MusicEnabled";
    private bool musicEnabled = true;

    private const string SFXPrefKey = "SFXEnabled";
    private bool SFXEnabled = true;


    void Start()
    {
        if(PlayerPrefs.HasKey("musicVolume"))
        {
            LoadVolume();
        }
        else
        {
            SetMusicVolume();
            SetSFXVolume();
        }

        if (PlayerPrefs.HasKey(MusicPrefKey))
        {
            musicEnabled = PlayerPrefs.GetInt(MusicPrefKey) == 1;
        }
        if (musicEnabled)
        {
            MusicOff();
        }
        else
        {
            MusicOn();
        }

         if (PlayerPrefs.HasKey(SFXPrefKey))
        {
            SFXEnabled = PlayerPrefs.GetInt(SFXPrefKey) == 1;
        }
        if (SFXEnabled)
        {
            SFXOff();
        }
        else
        {
            SFXOn();
        }

    }

    public void SetMusicVolume()
    {
        float volume = musicSlider.value;
        myMixer.SetFloat("music",Mathf.Log10(volume)*20);
        PlayerPrefs.SetFloat("musicVolume",volume);
    }

    public void SetSFXVolume()
    {
        float volume = SFXSlider.value;
        myMixer.SetFloat("SFX",Mathf.Log10(volume)*20);
        PlayerPrefs.SetFloat("SFXVolume",volume);
    }

    private void LoadVolume()
    {
        musicSlider.value = PlayerPrefs.GetFloat("musicVolume");
        SFXSlider.value = PlayerPrefs.GetFloat("SFXVolume");
        SetMusicVolume();
        SetSFXVolume();
    }

    public void MusicOn()
    {
        MusicOffButton.SetActive(true);
        musicSlider.interactable = false;
        musicSlider.value = 0;
        PlayerPrefs.SetInt(MusicPrefKey, 0);
    }

    public void MusicOff()
    {
        MusicOffButton.SetActive(false);
        MusicOnButton.SetActive(true);
        musicSlider.interactable = true;
        musicSlider.value = 1;
        PlayerPrefs.SetInt(MusicPrefKey, 1);
    }

    public void SFXOn()
    {
        SFXOffButton.SetActive(true);
        SFXSlider.interactable = false;
        SFXSlider.value = 0;
        PlayerPrefs.SetInt(SFXPrefKey, 0);
    }

    public void SFXOff()
    {
        SFXOffButton.SetActive(false);
        SFXOnButton.SetActive(true);
        SFXSlider.interactable = true;
        SFXSlider.value = 1;
        PlayerPrefs.SetInt(SFXPrefKey, 1);
    }

    public void SettingMain()
    {
        settingPanel.SetActive(true);
        exitButton.SetActive(false);
        close2.SetActive(false);
        close1.SetActive(true);
    }  

    public void SettingPause()
    {
        settingPanel.SetActive(true);
        exitButton.SetActive(false);
        close1.SetActive(false);
        close2.SetActive(true);
    }   

    public void MainClose()
    {
        settingPanel.SetActive(false);
        exitButton.SetActive(true);
    } 

    public void PauseClose()
    {
        settingPanel.SetActive(false);
    } 
}
