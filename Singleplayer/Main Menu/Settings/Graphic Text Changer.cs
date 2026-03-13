using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GraphicTextChanger : MonoBehaviour
{
    [SerializeField] private Slider qualitySlider;
    [SerializeField] private TextMeshProUGUI GraphicsText;

    void Update()
    {
        if(qualitySlider.value == 0)
        {
            GraphicsText.text = "Balanced";
        }

        if (qualitySlider.value == 1)
        {
            GraphicsText.text = "Perfomant";
        }

        if (qualitySlider.value == 2)
        {
            GraphicsText.text = "High Fidelety";
        }
    }
}
