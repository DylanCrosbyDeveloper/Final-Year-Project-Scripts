using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Microsoft.Win32.SafeHandles;
using Unity.VisualScripting;

public class PercentageShots : MonoBehaviour
{
    public Camera PlayerCamera;
    float StartPercHit, StartPercMiss;
    float Ratio;
    public TextMeshProUGUI RatioText;
    public GameObject Target;

    float HighScoreRatio;


    float zero = 0;

    int bulletsLeft;

    void Start()
    {
        HighScoreRatio = PlayerPrefs.GetFloat("RatioHighScore");
        StartPercHit = 1;
        StartPercMiss = 1;
    }
    public void Update()
    {

        RaycastHit hit;
        Ray ray = PlayerCamera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {

            MeshCollider mc = hit.collider as MeshCollider;

            Ratio = StartPercMiss / StartPercHit;

            if (Ratio > HighScoreRatio)
            {
                PlayerPrefs.SetFloat("RatioHighScore", Ratio);
                RatioText.text = "New Highscore Ratio!: " + Ratio.ToString();
            }
            if (Ratio < HighScoreRatio)
            {
                PlayerPrefs.GetFloat("RatioHighScore");
                RatioText.text = "Highscore Ratio: " + HighScoreRatio.ToString();
            }

        }

        
    }

    private void FixedUpdate()
    {

       

    }

    public void Hitshot(float  HitShot)
    {   
            StartPercHit = StartPercHit + HitShot;
    }
    public void Missshot(float MissShot)
    {
        StartPercMiss = StartPercMiss - MissShot;

       
    }

    public void ESRatioEQ()
    {
        
    }
}

