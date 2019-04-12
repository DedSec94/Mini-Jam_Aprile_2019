using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlternateWall : MonoBehaviour
{
    public GameObject Altro;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseDown()
    {
        Altro.SetActive(true);
        //Altro.GetComponent<Renderer>().material.color = Color.yellow;

        gameObject.SetActive(false);
        //gameObject.GetComponent<Renderer>().material.color = Color.red;
    }
}
