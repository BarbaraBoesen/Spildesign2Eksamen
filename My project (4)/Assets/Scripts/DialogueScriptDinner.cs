using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public List<string> currentLines;
    public string[] characters;
    public float textSpeed;
    public bool ReadingDistance;
    private Canvas signCanvas;
    public bool isReading;
    public Decision[] decisions;
    private int currentDecisionIndex;


    public ButtonHandler buttonHandler; // Reference to the new ButtonHandler script

    public Sprite[] characterImages;

    private int index;
    private int characterIndex;



    void Start()
    {
        textComponent.text = string.Empty;
        currentLines = new List<string>(lines);

        signCanvas = transform.Find("Canvas").GetComponent<Canvas>();
        signCanvas.gameObject.SetActive(false);

        Image characterImageComponent = signCanvas.transform.Find("CharacterImage").GetComponent<Image>();
        characterImageComponent.sprite = characterImages[characterIndex];
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (ReadingDistance && !isReading) // Start reading only if player is in reading distance and not already reading
            {

                Debug.Log("Smith Estate");
                StartDialogue();
                AudioManager.instance.PlayClip(0, 0);
                signCanvas.gameObject.SetActive(true);
                ReadingDistance = false;
            }
            else if (isReading) // If reading, proceed with dialogue
            {
                if (textComponent.text == currentLines[index])
                {
                    NextLine();
                    AudioManager.instance.PlayClip(0, 0);
                }
                else
                {
                    StopAllCoroutines();
                    textComponent.text = currentLines[index];
                }
            }
        }
    }

    public void StartDialogue()
    {
        DialogueManager.instance.SetActiveDialogue(this);
        isReading = true;
        index = 0; // Reset the line index
        characterIndex = 0; // Reset the character index
        textComponent.text = string.Empty; // Clear the current line
        currentLines = new List<string>(lines); // Reset the current lines back to the original lines
        StartCoroutine(TypeLine());
    }

    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            characterIndex = (characterIndex + 1) % characters.Length; // Cycle through characters

            // Decision handling
            currentDecisionIndex = Array.FindIndex(decisions, d => d.question == currentLines[index]);
            if (decisions.Length > 0 && currentDecisionIndex >= 0)
            {
                buttonHandler.ShowButtons(true);
            }
            else
            {
                buttonHandler.ShowButtons(false);
            }

            Image characterImageComponent = signCanvas.transform.Find("CharacterImage").GetComponent<Image>();
            characterImageComponent.sprite = characterImages[characterIndex];
        }
        else
        {
            index = 0; // Reset the line index
            characterIndex = 0; // Reset the character index
            signCanvas.gameObject.SetActive(false);
            isReading = false;
            DialogueManager.instance.SetActiveDialogue(null);
        }
        StartCoroutine(TypeLine()); // Moved outside the if-else structure
    }




    IEnumerator TypeLine()
    {
        foreach (char c in currentLines[index].ToCharArray())
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
    [System.Serializable]
    public class Decision
    {
        public string question; // The decision prompt
        public string positiveOutcome; // The outcome for choosing "yes"
        public string negativeOutcome; // The outcome for choosing "no"
    }


    public void MakeDecision(bool decision)
    {
        MakeDecision(currentDecisionIndex, decision);
    }

    void MakeDecision(int decisionIndex, bool decision)
    {
        if (decisionIndex >= 0)
        {
            currentLines[index] = decision ? decisions[decisionIndex].positiveOutcome : decisions[decisionIndex].negativeOutcome;

            buttonHandler.ShowButtons(false);

            // Continue the dialogue with the outcome
            textComponent.text = string.Empty;
            StopAllCoroutines(); // stop the current coroutine
            StartCoroutine(TypeLine());
        }
    }




}
