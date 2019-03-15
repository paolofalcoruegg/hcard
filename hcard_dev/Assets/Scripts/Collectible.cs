using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Collectible : MonoBehaviour
{
    private void OnTriggerEnter()
    {
      AudioSource source = GetComponent<AudioSource>();
      source.Play();
    }

}
