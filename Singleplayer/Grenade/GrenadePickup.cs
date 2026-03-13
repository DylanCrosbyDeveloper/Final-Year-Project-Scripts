using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
public class GrenadePickup : MonoBehaviour
{
    
       
    public GameObject PickupPrefab;
    public GameObject Player;
    public float MaxGrenadeHolder = 3;
    public float GrenadesHeld = 3;
    public float distanceThreshold = 2f;
    float Distance;
    public GameObject Item;
    

    [Header("UI")]
    public TextMeshProUGUI GrenadeUI;

    void Start()
    {
        if (Player != null)
            Player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
       
    }
           

    

    void Pickup()
    {
        
    }

}
