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
    bool onGround;
    #endregion

    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        m_rigidBody = GetComponent<Rigidbody>();
        recSpeed = speed;
        StartCoroutine(FSM());
    }

    void Update()
    {
        transform.position += Vector3.forward * Time.deltaTime * speed;
    }

    void OnCollisionEnter(Collision collision)
    {
        onGround = true;
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
