﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    public float delay = 3f;
    float countdown;
    bool hasExploded = false;
    public GameObject explosionEffect;
    public float radius = 5f;
    public float force = 700f;

	// Use this for initialization
	void Start ()
    {
        //countdown = delay;
       
    }
	
	// Update is called once per frame
	void Update ()
    {
        countdown -= Time.deltaTime;
        if (countdown <= 0f && !hasExploded)
        {
            Explode();
            hasExploded = true;
          

        }


	}

    void Explode()
    {
        Debug.Log("BOOM");

        // Show effect
        Instantiate(explosionEffect, transform.position, transform.rotation);
        

        //AOE
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);

        foreach(Collider nearbyObject in colliders)
        {
            Rigidbody rb =  nearbyObject.GetComponent<Rigidbody>();
            if (rb != null)
                rb.AddExplosionForce(force,transform.position, radius);
        }
        //Remove 
        Destroy(gameObject);
        //explosionEffect.active = false;
        
    }
}
