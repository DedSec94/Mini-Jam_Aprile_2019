using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DMovablePlatform : MonoBehaviour
{
    public GameObject opponent;
    public GameObject opponentToMove;
    public float distance;
    Transform camTransform;
    public float distbetween;

    void Start()
    {
        camTransform = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Transform>();
        distance = camTransform.position.y - transform.position.y;
        opponentToMove = null;
    }

    void Update()
    {
        if (opponentToMove == opponent)
        {
            opponentToMove.transform.position = new Vector3(-transform.position.x, opponentToMove.transform.position.y, opponentToMove.transform.position.z);
        }
    }

    void OnMouseDrag()
    {
        Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance);
        Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        transform.position = objPosition;
    }
    void OnMouseDown()
    {
        opponentToMove = opponent;
    }
    void OnMouseUp()
    {
        opponentToMove = null;
    }
}
