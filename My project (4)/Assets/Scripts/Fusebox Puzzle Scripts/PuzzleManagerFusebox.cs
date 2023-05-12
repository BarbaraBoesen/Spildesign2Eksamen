using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleManagerFusebox : MonoBehaviour
{
    public GameObject[] puzzlePieces; // array of puzzle pieces
    public GameObject[] correctForms; // array of correct forms

    private int numCorrect; // number of pieces in the correct form

    void Start()
    {
        numCorrect = 0;
    }

    public void CheckPuzzle()
    {
        numCorrect = 0;
        for (int i = 0; i < puzzlePieces.Length; i++)
        {
            for (int j = 0; j < correctForms.Length; j++)
            {
                if (puzzlePieces[i].transform.position == correctForms[j].transform.position)
                {
                    numCorrect++;
                    Debug.Log("Correct+1");
                    break;
                }
            }
        }

        if (numCorrect == puzzlePieces.Length)
        {
            Debug.Log("Puzzle complete!");
        }
    }
}