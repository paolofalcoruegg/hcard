using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour
{
    // private = no access in controller (just in script), whereas public can be changed in controller
    public float speed;
    public float baseSpeed;

    private TestSocketIO angleReceiver;

    // create variable to hold reference
    private Rigidbody rb;


    //runs at first script run
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        angleReceiver = GetComponent<TestSocketIO>();

    }

    private void FixedUpdate() //called before performing any calculations
    {
        
        // have to lean forwards to move forwards
        Vector3 angles1 = new Vector3(Convert.ToSingle(angleReceiver.beta-180), 0, Convert.ToSingle(angleReceiver.gamma-90));

        // move forwards without leaning but speed up by leaning
        Vector3 angles2 = new Vector3(Convert.ToSingle(angleReceiver.beta), 0, Convert.ToSingle(angleReceiver.gamma));

        // Give it a baseSpeed towards the front
        rb.velocity += new Vector3(0, 0, baseSpeed);

        //using default force mode - to not do this, look at the documentation for Rigidbody.AddForce
        rb.AddForce(angles2 * speed);

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            //deactivate game object when the object we collided with is a pick up
            other.gameObject.SetActive(false);
         
        }

    }


}
