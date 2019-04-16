using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MovablePlatform))]
public class DMovablePlatform : MonoBehaviour
{
    public GameObject opponent;
    public GameObject opponentToMove;

    void Awake ()
    {
        opponentToMove = null;
    }
    void Update()
    {
        if (opponentToMove == opponent)
        {
            opponentToMove.transform.position = new Vector3(-transform.position.x, opponentToMove.transform.position.y, opponentToMove.transform.position.z);
        }
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
