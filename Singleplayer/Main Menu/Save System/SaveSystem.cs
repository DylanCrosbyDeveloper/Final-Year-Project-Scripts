using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SaveSystem : MonoBehaviour
{
    public Slider qualitySlider;
    public Slider volumeSlider;

    public float VolumeValue;
    public float qualityValue;

    public void Update()
    {
        VolumeValue = volumeSlider.value;
        qualityValue = qualitySlider.value;
    }

    public void SaveData()
    {
        PlayerPrefs.SetFloat("Volume", VolumeValue);
        PlayerPrefs.SetFloat("Quality", qualityValue);
    }

    public void LoadData()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("Volume");
        qualitySlider.value = PlayerPrefs.GetFloat("Quality");
    }

    void Awake()
    {
        LoadData();
    }
}
