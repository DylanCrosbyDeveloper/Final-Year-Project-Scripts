using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SettingsMenu : MonoBehaviour
{
    [SerializeField] private Slider qualitySlider;
    [SerializeField] public Slider volumeSlider;
    [SerializeField] private AudioMixer mixer;
    [SerializeField] private Toggle isFullscreen;

    private void Start()
    {
        RefreshSettings();
    }

    public void RefreshSettings()
    {
        qualitySlider.value = Settings.QualityLevel;
        volumeSlider.value = Settings.Volume;
        isFullscreen.isOn = true;

        if (isFullscreen.isOn)
        {
            Screen.fullScreen = true;
        }
        else
        {
            Screen.fullScreen = false;
        }


        Apply();
    }

    public void Apply()
    {
        Settings.QualityLevel = (int)qualitySlider.value;
        Settings.Volume = volumeSlider.value;

        QualitySettings.SetQualityLevel(Settings.QualityLevel);
        mixer.SetFloat("Master", Mathf.Log10(Settings.Volume) * 20);

        
    }

    

    public void Awake()
    {
        Apply();
    }
}
