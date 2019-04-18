﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public enum TypeOfPlayer
{
    PLAYER_ONE,
    PLAYER_TWO
}

public class PlayerManager : MonoBehaviour
{
    #region PUBLIC
    public TypeOfPlayer type;
    [Space]
    public InputSO inputSO;
    [Space]
    public Material[] materials;
    [Space]
    public float speed;
    [Space]
    public float jumpSpeed;
    [Header("Set true if u want to change floats")]
    public bool editableRange;
    [Space]
    public ParticleSystem dust;
    [Space]
    public bool notMove;
    [Space]
    public CameraShake cameraShake;
    #endregion

    #region PRIVATE
    float recSpeed;
    MeshRenderer meshRenderer;
    Rigidbody m_rigidBody;
    bool onGround;
    #endregion

    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        m_rigidBody = GetComponent<Rigidbody>();
        dust = GetComponentInChildren<ParticleSystem>();
        recSpeed = speed;
        cameraShake = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraShake>();


        StartCoroutine(FSM());

        if (type == TypeOfPlayer.PLAYER_ONE)
        {
            m_rigidBody.constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ;
        }
        else if (type == TypeOfPlayer.PLAYER_TWO)
        {
            m_rigidBody.constraints = RigidbodyConstraints.FreezeAll;
        }
    }

    void Update()
    {
        AutoMove(speed);

        if (Input.GetKeyDown(inputSO.exitKey))
        {
            SceneManager.LoadScene(0);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        onGround = true;

        if (collision.gameObject.tag == "DoublePlat")
        {
            StartCoroutine(cameraShake.Shake(cameraShake.gameObject.GetComponent<MultipleTargetCamera>().duration, cameraShake.gameObject.GetComponent<MultipleTargetCamera>().magnitude));
            //StartCoroutine(cameraShake.Shake(.15f, .4f));
            notMove = true;
            dust.Play();
        }
        if (collision.gameObject.tag == "MP")
        {
            StartCoroutine(cameraShake.Shake(cameraShake.gameObject.GetComponent<MultipleTargetCamera>().duration, cameraShake.gameObject.GetComponent<MultipleTargetCamera>().magnitude));
            //StartCoroutine(cameraShake.Shake(.15f, .4f));
            notMove = true;
            dust.Play();
        }
        if (collision.gameObject.tag == "BlackWall")
        {
            StartCoroutine(cameraShake.Shake(cameraShake.gameObject.GetComponent<MultipleTargetCamera>().duration, cameraShake.gameObject.GetComponent<MultipleTargetCamera>().magnitude));
            //StartCoroutine(cameraShake.Shake(.15f, .4f));
            notMove = true;
            dust.Play();
        }

        if (collision.gameObject.tag == "Trap")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Laser")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "DoublePlat")
        {
            notMove = true;
        }
        if (collision.gameObject.tag == "MP")
        {
            notMove = true;
        }
        if (collision.gameObject.tag == "BlackWall")
        {
            notMove = true;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "DoublePlat")
        {
            StopCoroutine(cameraShake.Shake(cameraShake.gameObject.GetComponent<MultipleTargetCamera>().duration, cameraShake.gameObject.GetComponent<MultipleTargetCamera>().magnitude));
            notMove = false;
        }
        if (collision.gameObject.tag == "MP")
        {
            StopCoroutine(cameraShake.Shake(cameraShake.gameObject.GetComponent<MultipleTargetCamera>().duration, cameraShake.gameObject.GetComponent<MultipleTargetCamera>().magnitude));
            notMove = false;
        }
        if (collision.gameObject.tag == "BlackWall")
        {
            StopCoroutine(cameraShake.Shake(cameraShake.gameObject.GetComponent<MultipleTargetCamera>().duration, cameraShake.gameObject.GetComponent<MultipleTargetCamera>().magnitude));
            notMove = false;
        }
    }

    void PlayerOneStatistics()
    {
        if (!editableRange)
        {
            speed = 8f;
            jumpSpeed = 10f;
        }
        meshRenderer.material = materials[0];
    }

    void PlayerTwoStatistics()
    {
        if (!editableRange)
        {
            speed = 4f;
        }
        meshRenderer.material = materials[1];
    }

    void AutoMove(float i)
    {
        if (!notMove)
        {
            transform.position += new Vector3(0, 0,i * Time.deltaTime);
            i = recSpeed;
        }
        else
        {
            i = 0f;
        }

    }

    void Jumping(float i)
    {
        if (Input.GetKeyDown(inputSO.jumpKey) && onGround)
        {
            m_rigidBody.AddForce(Vector3.up * i, ForceMode.Impulse);
            onGround = false;
        }
    }

    IEnumerator FSM()
    {
        while(true)
        {
            switch(type)
            {
                case TypeOfPlayer.PLAYER_ONE:
                    PlayerOneStatistics();
                    Jumping(jumpSpeed);
                    break;
                case TypeOfPlayer.PLAYER_TWO:
                    PlayerTwoStatistics();
                    break;
            }
            yield return null;
        }
    }
}
