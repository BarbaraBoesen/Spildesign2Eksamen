using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogueScriptOptions : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public string[][] options;  // 2D array of options
    public string[][] responses;  // 2D array of responses corresponding to options
    public string[] characters;
    public float textSpeed;
    public bool ReadingDistance;
    public GameObject optionsPanel;
    public GameObject optionButtonPrefab;
    private Canvas signCanvas;
    public Sprite[] characterImages;

    private int index;
    private int characterIndex;

    void Start()
    {
        textComponent.text = string.Empty;
        ReadingDistance = false;
        signCanvas = transform.Find("Canvas").GetComponent<Canvas>();
        signCanvas.gameObject.SetActive(false);

        Image characterImageComponent = signCanvas.transform.Find("CharacterImage").GetComponent<Image>();
        characterImageComponent.sprite = characterImages[characterIndex];
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && ReadingDistance == true)
        {
            Debug.Log("Smith Estate");
            StartDialogue();
            signCanvas.gameObject.SetActive(!signCanvas.gameObject.activeSelf);
            ReadingDistance = false;
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (textComponent.text == lines[index])
            {
                ShowOptions();
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
        characterIndex = 0;
        StartCoroutine(TypeLine());
    }

    void ShowOptions()
    {
        optionsPanel.SetActive(true);

        for (int i = 0; i < options[index].Length; i++)
        {
            GameObject optionButton = Instantiate(optionButtonPrefab, optionsPanel.transform);
            optionButton.GetComponentInChildren<TextMeshProUGUI>().text = options[index][i];
            int choice = i;
            optionButton.GetComponent<Button>().onClick.AddListener(delegate { HandleChoice(choice); });
        }
    }

    void HandleChoice(int choice)
    {
        optionsPanel.SetActive(false);
        textComponent.text = responses[index][choice];
        StartCoroutine(WaitAndContinue());
    }

    IEnumerator WaitAndContinue()
    {
        yield return new WaitForSeconds(3f); // Wait for 3 seconds before proceeding to the next line
        NextLine();
    }

    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            characterIndex++;
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

    void OnTriggerEnter2D(Collider2D collider)
    {
        ReadingDistance = true;
        Debug.Log("Press E");
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        ReadingDistance = false;
    }
}
