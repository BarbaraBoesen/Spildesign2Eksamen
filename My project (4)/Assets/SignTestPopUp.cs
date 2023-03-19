using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignTestPopUp : MonoBehaviour
    
{
    public bool ReadingDistance;

// Start is called before the first frame update
void Start()
    {
        ReadingDistance = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && ReadingDistance == true)
        {
            Debug.Log("Smith Estate");
        }
       
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        ReadingDistance = true;
        Debug.Log("Press E");
    }
    void OnTriggerExit2D(Collider2D collider)
    {
        ReadingDistance = false;
    }
}
