using UnityEngine;

public class PotScript : MonoBehaviour
{
    public GameObject keyPrefab;
    public static bool hasKey = false;
    private bool playerInRange = false;
    private GameObject levelManager;

    void Start()
    {
        levelManager = GameObject.FindGameObjectWithTag("LevelManager");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entered the pot's collider.");
            playerInRange = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player exited the pot's collider.");
            playerInRange = false;
        }
    }

    void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            if (!hasKey)
            {
                Instantiate(keyPrefab, transform.position, Quaternion.identity, transform.parent);
                hasKey = true;
                Debug.Log("You got the key!");

                if (levelManager != null)
                {
                    levelManager.SendMessage("SetHasKey", true);
                }
            }
        }
    }
}
