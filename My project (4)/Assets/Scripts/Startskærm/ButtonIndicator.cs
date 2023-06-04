using UnityEngine;
using UnityEngine.UI;

public class ButtonIndicator : MonoBehaviour
{
    public GameObject indicatorObject;
    private Image indicatorImage;

    private void Start()
    {
        // Get the Image component from the indicator object
        indicatorImage = indicatorObject.GetComponent<Image>();

        // Hide the indicator initially
        indicatorImage.enabled = false;
    }

    private void OnMouseEnter()
    {
        // Show the indicator when the mouse enters the button
        indicatorImage.enabled = true;
    }

    private void OnMouseExit()
    {
        // Hide the indicator when the mouse exits the button
        indicatorImage.enabled = false;
    }
}