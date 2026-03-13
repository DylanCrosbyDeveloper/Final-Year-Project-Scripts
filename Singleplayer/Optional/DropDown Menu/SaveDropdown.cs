using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;


public class SaveDropdown : MonoBehaviour
{
    const string PrefName = "optionvalue";
    public Sprite[] Crosshair;
    private TMP_Dropdown _dropdown;

    
    void Awake()
    {
        PlayerPrefs.GetInt(PrefName, 0);
        _dropdown = GetComponent<TMP_Dropdown>();

        _dropdown.onValueChanged.AddListener(new UnityAction<int>(index =>
        {
            SaveCH();
        }));
        
    }
    void Start()
    {
        _dropdown.value = PlayerPrefs.GetInt(PrefName, 0);
    }

   public void SaveCH()
    {
        PlayerPrefs.SetInt(PrefName, _dropdown.value);
        PlayerPrefs.Save();
    }
    public void DeleteCH()
    {
        PlayerPrefs.DeleteKey(PrefName);
    }
}
