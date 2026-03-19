using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupRespawner : MonoBehaviour
{
    public GameObject SpawnPoint;
    public GameObject Item;

    void Update()
    {
        if(Item.activeInHierarchy == false)
        {
            Invoke("Action", 25);
            Debug.Log("WORKING");
        }
    }

    private void Action()
    {
        Item.SetActive(true);
    }
}
