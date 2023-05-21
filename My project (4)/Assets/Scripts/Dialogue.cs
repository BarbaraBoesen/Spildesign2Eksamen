using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float textSpeed;
    public bool ReadingDistance;
    private Canvas signCanvas;

    public Sprite character1Face;
    public Sprite character2Face;

    private int index;
    private bool isCharacter1Talking;

    void Start()
    {
        textComponent.text = string.Empty;
        ReadingDistance = false;
        signCanvas = transform.Find("Canvas").GetComponent<Canvas>();
        signCanvas.gameObject.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && ReadingDistance == true)
        {
            if (signCanvas.gameObject.activeSelf)
            {
                signCanvas.gameObject.SetActive(false);
                StopAllCoroutines();
            }
            else
            {
                StartDialogue();
                signCanvas.gameObject.SetActive(true);
            }
        }

        if (Input.GetKeyDown(KeyCode.E) && textComponent.text == lines[index])
        {
            NextLine();
        }
    }

    public void StartDialogue()
    {
        index = 0;
        isCharacter1Talking = true; // Start with character 1 talking
        StartCoroutine(TypeLine());
    }

    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            signCanvas.gameObject.SetActive(false);
        }
    }

    IEnumerator TypeLine()
    {
        Image characterFaceImage = signCanvas.transform.Find("CharacterFace").GetComponent<Image>();

        if (isCharacter1Talking)
        {
            characterFaceImage.sprite = character1Face;
            isCharacter1Talking = false;
        }
        else
        {
            characterFaceImage.sprite = character2Face;
            isCharacter1Talking = true;
        }

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
        if (signCanvas.gameObject.activeSelf)
        {
            signCanvas.gameObject.SetActive(false);
            StopAllCoroutines();
        }
    }
}
