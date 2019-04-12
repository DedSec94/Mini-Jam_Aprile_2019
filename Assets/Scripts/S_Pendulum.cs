using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Pendulum : MonoBehaviour
{
    private float zPosition;
    public float xPosition;
    public float secondX;
    public float secondy;
    public float secondz;
    // Start is called before the first frame update
    void Start()
    {
        zPosition = transform.position.z;
        Vector3 firstPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        /*
        //lock x
        if (transform.position.x < -xPosition)
            transform.position = new Vector3(-xPosition, transform.position.y, transform.position.z);
        if (transform.position.x > xPosition)
            transform.position = new Vector3(xPosition, transform.position.y, transform.position.z);
        //lock z
        if (transform.position.z < zPosition)
            transform.position = new Vector3(transform.position.x, transform.position.y, zPosition);
        if (transform.position.z > zPosition)
            transform.position = new Vector3(transform.position.x, transform.position.y, zPosition);*/
       
        
        Vector3 secondPosition = new Vector3(secondX, secondy, secondz);
        while (transform.position.x < secondX)
        {
            transform.position = new Vector3(transform.position.x + 0.001f, transform.position.y, transform.position.z);
        }
    }
}
