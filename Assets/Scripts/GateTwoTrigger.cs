using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateTwoTrigger : MonoBehaviour
{
    public GameManager gameManager;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            gameManager.CheckpointReached();
        }
    }}
