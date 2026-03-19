using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ImageColorChanger : MonoBehaviour
{
    public Slider Red;
    public Slider Green;
    public Slider Blue;

    float RedValue;
    float GreenValue;
    float BlueValue;

    SaveDropdown SaveDropdown;

    //public TextMeshProUGUI RedText;
    //public TextMeshProUGUI GreenText;
    //public TextMeshProUGUI BlueText;

    public GameObject Recticle;

    public TextMeshProUGUI ButtonText;

    public TMP_InputField S1NameInput;
    //public TMP_InputField S2NameInput;
    //public TMP_InputField S3NameInput;

    public TextMeshProUGUI S1Name;
    //public TextMeshProUGUI S2Name;
    //public TextMeshProUGUI S3Name;



    void Start()
    {
        S1NameInput = GetComponent<TMP_InputField>();
        //S2NameInput = GetComponent<TMP_InputField>();
        //S3NameInput = GetComponent<TMP_InputField>();
        Debug.Log("Green Value: " + GreenValue);
    }
    void Update()
    {
        RedValue = Red.value;
        GreenValue = Green.value;
        BlueValue = Blue.value;

       

        Recticle.gameObject.GetComponent<Image>().color = new Color(RedValue, GreenValue, BlueValue);

        

        //LoadData();
        
    }

    public void SaveDataSlot1()
    {
        SaveDropdown = FindAnyObjectByType<SaveDropdown>();
        SaveDropdown.SaveCH();
        PlayerPrefs.SetFloat("RedValueS1", Red.value);
        PlayerPrefs.SetFloat("GreenValueS1", Green.value);
        PlayerPrefs.SetFloat("BlueValueS1", Blue.value);
    } 
    
    public void LoadDataSlot1()
    {
        Red.value = PlayerPrefs.GetFloat("RedValueS1");
        Green.value = PlayerPrefs.GetFloat("GreenValueS1");
        Blue.value = PlayerPrefs.GetFloat("BlueValueS1");
    }

    public void SaveDataSlot2()
    {
        SaveDropdown = FindAnyObjectByType<SaveDropdown>();
        SaveDropdown.SaveCH();
        PlayerPrefs.SetFloat("RedValueS2", Red.value);
        PlayerPrefs.SetFloat("GreenValueS2", Green.value);
        PlayerPrefs.SetFloat("BlueValueS2", Blue.value);
    }

    public void LoadDataSlot2()
    {
        Red.value = PlayerPrefs.GetFloat("RedValueS2");
        Green.value = PlayerPrefs.GetFloat("GreenValueS2");
        Blue.value = PlayerPrefs.GetFloat("BlueValueS2");
    }

    public void SaveDataSlot3()
    {
        SaveDropdown = FindAnyObjectByType<SaveDropdown>();
        SaveDropdown.SaveCH();
        PlayerPrefs.SetFloat("RedValueS3", Red.value);
        PlayerPrefs.SetFloat("GreenValueS3", Green.value);
        PlayerPrefs.SetFloat("BlueValueS3", Blue.value);
    }

    public void LoadDataSlot3()
    {
        Red.value = PlayerPrefs.GetFloat("RedValueS3");
        Green.value = PlayerPrefs.GetFloat("GreenValueS3");
        Blue.value = PlayerPrefs.GetFloat("BlueValueS3");
    }

    public void DeleteDataS1()
    {
        PlayerPrefs.DeleteKey("RedValueS1");
        PlayerPrefs.DeleteKey("GreenValueS1");
        PlayerPrefs.DeleteKey("BlueValueS1");

        Red.value = 0.5f;
        Green.value = 0.5f;
        Blue.value = 0.5f;

        SaveDropdown.DeleteCH();
    }
    public void DeleteDataS2()
    {
        PlayerPrefs.DeleteKey("RedValueS2");
        PlayerPrefs.DeleteKey("GreenValueS2");
        PlayerPrefs.DeleteKey("BlueValueS2");

        Red.value = 0.5f;
        Green.value = 0.5f;
        Blue.value = 0.5f;

        SaveDropdown.DeleteCH();

    }
    public void DeleteDataS3()
    {
        Debug.Log("Pressed");
        PlayerPrefs.DeleteKey("RedValueS3");
        PlayerPrefs.DeleteKey("GreenValueS3");
        PlayerPrefs.DeleteKey("BlueValueS3");

        Red.value = 0.5f;
        Green.value = 0.5f;
        Blue.value = 0.5f;

        SaveDropdown.DeleteCH();
    }

    

    public void DebugLog()
    {
        Debug.Log("Working");
    }

    
}
