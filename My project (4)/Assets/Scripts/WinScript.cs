using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScript : MonoBehaviour
{
    public int pointsToWin;
    private int currentPoints;
    public GameObject Fuses;
    public string sceneName; // Start is called before the first frame update
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (currentPoints >= pointsToWin)
        {
            
            SceneManager.LoadScene(sceneName);

        }
    }

    public void AddPoints()
    {
        currentPoints++;
        Debug.Log("Works");
    }
}
