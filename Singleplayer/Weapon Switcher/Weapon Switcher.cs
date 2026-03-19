
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class WeaponSwitcher : MonoBehaviour
{
    [Header("Guns")]
    public GameObject AR;
    public GameObject Pistol;
    public GameObject Shotgun;

    [Header("UI")]
    public GameObject GroupedUI;
    public Button AR_Toggle;
    public Button Pistol_Toggle;
    public Button Shotgun_Toggle;
    public Image Background;

    public GameObject CustomGunGroup;
    public Button CustomGunButton;
    public Image CustomGunBackground;

    //[Header("Settings")]
    //public KeyCode SettingsAppear;

    // Start is called before the first frame update
    void Start()
    {
        GroupedUI.SetActive(false);
    }

    void Update()
    {
        //if (Input.GetKey(SettingsAppear))
        //{
        //    UnityEngine.Cursor.lockState = CursorLockMode.None;
        //    UnityEngine.Cursor.visible = true;
        //    Time.timeScale = 0f;
        //    GroupedUI.SetActive(true);

        //}
        //if (AR_Toggle.isOn)
        //{
        //    ARAppear();
        //    PistolDissapear();
        //    ShotgunDissapear();

        //}

        //if (Pistol_Toggle.isOn)
        //{
        //    PistolAppear();
        //}

        //if (Shotgun_Toggle.isOn)
        //{
        //    ARDissapear();
        //    PistolDissapear();
        //    ShotgunAppear();

        //}
        //if (Input.GetKey(KeyCode.Escape))
        //{
        //    GroupedUI.SetActive(false);
        //    CustomGunGroup.SetActive(false);
        //    UnityEngine.Cursor.lockState = CursorLockMode.Locked;
        //    UnityEngine.Cursor.visible = false;
        //    Time.timeScale = 1f;
        //}

    }

    public void ARAppear()
    {
        AR.SetActive(true);
    }

    public void PistolAppear()
    {
        Pistol.SetActive(true);
    }

    public void ShotgunAppear()
    {
        Shotgun.SetActive(true);
    }

    public void ARDissapear()
    {
        AR.SetActive(false);
    }

    public void PistolDissapear()
    {
        Pistol.SetActive(false);
    }

    public void ShotgunDissapear()
    {
        Pistol.SetActive(false);
    }

    public void CustomGunOnClick()
    {
        CustomGunGroup.SetActive(true);
    }
}
