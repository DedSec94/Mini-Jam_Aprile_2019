using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanceObject : MonoBehaviour
{
    public GameObject game;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var mousePos = Input.mousePosition;
        mousePos.z = 19.5f;
        var objectPos = Camera.main.ScreenToWorldPoint(mousePos);


        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Instantiate(game, objectPos, Quaternion.identity);
        }
    }
}
