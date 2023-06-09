
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Tallerkner : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public string[] characters; // Array of character names or identifiers
    public float textSpeed;
    public bool ReadingDistance;
    private Canvas signCanvas;
    public GameObject objectToDestroy;

    public Sprite[] characterImages; // Array of character images corresponding to the characters array

    private int index;
    private int characterIndex; // Index to keep track of the current character speaking
    private bool hasInteracted; // Flag to track the first interaction

    void Start()
    {
        textComponent.text = string.Empty;
        ReadingDistance = false;
        signCanvas = transform.Find("Canvas").GetComponent<Canvas>();
        signCanvas.gameObject.SetActive(false);

        Image characterImageComponent = signCanvas.transform.Find("CharacterImage").GetComponent<Image>();
        characterImageComponent.sprite = characterImages[characterIndex];
        hasInteracted = false; // Initialize the flag to false
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && ReadingDistance == true)
        {
            if (!hasInteracted) // Check if the first interaction has occurred
            {
                Debug.Log("Smith Estate");
                StartDialogue();
                hasInteracted = true; // Set the flag to true after the first interaction

            }
            signCanvas.gameObject.SetActive(!signCanvas.gameObject.activeSelf);
            ReadingDistance = false;
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (textComponent.text == lines[index])
            {
                NextLine();

            }
            else
            {
                StopAllCoroutines();
                textComponent.text = lines[index];
            }
        }
    }

    public void StartDialogue()
    {
        index = 0;
        characterIndex = 0; // Start with the first character
        StartCoroutine(TypeLine());
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
            if (hasInteracted)
            {
                DestroyObject();
            }

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

    void OnTriggerEnter2D(Collider2D collider)
    {
        ReadingDistance = true;
        Debug.Log("Press E");
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        ReadingDistance = false;
    }
    private void DestroyObject()
    {

        Destroy(objectToDestroy);

    }
}

