using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDragAndDrop : MonoBehaviour
{
    public float distance = 10f;
    public string tagToDrag = "CupObject";

    private Vector3 screenPoint;
    private Vector3 offset;
    private bool isDragging = false;


    void OnMouseDown()
    {
        if (Input.GetMouseButton(0))
        {
            RaycastHit[] hits;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            hits = Physics.RaycastAll(ray, Mathf.Infinity);
            foreach (RaycastHit hit in hits)
            {
                if (hit.collider.CompareTag(tagToDrag))
                {
                    Debug.Log("오브젝트 클릭");
                    screenPoint = Camera.main.WorldToScreenPoint(hit.collider.gameObject.transform.position);
                    offset = hit.collider.gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
                    isDragging = true;
                    break;
                }
            }
        }
    }

    void OnMouseDrag()
    {
        if (isDragging)
        {
            Vector3 cursorPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
            Vector3 cursorPosition = Camera.main.ScreenToWorldPoint(cursorPoint) + offset;
            cursorPosition.y = Mathf.Max(cursorPosition.y, 0f);
            transform.position = cursorPosition;
        }
    }

    void OnMouseUp()
    {
        isDragging = false;
    }
}
