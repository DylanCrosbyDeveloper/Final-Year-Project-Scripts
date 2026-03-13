using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class VolumeTextChange : MonoBehaviour
{
    [SerializeField] private Slider volumeSlider;
    [SerializeField] private TextMeshProUGUI volumeText;
    float volumeCount;

    void Update()
    {
        volumeCount = Settings.Volume * 100;
        volumeCount = Mathf.Round(volumeCount);

        volumeText.text = volumeCount.ToString() + "%";
    }
}
