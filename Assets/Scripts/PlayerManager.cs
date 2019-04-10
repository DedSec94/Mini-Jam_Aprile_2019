using System.Collections;
using System.Collections.Generic;
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
    #endregion

    #region PRIVATE
    float recSpeed;
    MeshRenderer meshRenderer;
    Rigidbody m_rigidBody;
    bool onGround, notMove;
    #endregion

    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        m_rigidBody = GetComponent<Rigidbody>();
        recSpeed = speed;
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
        AutoMove();
    }

    void OnCollisionEnter(Collision collision)
    {
        onGround = true;

        if (collision.gameObject.CompareTag("DoublePlat"))
        {
            if (type == TypeOfPlayer.PLAYER_ONE || type == TypeOfPlayer.PLAYER_TWO)
            {
                notMove = true;
            }

        }

        if (collision.gameObject.CompareTag("MP"))
        {
            if (type == TypeOfPlayer.PLAYER_ONE || type == TypeOfPlayer.PLAYER_TWO)
            {
                notMove = true;
            }
        }
    }

    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("DoublePlat")  )
        {
            if (type == TypeOfPlayer.PLAYER_ONE || type == TypeOfPlayer.PLAYER_TWO)
            {
                notMove = true;
            }
            
        }

        if (collision.gameObject.CompareTag("MP"))
        {
            if (type == TypeOfPlayer.PLAYER_ONE || type == TypeOfPlayer.PLAYER_TWO)
            {
                notMove = true;
            }
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("DoublePlat"))
        {
            if (type == TypeOfPlayer.PLAYER_ONE || type == TypeOfPlayer.PLAYER_TWO)
            {
                notMove = false;
            }
        }

        if (collision.gameObject.CompareTag("MP"))
        {
            if (type == TypeOfPlayer.PLAYER_ONE || type == TypeOfPlayer.PLAYER_TWO)
            {
                notMove = false;
            }
        }
    }

    void PlayerOneStatistics()
    {
        if (!editableRange)
        {
            speed = 50f;
            jumpSpeed = 10f;
        }
        meshRenderer.material = materials[0];
    }

    void PlayerTwoStatistics()
    {
        if (!editableRange)
        {
            speed = 40f;
        }
        meshRenderer.material = materials[1];
    }

    void AutoMove()
    {
        if (!notMove)
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
            speed = recSpeed;
        }
        else
        {
            speed = 0f;
        }

    }

    void Jumping()
    {
        if (Input.GetKeyDown(inputSO.jumpKey) && onGround)
        {
            m_rigidBody.AddForce(Vector3.up * jumpSpeed, ForceMode.Impulse);
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
                    Jumping();
                    break;
                case TypeOfPlayer.PLAYER_TWO:
                    PlayerTwoStatistics();
                    break;
            }
            yield return null;
        }
    }
}
