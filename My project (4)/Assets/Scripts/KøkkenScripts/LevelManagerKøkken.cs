using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManagerKøkken : MonoBehaviour
{
    public string sceneName;
    public GameObject stairs;
    public PotScript pot;
    private bool playerInRange = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entered the stairs collider.");
            playerInRange = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player exited the stairs collider.");
            playerInRange = false;
        }
    }

    void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            if (PotScript.hasKey)
            {
                changeScene();
            }
        }
    }
    

    void changeScene()
    {
        SceneManager.LoadScene(sceneName);
    }

}
