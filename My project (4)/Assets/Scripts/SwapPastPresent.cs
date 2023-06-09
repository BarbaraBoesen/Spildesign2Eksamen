using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;

public class SwapPastPresent : MonoBehaviour
{
    public GameObject objectToDisable;
    public GameObject objectToEnable;
    public Image fadeImage;
    public CinemachineVirtualCamera vcam;
    public Transform newVcamTarget;
    public float fadeDuration = 0.7f;

    private bool canTeleport;

    void Start()
    {
        canTeleport = false;
    }

    void Update()
    {
        // Only check for teleportation if "T" is pressed and canTeleport flag is true
        if (Input.GetKeyDown(KeyCode.T) && canTeleport)
        {
            StartCoroutine(TeleportAndFade());
        }
    }

    IEnumerator TeleportAndFade()
    {
        AudioManager.instance.PlayClip(12, 0);
        yield return StartCoroutine(FadeImage(true));

        objectToDisable.SetActive(false);
        objectToEnable.SetActive(true);

        vcam.Follow = newVcamTarget;

        yield return new WaitForSeconds(1f);
        yield return StartCoroutine(FadeImage(false));
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
        if (other.gameObject.CompareTag("Player"))
        {
            canTeleport = true;
            Debug.Log("Entered teleport trigger");
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            canTeleport = false;
            Debug.Log("Exited teleport trigger");
        }
    }
}

