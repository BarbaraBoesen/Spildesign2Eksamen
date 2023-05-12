using UnityEngine;

public class BathroomKeyScript : MonoBehaviour
{
    public GameObject keyPrefab;
    public static bool hasFuseKey = false;
    private bool playerInRange = false;
    
    

    void Start()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entered the FuseKeys collider.");
            playerInRange = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player exited the FuseKeys collider.");
            playerInRange = false;
        }
    }

    void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            if (!hasFuseKey)
            {
                
                hasFuseKey = true;
                Debug.Log("You got the key!");
                Destroy(keyPrefab);

               
            }
        }
    }

   
}
