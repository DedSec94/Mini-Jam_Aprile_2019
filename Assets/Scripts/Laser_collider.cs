using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser_collider : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip electric;

    void Awake ()
    {
        audioSource = GetComponent<AudioSource>();
    }

    
    void OnTriggerEnter (Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            audioSource.PlayOneShot(electric);
        }
    }
}
