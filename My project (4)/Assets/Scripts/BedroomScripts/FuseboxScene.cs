using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FuseboxScene : MonoBehaviour
{
    public string sceneName;
    public GameObject FuseBox;
    private bool playerInRange = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entered the FuseBox collider.");
            playerInRange = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player exited the FuseBox collider.");
            playerInRange = false;
        }
    }

    
     void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            if (BathroomKeyScript.hasFuseKey)
            {
                changeScene();
            }
        }
        else
        {
            Debug.Log("You Need a Key");
        }

    }
    
       
    
    

    void changeScene()
    {
        SceneManager.LoadScene(sceneName);
    }

}
