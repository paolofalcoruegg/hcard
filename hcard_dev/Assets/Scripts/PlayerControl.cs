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

    public Text scoreText;

    private TestSocketIO angleReceiver;

    // create variable to hold reference
    private Rigidbody rb;

    private int score;
    private float previousZ, previousX, angleX;


    // angles
    public Vector3 angles;

    //runs at first script run
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        angleReceiver = GetComponent<TestSocketIO>();

        score = 0;
        SetCountText();

        // initial transform to calculate angle of ball
        previousX = transform.position.x;
        previousZ = transform.position.z;

    }

    private void FixedUpdate() //called before performing any calculations
    {

        // Moving sideways controls sideways motion
        angles = new Vector3(Convert.ToSingle(angleReceiver.beta), 0, 0);

        // Give it a baseSpeed towards the front
        rb.velocity = new Vector3(0, 0, baseSpeed);

        // Adding force depending on mapping and body angle
        rb.AddForce(angles * speed/10,ForceMode.VelocityChange);

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            //deactivate game object when the object we collided with is a pick up
            other.gameObject.SetActive(false);
            score += 25;
            SetCountText();
        }

    }

    void SetCountText()
    {
        scoreText.text = "Score: " + score.ToString();
    }
}
