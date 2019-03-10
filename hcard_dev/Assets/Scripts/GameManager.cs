using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject completeLevelUI;
    public GameObject basicUI;

   public void CompleteLevel()
    {
        Debug.Log("Level Won");
        completeLevelUI.SetActive(true);
        basicUI.SetActive(false);
    }
}
