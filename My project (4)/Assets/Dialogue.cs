using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float textSpeed;
    public bool ReadingDistance;
    private Canvas signCanvas;


    private int index;
    // Start is called before the first frame update
    void Start()
    {
        textComponent.text = string.Empty;
        ReadingDistance = false;
        signCanvas = transform.Find("Canvas").GetComponent<Canvas>();
        signCanvas.gameObject.SetActive(false);
    }

    // Update is called once per frame
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
