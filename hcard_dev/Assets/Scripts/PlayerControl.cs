using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class PlayerControl : MonoBehaviour
{
    // private = no access in controller (just in script), whereas public can be changed in controller
    public float speed;
    public float baseSpeed;

    public Text countText;
    public Text winText;
    public Text angleText;

    private TestSocketIO angleReceiver;

    // create variable to hold reference
    private Rigidbody rb;

    private int count;
    private float previousZ, previousX, angleX;


    // angles
    public Vector3 angles;

    //runs at first script run
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        angleReceiver = GetComponent<TestSocketIO>();

        count = 0;
        SetCountText();

        winText.text = "";

        // initial transform to calculate angle of ball
        previousX = transform.position.x;
        previousZ = transform.position.z;

    }

    private void FixedUpdate() //called before performing any calculations
    {
        // move forwards without leaning but speed up by leaning
        angles = new Vector3(Convert.ToSingle(angleReceiver.beta), 0, Convert.ToSingle(angleReceiver.gamma));

        // Give it a baseSpeed towards the front
        rb.velocity = new Vector3(0, 0, baseSpeed);

        //using default force mode - to not do this, look at the documentation for Rigidbody.AddForce
        rb.AddForce((angles * speed),ForceMode.VelocityChange);

        angleX = Mathf.Atan2(transform.position.z - previousZ, transform.position.x - previousX);
        angleText.text = (angleX * 180 / Mathf.PI - 90).ToString();

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            //deactivate game object when the object we collided with is a pick up
            other.gameObject.SetActive(false);
            count += 1;
            SetCountText();
        }

    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= 12)
        {
            winText.text = "You've fucking done it! Well done, biiitch xx";
        }
    }
}
