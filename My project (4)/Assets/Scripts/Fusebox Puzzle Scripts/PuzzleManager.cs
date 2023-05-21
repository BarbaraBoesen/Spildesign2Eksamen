using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    public GameObject[] fuses;
    public GameObject[] slots;

    private bool moving;
    private bool finish;
    private Vector3[] resetPositions;

    private void Start()
    {
        resetPositions = new Vector3[fuses.Length];
        for (int i = 0; i < fuses.Length; i++)
        {
            resetPositions[i] = fuses[i].transform.localPosition;
        }
    }

    private void Update()
    {
        if (!finish && moving)
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);
            transform.localPosition = new Vector3(mousePos.x, mousePos.y, transform.localPosition.z);
        }
    }

    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            moving = true;
        }
    }

    private void OnMouseUp()
    {
        moving = false;
        bool inCorrectSlot = false;

        for (int i = 0; i < slots.Length; i++)
        {
            if (Mathf.Abs(transform.position.x - slots[i].transform.position.x) <= 0.5f &&
                Mathf.Abs(transform.position.y - slots[i].transform.position.y) <= 0.5f)
            {
                transform.position = new Vector3(slots[i].transform.position.x, slots[i].transform.position.y, slots[i].transform.position.z);
                inCorrectSlot = true;
                break;
            }
        }

        if (inCorrectSlot)
        {
            bool allFusesInCorrectSlots = true;

            for (int i = 0; i < fuses.Length; i++)
            {
                if (!IsFuseInCorrectSlot(fuses[i], slots[i]))
                {
                    allFusesInCorrectSlots = false;
                    break;
                }
            }

            if (allFusesInCorrectSlots)
            {
                finish = true;
                Debug.Log("Puzzle complete!");
                // Add your code for completing the puzzle here
            }
        }
        else
        {
            for (int i = 0; i < fuses.Length; i++)
            {
                fuses[i].transform.localPosition = resetPositions[i];
            }
        }
    }

    private bool IsFuseInCorrectSlot(GameObject fuse, GameObject slot)
    {
        return Mathf.Abs(fuse.transform.position.x - slot.transform.position.x) <= 0.5f &&
               Mathf.Abs(fuse.transform.position.y - slot.transform.position.y) <= 0.5f;
    }
}

