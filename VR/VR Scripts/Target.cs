using System;
using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] private Transform Pivot;
    [SerializeField] private GameObject Button;
    private void OnCollisionEnter(Collision collision)
    {
        Pivot.transform.Rotate(0, 0, -90);

        if(collision.gameObject == Button)
        {
            Pivot.transform.Rotate(0, 0, 0);
        }
    }
}
