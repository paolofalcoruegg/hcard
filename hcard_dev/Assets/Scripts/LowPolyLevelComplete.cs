using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LowPolyLevelComplete : MonoBehaviour
{
    public void LoadNextLevel() => SceneManager.LoadScene(sceneBuildIndex: SceneManager.GetActiveScene().buildIndex - 2);
}
