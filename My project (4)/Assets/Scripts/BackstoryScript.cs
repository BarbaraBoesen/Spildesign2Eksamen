using UnityEngine;
using UnityEngine.UI;

public class BackstoryScript : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite[] images;
    private int currentIndex = 0;

    public Button startButton;
    public float fadeDuration = 1f;
    private float currentFadeTime = 0f;
    private bool fadingIn = false;

    private bool lastImageShown = false;
    private bool buttonAppeared = false;

    void Start()
    {
        ShowImage(currentIndex);
        startButton.gameObject.SetActive(false); // Hide the start button initially
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            if (!buttonAppeared)
            {
                if (lastImageShown)
                {
                    FadeInStartButton();
                    buttonAppeared = true;
                }
                else
                {
                    ShowNextImage();
                }
            }
        }

        // Fade in the start button
        if (fadingIn)
        {
            currentFadeTime += Time.deltaTime;
            float alpha = Mathf.Clamp01(currentFadeTime / fadeDuration);
            Color buttonColor = startButton.image.color;
            buttonColor.a = alpha;
            startButton.image.color = buttonColor;
        }
    }

    void ShowNextImage()
    {
        if (currentIndex < images.Length - 1)
        {
            currentIndex++;
            ShowImage(currentIndex);
        }
        else
        {
            // Last image is shown. Set the flags.
            lastImageShown = true;
            buttonAppeared = true;
            FadeInStartButton();
        }
    }

    void ShowImage(int index)
    {
        if (index < images.Length)
        {
            spriteRenderer.sprite = images[index];
        }
    }

    void FadeInStartButton()
    {
        fadingIn = true;
        currentFadeTime = 0f;
        startButton.gameObject.SetActive(true); // Show the start button
        Color buttonColor = startButton.image.color;
        buttonColor.a = 0f;
        startButton.image.color = buttonColor;
    }
}














