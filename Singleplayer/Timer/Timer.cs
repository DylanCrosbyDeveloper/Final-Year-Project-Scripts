using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using Unity.VisualScripting;

public class Timer : MonoBehaviour
{
    [SerializeField] GameObject timer;
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] TextMeshProUGUI EndScreenTimerText;
    [SerializeField] float remainingTime;
    [SerializeField] bool stop;
    [SerializeField] UnityEvent Enter;
    [SerializeField] public Camera PlayerCamera;
    [SerializeField] public GameObject Barrier;

    int Previousremainingtime;


    

    [SerializeField] GameObject GameStarter;
    bool Hit;

    void Start()
    {
        timer.SetActive(true);
        Time.timeScale = 1.0f;

    }
    public void FixedUpdate()
    {
        
        if (Hit == true)
        {
            timer.SetActive(true);
            Countdown(false);
        }
        //if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
        //{

        

        //}
        RaycastHit hit;
        Ray ray = PlayerCamera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            
            BoxCollider bc = hit.collider as BoxCollider;

            if (Input.GetMouseButtonDown(0) && hit.collider as BoxCollider && hit.collider.tag == "StartTimer")
            {
                Hit = true;
                Countdown(true);
                Destroy(Barrier);
            }
            if (Input.GetMouseButtonDown(0) && hit.collider as BoxCollider && hit.collider.tag == "StopTimer")
            {
                Hit = true;     
            }

            Debug.Log(remainingTime);
        }

        
        



    }

    public void Countdown(bool Stop)
    {

        
        if (Hit == true)
        {
            GameStarter.SetActive(false);
            if (stop == false)
            {
                if (remainingTime > 0)
                {
                    remainingTime -= Time.deltaTime;

                }
                else if (remainingTime < 0)
                {
                    remainingTime = 0;
                }

                if (stop == true)
                {
                    remainingTime = remainingTime + 0;
                }

                if (remainingTime < 0)
                {
                    StopTimer();
                }


                TimerConverter();




            }
        }
        

        
    }
    public void StopTimer()
    {
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    void TimerConverter()
    {
        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        EndScreenTimerText.text = "Time Taken: " + string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
    
    
    
    

    
