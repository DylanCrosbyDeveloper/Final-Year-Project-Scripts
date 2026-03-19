using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIChange : MonoBehaviour
{
    public GameObject ColorChanger;
    public GameObject WeaponSwitcher;
    public KeyCode ColorChangerKey;
    public KeyCode WeaponSwitcherKey;

    GameObject cam;
    Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        ColorChanger.SetActive(false);
        cam = GameObject.Find("PlayerCamera");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(ColorChangerKey))
        {
            Time.timeScale = 0;
            ColorChanger.SetActive(true);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;

          

            
        }
        
        if (Input.GetKeyDown(WeaponSwitcherKey))
        {
            Time.timeScale = 0;
            WeaponSwitcher.SetActive(true);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;

          

            
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 1;
            ColorChanger.SetActive(false);
            WeaponSwitcher.SetActive(false);
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;

            
        }
    }
}
