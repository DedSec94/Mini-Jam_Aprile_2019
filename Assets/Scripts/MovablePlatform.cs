using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovablePlatform : MonoBehaviour
{
    private Vector3 mOffset;
    private float mZCoord;
    private float zPosition;
    public float xPosition;
    void Start()
    {
        zPosition = transform.position.z;
    }
    void Update()
    {
        //lock x
        if (transform.position.x < -xPosition)
            transform.position = new Vector3(-xPosition, transform.position.y, transform.position.z);
        if (transform.position.x > xPosition)
            transform.position = new Vector3(xPosition, transform.position.y, transform.position.z);
        //lock z
        if (transform.position.z < zPosition)
            transform.position = new Vector3(transform.position.x, transform.position.y, zPosition);
        if (transform.position.z > zPosition)
            transform.position = new Vector3(transform.position.x, transform.position.y, zPosition);
    }


    void OnMouseDown()
    {
        mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        mOffset = gameObject.transform.position - GetMouseWorldPos();

    }
    private Vector3 GetMouseWorldPos()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = mZCoord;
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }


    void OnMouseDrag()
    {
        transform.position = GetMouseWorldPos() + mOffset;
    }
}