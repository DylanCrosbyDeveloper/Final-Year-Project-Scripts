using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHeath : MonoBehaviour
{
    public float playerHealth = 100f;
    float stopTime;
    public Slider HealthBar;
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Projectile")
        {
            playerHealth = playerHealth - 10;
            HealthBar.value = playerHealth;
        }
    }

    void Start()
    {
        stopTime = Time.deltaTime; 
        
    }
    void Update()
    {

        if (playerHealth <= 0) 
        {
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    public void AddHealth(float amount)
    {
        playerHealth = playerHealth + amount;
        HealthBar.value = playerHealth;
    }
}
