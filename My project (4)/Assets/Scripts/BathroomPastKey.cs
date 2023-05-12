using UnityEngine;

public class BathroomPastKey : MonoBehaviour
{
    public GameObject presentKey;
    private bool playerInRange = false;
    

    void Start()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entered the PastKeys collider.");
            playerInRange = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player exited the PastKeys collider.");
            playerInRange = false;
        }
    }

    void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            
            
            presentKey.SetActive(true);
            Debug.Log("You are not tall enough");

               
            
        }
    }
}