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

    public bool flipAxis;

    private TestSocketIO angleReceiver;

    // create variable to hold reference
    private Rigidbody rb;

    private int score;
    private float previousZ, previousX, angleX;

    private float timeCount = 0.5f;

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
        if (flipAxis)
        {
            angles = new Vector3(Convert.ToSingle(angleReceiver.gamma), 0, 0);
            Quaternion newRot = Quaternion.Euler(0, 2*Convert.ToSingle(angleReceiver.gamma), 0);
            transform.rotation = newRot;

        }
        else
        {
            if (timeCount < 0.5f)
            {
                angles = new Vector3(Convert.ToSingle(angleReceiver.beta), 0, 0);
                Quaternion oldRot = transform.rotation;
                Quaternion newRot = Quaternion.Euler(0, 2 * Convert.ToSingle(angleReceiver.beta), 0);
                transform.rotation = Quaternion.Slerp(oldRot, newRot, timeCount);
                timeCount = timeCount + Time.deltaTime;
            }
            else
            {
                timeCount = 0f;
            }

        }

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
