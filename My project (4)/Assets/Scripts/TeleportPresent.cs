using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TeleportPresent : MonoBehaviour
{
    public Transform presentTeleportLocation;
    public Collider2D teleportTrigger; // Reference to the trigger collider

    private bool canTeleport; // Flag to track if teleportation is allowed

    void Start()
    {
        canTeleport = false; // Initialize the flag to false
    }

    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.T) && canTeleport)
        {
            // Teleport to the present location
            Teleport(presentTeleportLocation.position);
        }
    }

    public void Teleport(Vector2 destination)
    {
        transform.position = destination;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other == teleportTrigger)
        {
            canTeleport = true; // Set the flag to true when entering the trigger
            Debug.Log("Entered teleport trigger");
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other == teleportTrigger)
        {
            canTeleport = false; // Set the flag to false when exiting the trigger
            Debug.Log("Exited teleport trigger");
        }
    }
}
