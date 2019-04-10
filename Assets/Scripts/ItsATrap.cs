﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItsATrap : MonoBehaviour
{
    public GameObject m_trap;
    public float distance;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            m_trap.transform.position = new Vector3(m_trap.transform.position.x, m_trap.transform.position.y - distance, m_trap.transform.position.z);
            m_trap.GetComponent<BoxCollider>().isTrigger = true;
        }
    }
}
