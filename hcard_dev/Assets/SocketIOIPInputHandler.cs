using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SocketIOIPInputHandler : MonoBehaviour
{

    InputField inputField;

    // Start is called before the first frame update
    void Start()
    {
        inputField = GetComponent<InputField>();
    }

    public void SetSocketIOIP()
    {
        SocketIOIP.socketIOIP = inputField.text;
        Debug.Log(SocketIOIP.socketIOIP);
        Destroy(gameObject);
    }
}
