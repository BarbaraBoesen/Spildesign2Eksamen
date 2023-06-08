using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Stue2EnterDialogue : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public string[] characters; // Array of character names or identifiers
    public float textSpeed;
    private Canvas signCanvas;

    public Sprite[] characterImages; // Array of character images corresponding to the characters array

    private int index;
    private int characterIndex; // Index to keep track of the current character speaking

    private bool dialogueTriggered = false; // Flag to track if the dialogue has been triggered

    void Start()
    {
        textComponent.text = string.Empty;
        signCanvas = transform.Find("Canvas").GetComponent<Canvas>();
        signCanvas.gameObject.SetActive(false);

        Image characterImageComponent = signCanvas.transform.Find("CharacterImage").GetComponent<Image>();
        characterImageComponent.sprite = characterImages[characterIndex];

        SceneManager.sceneLoaded += OnSceneLoaded; // Subscribe to the sceneLoaded event
    }

    void Update()
    {
        if (dialogueTriggered && Input.GetKeyDown(KeyCode.E))
        {
            NextLine();
        }
    }

    public void StartDialogue()
    {
        index = 0;
        characterIndex = 0; // Start with the first character
        StartCoroutine(TypeLine());
        dialogueTriggered = true;
    }

    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            characterIndex++; // Move to the next character

            // If the character index exceeds the number of characters available, reset it to 0
            if (characterIndex >= characters.Length)
            {
                characterIndex = 0;
            }

            Image characterImageComponent = signCanvas.transform.Find("CharacterImage").GetComponent<Image>();
            characterImageComponent.sprite = characterImages[characterIndex];

            StartCoroutine(TypeLine());
        }
        else
        {
            signCanvas.gameObject.SetActive(false);
        }
    }

    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    // Callback method when a new scene is loaded
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        StartDialogue();
    }
}
