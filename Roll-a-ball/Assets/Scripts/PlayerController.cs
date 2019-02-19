using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    // private = no access in controller (just in script), whereas public can be changed in controller
    public float speed;
    public double alpha;
    public double beta;
    public double gamma;

    // create variable to hold reference
    private Rigidbody rb;

    // used to count number of points
    private int count;
    public Text countText;
    public Text winText;

    //runs at first script run
    void Start ()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winText.text = "";
    }
    
    //void Update() //called before rendering a frame - most game code here
    //{
    //not needed here as we are dealing with the physics of the ball
    //}

    private void FixedUpdate() //called before performing any calculations
    {
        //old controls:
        //float moveHorizontal = Input.GetAxis("Horizontal");
        //float moveVertical = Input.GetAxis("Vertical");
        //Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);
        
        Vector3 angles = new Vector3(Convert.ToSingle(Math.Sin(alpha)), Convert.ToSingle(Math.Sin(beta)), Convert.ToSingle(Math.Sin(gamma)));

        //using default force mode - to not do this, look at the documentation for Rigidbody.AddForce
        rb.AddForce(angles * speed);

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            //deactivate game object when the object we collided with is a pick up
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        }

        if (other.gameObject.CompareTag("Danger"))
        {
            rb.gameObject.SetActive(false);
            winText.text = "YOU LOSE!";
        }
    }

    void SetCountText()
    {
        countText.text = "Count:" + count.ToString();
        if (count >= 10)
        {
            winText.text = "YOU WIN!";
        }
    }
    
}
    
 