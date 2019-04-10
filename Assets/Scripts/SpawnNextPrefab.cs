using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnNextPrefab : MonoBehaviour
{
    #region PUBLIC
    public GameManager gameManager;
    public Transform spawner;
    public DestroyOldPrefab destroyer;
    #endregion

    #region PRIVATE
    bool spawn;
    #endregion

    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        destroyer.enabled = false;
    }

    void Update()
    {
        if (spawn)
        {
            Instantiate(gameManager.prefabs[Random.Range(0, gameManager.prefabs.Length)], spawner.position, spawner.rotation);
            Destroy(this);
            //gameManager.previousPrefab = gameObject.GetComponent<Transform>().parent.gameObject;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            spawn = true;
            destroyer.enabled = true;
        }
    }
}
