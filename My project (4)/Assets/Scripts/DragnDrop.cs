using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragnDrop : MonoBehaviour
{
    public GameObject correctForm;
    private bool moving;
    private bool finish;

    private float StartPosX;
    private float StartPosY;

    private Vector3 resetPosition;


    void Start()
    {
        resetPosition = this.transform.localPosition;
    }


    void Update()
    {

        if (finish == false)
        {
            if (moving)
            {
                Vector3 mousePos;
                mousePos = Input.mousePosition;
                mousePos = Camera.main.ScreenToWorldPoint(mousePos);

                this.gameObject.transform.localPosition = new Vector3(mousePos.x - StartPosX, mousePos.y - StartPosY, this.gameObject.transform.localPosition.z);
            }
        }


    }

    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            StartPosX = mousePos.x - this.transform.localPosition.x;
            StartPosY = mousePos.y - this.transform.localPosition.y;

            moving = true;

        }
    }


    private void OnMouseUp()
    {
        moving = false;

        if (Mathf.Abs(this.transform.localPosition.x - correctForm.transform.localPosition.x) <= 0.5f &&
            Mathf.Abs(this.transform.localPosition.y - correctForm.transform.localPosition.y) <= 0.5f)
        {
            this.transform.position = new Vector3(correctForm.transform.position.x, correctForm.transform.position.y, correctForm.transform.position.z);
            finish = true;

            GameObject.Find("PointsHandler").GetComponent<WinScript>().AddPoints();
        }
        else
        {
            this.transform.localPosition = new Vector3(resetPosition.x, resetPosition.y, resetPosition.z);
        }
    }

}


