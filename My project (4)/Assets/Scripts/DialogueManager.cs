using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager instance; // static reference to the DialogueManager instance

    public Dialogue CurrentDialogue { get; private set; } // property to get the currently active dialogue

    void Awake()
    {
        // singleton pattern
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetActiveDialogue(Dialogue dialogue)
    {
        CurrentDialogue = dialogue;
    }
}

