using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsFinish : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(CreditEnd());
    }
    IEnumerator CreditEnd()
    {
        yield return new WaitForSeconds(20);
        SceneManager.LoadScene(0);
    }
}
