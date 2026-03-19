using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TargetSystem : MonoBehaviour
{
    
    public float health = 100f;
    public GameObject Enemy;

    bool isPlaying;

    public int TotalEnemies;
    int NumofEnemies;
    int TotalEnemiesKilled;
    void Update()
    {
       
    }
    //EnemySpawner Spawner;
    //ImageColorChanger KCC;

    public void TakeDamage(float damage)
    {
        health -= damage;

        if (health <= 0f)
        {
           
            Die();
            
        }


    }

    void Die()
    {
       Destroy(Enemy);
       NumofEnemies = NumofEnemies + 1;
       TotalEnemiesKilled++;

    }

    

}
