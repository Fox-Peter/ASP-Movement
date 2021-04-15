using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class OptionsMenuManager : MonoBehaviour
{
    public AudioMixer m_audioMixer;
    public MenuSettings menuSettings;
    public Slider musicSlider;
    public Slider sfxSlider;

    void Start()
    {
        musicSlider.value = menuSettings.musicSliderValue;
        sfxSlider.value = menuSettings.sfxSliderValue;
    }

    public void SetSFXVolume(float volume)
    {
        menuSettings.sfxSliderValue = volume;
        volume = Mathf.Log10(volume) * 20;

        m_audioMixer.SetFloat("sfxVolume", volume);
    }

    public void SetMusicVolume(float volume)
    {
        menuSettings.musicSliderValue = volume;
        volume = Mathf.Log10(volume) * 20;

        m_audioMixer.SetFloat("musicVolume", volume);
    }
}
