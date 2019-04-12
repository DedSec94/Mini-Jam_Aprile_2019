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
        //Altro.SetActive(true);
        //Altro.GetComponent<Renderer>().material.color = Color.yellow;
        for(int i = 0; i < Altro.transform.childCount; i++)
        {
            Transform child = Altro.transform.GetChild(i); //Gets the current child
            Renderer childRenderer = child.GetComponent<Renderer>(); //Get the renderer
            childRenderer.material.color = Color.green; //Set the color

            child.GetComponent<Collider>().isTrigger = true; //Activate the trigger making them like the Box collider is disabled


        }


        //gameObject.SetActive(false);
        //gameObject.GetComponent<Renderer>().material.color = Color.red;
        for (int i = 0; i < transform.childCount; i++)
        {
            Transform child = transform.GetChild(i); //Gets the current child
            Renderer childRenderer = child.GetComponent<Renderer>(); //Get the renderer
            childRenderer.material.color = Color.red; //Set the color

            child.GetComponent<Collider>().isTrigger = false; //Deactivate the trigger making them like the Box collider is disabled
        }

    }
}
