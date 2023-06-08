using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class TeleportPresent : MonoBehaviour
{
    public Transform presentTeleportLocation;
    public Collider2D teleportTrigger; // Reference to the trigger collider
    public Image fadeImage; // Reference to the fade image
    public float fadeDuration = 0.7f; // Duration of the fade effect in seconds


    private bool canTeleport; // Flag to track if teleportation is allowed

    void Start()
    {
        canTeleport = false; // Initialize the flag to false
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T) && canTeleport)
        {
            StartCoroutine(TeleportAndFade(presentTeleportLocation.position));
        }
    }

    IEnumerator TeleportAndFade(Vector2 destination)
    {
        yield return StartCoroutine(FadeImage(true)); // Fade in (to black)
        transform.position = destination;
        yield return new WaitForSeconds(1f);
        yield return StartCoroutine(FadeImage(false)); // Fade out (from black)
    }

    IEnumerator FadeImage(bool fadeIn)
    {
        float startAlpha = fadeIn ? 0 : 1;
        float endAlpha = fadeIn ? 1 : 0;
        float elapsedTime = 0;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            float newAlpha = Mathf.Lerp(startAlpha, endAlpha, elapsedTime / fadeDuration);
            fadeImage.color = new Color(fadeImage.color.r, fadeImage.color.g, fadeImage.color.b, newAlpha);
            yield return null;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other == teleportTrigger)
        {
            canTeleport = true; // Set the flag to true when entering the trigger
            Debug.Log("Entered teleport trigger");
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other == teleportTrigger)
        {
            canTeleport = false; // Set the flag to false when exiting the trigger
            Debug.Log("Exited teleport trigger");
        }
    }
}
