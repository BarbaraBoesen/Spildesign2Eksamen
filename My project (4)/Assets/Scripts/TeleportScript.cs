using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class TeleportScript : MonoBehaviour
{
    public Transform presentTeleportLocation;
    public Transform pastTeleportLocation;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            // Teleport to the past location
            Teleport(pastTeleportLocation.position);
        }
        else if (Input.GetKeyDown(KeyCode.P))
        {
            // Teleport to the present location
            Teleport(presentTeleportLocation.position);
        }
    }

    public void Teleport(Vector2 destination)
    {
        transform.position = destination;
    }
}