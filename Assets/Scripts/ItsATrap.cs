using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItsATrap : MonoBehaviour
{
    public GameObject m_trap;
    public float distance;

    private AudioSource audioSource;
    public AudioClip plate;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            m_trap.transform.position = new Vector3(m_trap.transform.position.x, m_trap.transform.position.y - distance, m_trap.transform.position.z);
            m_trap.GetComponent<BoxCollider>().isTrigger = true;
            audioSource.PlayOneShot(audioSource.clip);
        }
    }
}
