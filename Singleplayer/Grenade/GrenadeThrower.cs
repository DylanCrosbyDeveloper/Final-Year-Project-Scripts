
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class GrenadeThrower : MonoBehaviour
{
    public GameObject grenadePrefab;
    public float MaxGrenadeHolder = 3;
    public float GrenadesHeld = 3;
    
    public float throwForce = 40f;
    public Transform AttackPoint;

    public TextMeshProUGUI GrenadeUI;
    public Camera PlayerCamera;
    void Update()
    {
       
        if (Input.GetKeyDown(KeyCode.E))
        {
            RaycastHit hit;
            Ray ray = PlayerCamera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                CapsuleCollider CapCol = hit.collider as CapsuleCollider;
                if (Input.GetKeyDown(KeyCode.Q) && hit.collider as CapsuleCollider)
                {
                    //Destroy(CapCol.gameObject);
                    CapCol.gameObject.SetActive(false);
                    Debug.Log(GrenadesHeld);
                    GrenadesHeld = GrenadesHeld + 1;


                    if (GrenadesHeld > MaxGrenadeHolder)
                    {
                        GrenadesHeld = MaxGrenadeHolder;
                    }
                }

            }

            

        }
        if (Input.GetKeyDown(KeyCode.Q) && MaxGrenadeHolder != 0 && GrenadesHeld != 0)
        {
            ThrowGrenade();


            Debug.Log(MaxGrenadeHolder);
            Debug.Log(GrenadesHeld);
        }
        GrenadeUI.SetText(GrenadesHeld.ToString() + "/" + MaxGrenadeHolder);
    }

    void ThrowGrenade()
    {

        GameObject grenade = Instantiate(grenadePrefab, AttackPoint.position, AttackPoint.rotation);
        Rigidbody rb = grenade.GetComponent<Rigidbody>();
        GrenadesHeld -= 1;
        rb.AddForce(AttackPoint.forward * throwForce, ForceMode.VelocityChange);

        //if (GrenadesHeld <= 0)
        //{
        //    GrenadesHeld += 0;
        //}
    }
}
