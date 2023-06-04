using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class KommodeNutid2 : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public string[] characters; // Array of character names or identifiers
    public float textSpeed;
    public bool ReadingDistance;
    public string sceneToLoad;
    private Canvas signCanvas;

    public Sprite[] characterImages; // Array of character images corresponding to the characters array

    private int index;
    private int characterIndex; // Index to keep track of the current character speaking
    private bool isDialogueActive; // Flag to track if the dialogue is currently active

    void Start()
    {
        textComponent.text = string.Empty;
        ReadingDistance = false;
        signCanvas = transform.Find("Canvas").GetComponent<Canvas>();
        signCanvas.gameObject.SetActive(false);

        Image characterImageComponent = signCanvas.transform.Find("CharacterImage").GetComponent<Image>();
        characterImageComponent.sprite = characterImages[characterIndex];

        isDialogueActive = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && ReadingDistance == true)
        {
            if (isDialogueActive)
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
            else
            {
                StartDialogue();
            }
        }
    }

    public void StartDialogue()
    {
        index = 0;
        characterIndex = 0; // Start with the first character
        isDialogueActive = true;
        StartCoroutine(TypeLine());
        signCanvas.gameObject.SetActive(true);
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
            EndDialogue();
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
        if (!isDialogueActive)
        {
            signCanvas.gameObject.SetActive(false);
        }
    }

    void EndDialogue()
    {
        isDialogueActive = false;
        signCanvas.gameObject.SetActive(false);

        // Swap the scene to the desired scene
        SceneManager.LoadScene(sceneToLoad);
    }
}

