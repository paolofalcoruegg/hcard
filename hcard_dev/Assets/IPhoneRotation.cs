using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IPhoneRotation : MonoBehaviour
{
    private TestSocketIO angleReceiver;
    private Quaternion rotation;
    public Transform iphone;

    // Start is called before the first frame update
    void Start()
    {
        angleReceiver = GetComponent<TestSocketIO>();
    }

    // Update is called once per frame
    void Update()
    {
        rotation = Quaternion.Euler(angleReceiver.beta, angleReceiver.gamma, angleReceiver.alpha);
        iphone.rotation = rotation;
    }
}
