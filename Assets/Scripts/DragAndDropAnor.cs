using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDropAnor : MonoBehaviour
{
    public GameObject correctForm;
    private bool moving;
    private float startPosX;
    private float startPosY;
    private Vector3 resetPosition;
    private int nilai;

    void Start()
    {
        resetPosition = this.transform.localPosition;
    }

    void Update()
    {
        if (moving)
        {
            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            this.transform.localPosition = new Vector3(mousePos.x - startPosX, mousePos.y - startPosY, this.transform.localPosition.z);
        }

        Debug.Log(nilai);
    }

    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            startPosX = mousePos.x - this.transform.localPosition.x;
            startPosY = mousePos.y - this.transform.localPosition.y;

            moving = true;
        }
    }

    private void OnMouseUp()
    {
        moving = false;

        float distanceToCorrectForm = Vector3.Distance(transform.localPosition, correctForm.transform.localPosition);

        if (distanceToCorrectForm <= 0.5f)
        {
            this.transform.localPosition = new Vector3(correctForm.transform.localPosition.x, correctForm.transform.localPosition.y, correctForm.transform.localPosition.z);
            Destroy(gameObject);
            nilai += 1;
        }
        else
        {
            this.transform.localPosition = new Vector3(resetPosition.x, resetPosition.y, resetPosition.z);
        }
    }
}
