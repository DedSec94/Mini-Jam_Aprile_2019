﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_PlayerMove : MonoBehaviour
{
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0 , 0, Time.deltaTime * speed);
    }
}
