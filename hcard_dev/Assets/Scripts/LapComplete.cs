using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LapComplete : MonoBehaviour
{

    public GameObject LapCompleteTrig;
    public GameObject StartLapTrig;
    public GameManager gameManager;

    void OnTriggerEnter()
    {
        StartLapTrig.SetActive(true);
        LapCompleteTrig.SetActive(false);

        gameManager.CompleteLevel();
    }

}