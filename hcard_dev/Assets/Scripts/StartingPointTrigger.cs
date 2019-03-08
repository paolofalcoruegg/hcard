using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartingPointTrigger : MonoBehaviour
{

    public GameObject LapCompleteTrig;
    public GameObject StartLapTrig;

    void OnTriggerEnter()
    {
        LapCompleteTrig.SetActive(true);
        StartLapTrig.SetActive(false);
    }
}