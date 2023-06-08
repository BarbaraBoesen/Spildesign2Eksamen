using UnityEngine;
using UnityEngine.UI;

public class ButtonHandler : MonoBehaviour
{
    public Button positiveButton;
    public Button negativeButton;
    public Dialogue dialogue; // Reference to the Dialogue script

    void Start()
    {
        positiveButton.onClick.AddListener(() => HandleClick(true));
        negativeButton.onClick.AddListener(() => HandleClick(false));

        //Initially set the buttons to be not visible
        positiveButton.gameObject.SetActive(false);
        negativeButton.gameObject.SetActive(false);
    }

    public void ShowButtons(bool show)
    {
        positiveButton.gameObject.SetActive(show);
        negativeButton.gameObject.SetActive(show);
    }

    public void HandleClick(bool decision)
    {
        // Send decision to Dialogue 
        dialogue.MakeDecision(decision);
        Debug.Log("Du har klikket");
        AudioManager.instance.PlayClip(1, 0);

        // Check if button is active before disabling it
        if (positiveButton.IsActive() || negativeButton.IsActive())
        {
            // Hide the buttons after click
            ShowButtons(false);
        }
    }
}
