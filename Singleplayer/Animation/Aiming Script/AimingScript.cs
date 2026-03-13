using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimingScript : MonoBehaviour
{
    public GameObject Gun;

    public bool isAiming;
    public bool isReloading = false;
    public bool isRecoiling = false;
    bool useAnimPhys = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetMouseButtonDown(1))
        {
            Gun.GetComponent<Animator>().Play("Aim");
            isAiming = true;
        }
        if (Input.GetMouseButtonUp(1))
        {
            Gun.GetComponent<Animator>().Play("New State");
            isAiming = false;
        }
        if (Input.GetKey(KeyCode.I))
        {
            Gun.GetComponent<Animator>().Play("Inspect");

            
            
            
        }
        if (Input.GetKey(KeyCode.R))
        {

            if (isReloading)
            {
                Gun.GetComponent<Animator>().animatePhysics = false;
                Gun.GetComponent<Animator>().Play("Reload");
                isReloading = false;
            }
            
            isReloading = false;
        
        }
        if (Input.GetMouseButtonDown(0))
        {
            Gun.GetComponent<Animator>().Play("Recoil");
            if (isRecoiling)
            {
                Gun.GetComponent<Animator>().Play("Reload");
                isRecoiling = false;
            }
        }

    }

}
