using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Localization : MonoBehaviour
{
    public TMP_Dropdown dropDown;

    public Sprite[] crosshairs;

    void Start()
    {
        dropDown.ClearOptions();

        List<Dropdown.OptionData> crosshairItems = new List<Dropdown.OptionData>();

        foreach (var crosshair in crosshairs) 
        {
        
            string crosshairName = crosshair.name;
            int dot = crosshairName.IndexOf('.');
            if (dot >= 0)
            {
                crosshairName = crosshairName.Substring(dot + 1);
            }
            var crosshairOption = new Dropdown.OptionData(crosshair.name, crosshair);
            crosshairItems.Add(crosshairOption);
        
        }
    }
}
