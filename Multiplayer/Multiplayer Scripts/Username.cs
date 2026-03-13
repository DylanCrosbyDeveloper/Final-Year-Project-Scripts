using UnityEngine;
using Unity.Netcode.Components;
using Unity.Netcode;
using UnityEngine.UI;
using TMPro;
public class Username : NetworkBehaviour
{
    public TMP_InputField Username_Input;
    public Button Save;
    public Button Delete;
    public TextMeshPro Username_WorldUI;
    bool UsernameAdded;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Username_Input = GetComponent<TMP_InputField>();
        //Username_Input.onValueChanged.AddListener(delegate { ValueChangeCheck();  });

        Save.onClick.AddListener(delegate { SaveUsername(); });
        Delete.onClick.AddListener(delegate { DeleteUsername(); });
    }

    // Update is called once per frame
    void Update()
    {
        if (UsernameAdded) 
        {
            Username_WorldUI.gameObject.SetActive(true);
            Username_WorldUI.text = Username_Input.ToString();

            
        }

    }

    void ValueChangeCheck()
    {
        UsernameAdded = true;
    }

    public void SaveUsername()
    {
        PlayerPrefs.SetString("Username_WorldUI", Username_WorldUI.ToString());
    }

    public void DeleteUsername()
    {
        PlayerPrefs.DeleteKey("Username_WorldUI");
    }
}
