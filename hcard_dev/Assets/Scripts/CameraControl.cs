using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{

    public GameObject player;

    //private as can set here in script
    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 start_pos = new Vector3(0, 10, -255);
        transform.position = start_pos;
        offset = transform.position - player.transform.position;
    }

    // LateUpdate is called once per frame if have moved
    void LateUpdate()
    {
        transform.position = player.transform.position + offset;
    }
}

