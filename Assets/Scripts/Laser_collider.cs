using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser_collider : MonoBehaviour
{
    private AudioSource audioSource;
    private AudioClip electric;

    void Awake ()
    {
        audioSource = GetComponent<AudioSource>();
    }

    
    void OnTriggerEnter (Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            audioSource.Play();
        }
    }
}
