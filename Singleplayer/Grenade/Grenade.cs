using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    public float delay = 3f;
    public float radius = 5f;
    public float force = 700f;

    public float damage = 80f;

    public GameObject grenadePrefab;   
    public GameObject PickupPrefab;

    public float MaxGrenadeHolder = 3;
    public float GrenadesHeld = 3;

    float countdown;
    bool hasExploded = false;

    float Despawntime = 5f;

   

    public GameObject explosionEffect;
    void Start()
    {
        countdown = delay;
    }


    void Update()
    {
        countdown -= Time.deltaTime;

        if(countdown <= 0 && !hasExploded)
        {
            Explode();
            hasExploded = true;
            Despawntime -= Time.deltaTime;

            if (Despawntime < 0)
            {
                Destroy(explosionEffect);
            }
        }
       


    }

    void Explode()
    {
        Instantiate(explosionEffect, transform.position, transform.rotation);

        


        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);

        foreach(Collider nearbyObject in colliders) 
        {
            Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
            if(rb != null)
            {
                rb.AddExplosionForce(force, transform.position, radius);

                
            }

            if (nearbyObject.gameObject.GetComponent<TargetSystem>() != null) 
            {
                TargetSystem enemy = nearbyObject.gameObject.GetComponent<TargetSystem>();
                enemy.TakeDamage(damage);
            }
        }

        Destroy(gameObject);
    }

    
}
