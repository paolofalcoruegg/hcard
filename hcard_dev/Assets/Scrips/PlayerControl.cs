using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour
{
    // private = no access in controller (just in script), whereas public can be changed in controller
    public float speed;
    private TestSocketIO angleReceiver;

    // create variable to hold reference
    private Rigidbody rb;


    //runs at first script run
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate() //called before performing any calculations
    {
        Vector3 angles = new Vector3(Convert.ToSingle(Math.Sin(angleReceiver.alpha)), Convert.ToSingle(Math.Sin(angleReceiver.beta)), Convert.ToSingle(Math.Sin(angleReceiver.gamma)));

        //using default force mode - to not do this, look at the documentation for Rigidbody.AddForce
        rb.AddForce(angles * speed);

    }

    
}
