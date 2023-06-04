using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Stue"); // Replace "GameScene" with the name of your game scene
    }

    public void OpenOptions()
    {
        // Add code here to open options menu or scene
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}