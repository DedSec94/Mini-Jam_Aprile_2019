using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    public Transform door;

    public ParticleSystem smoke;
    private AudioSource audioSource;
    public AudioClip button;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        smoke = GetComponentInChildren<ParticleSystem>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            door.GetChild(2).transform.position = new Vector3(door.GetChild(2).transform.position.x, -1, door.GetChild(2).transform.position.z);
            smoke.Play();
            audioSource.PlayOneShot(audioSource.clip);
        }
    }
}
