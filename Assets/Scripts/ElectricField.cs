using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricField : MonoBehaviour
{

    public GameObject[] ElectricFieldsA;
    public GameObject[] ElectricFieldsB;

    public bool right = false;

    // Start is called before the first frame update
    void Start()
    {
        //Find All electric fields on the A side and put them on a List
        ElectricFieldsA = GameObject.FindGameObjectsWithTag("ElectricFieldA");

        //Find All electric fields on the B side and put them on a List
        ElectricFieldsB = GameObject.FindGameObjectsWithTag("ElectricFieldB");

        for (int i = 0; i < ElectricFieldsA.Length; i++)
        {
            Debug.Log("im changing color for B side");
            ElectricFieldsB[i].GetComponent<Renderer>().material.color = Color.red;
            //ElectricFieldsB[i].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void OnMouseDown()
    {
        //GetComponent<Renderer>().material.color = Color.red;

        // if false set ON->A and OFF->B
        if (right)
        {
            //Iterate trough the B list and changhe the color for everyone of them
            //    //And set them on "ON = Yellow"
            for (int i = 0; i < ElectricFieldsB.Length; i++)
            {
                //Debug.Log("im changing color for B side");
                ElectricFieldsB[i].GetComponent<Renderer>().material.color = Color.yellow;
                ElectricFieldsA[i].GetComponent<Renderer>().material.color = Color.red;
                //ElectricFieldsB[i].SetActive(true);

            }

            //then set me on "OFF = Red" means change all of A
            //for (int i = 0; i < ElectricFieldsA.Length; i++)
            {
                //Debug.Log("im changing color for A side");
                //ElectricFieldsA[i].SetActive(false);
            }
            right = false;

        }
        else
        {
            //Iterate trough the A list and changhe the color for everyone of them
            //And set them on "ON = Yellow"
            for (int i = 0; i < ElectricFieldsB.Length; i++)
            {
                //Debug.Log("im changing color for A side");
                ElectricFieldsA[i].GetComponent<Renderer>().material.color = Color.yellow;
                ElectricFieldsB[i].GetComponent<Renderer>().material.color = Color.red;
                //ElectricFieldsA[i].SetActive(true);
            }

            //then set me on "OFF = Red" means change all of A
            //for (int i = 0; i < ElectricFieldsA.Length; i++)
            {
                //Debug.Log("im changing color for B side");
                //ElectricFieldsB[i].SetActive(false);
            }

            right = true;
        }


        // Im part of A list
        //if(gameObject.tag == "ElectricFieldA")
        //{
        //    //Iterate trough the B list and changhe the color for everyone of them
        //    //And set them on "ON = Yellow"
        //    for (int i = 0; i < ElectricFieldsB.Length; i++)
        //    {
        //        Debug.Log("im changing color for B side");
        //        ElectricFieldsB[i].GetComponent<Renderer>().material.color = Color.yellow;

        //    }

        //    //then set me on "OFF = Red" means change all of A
        //    for (int i = 0; i < ElectricFieldsA.Length; i++)
        //    {
        //        Debug.Log("im changing color for A side");
        //        ElectricFieldsA[i].GetComponent<Renderer>().material.color = Color.red;

        //    }
        //}

        //// Im part of B list
        //if (gameObject.tag == "ElectricFieldB")
        //{
        //    //Iterate trough the A list and changhe the color for everyone of them
        //    //And set them on "ON = Yellow"
        //    for (int i = 0; i < ElectricFieldsB.Length; i++)
        //    {
        //        Debug.Log("im changing color for A side");
        //        ElectricFieldsA[i].GetComponent<Renderer>().material.color = Color.yellow;

        //    }

        //    //then set me on "OFF = Red" means change all of A
        //    for (int i = 0; i < ElectricFieldsA.Length; i++)
        //    {
        //        Debug.Log("im changing color for B side");
        //        ElectricFieldsB[i].GetComponent<Renderer>().material.color = Color.red;

        //    }
        //}


    }


}
