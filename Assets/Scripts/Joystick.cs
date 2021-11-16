using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Joystick : MonoBehaviour, IDragHandler, IEndDragHandler, IPointerUpHandler
{
    [SerializeField] private GameObject cursor;

    public GameObject Cursor
    {
        get => cursor;
    }

    private void ClearCursor()
    {
        ((RectTransform)cursor.transform).localPosition = new Vector3(0, 0, 0);
    }

    private void SetCursorPosition(float x, float y)
    {
        float rad = ((RectTransform) transform).sizeDelta.x / 2;
        float curX, curY;

        float dx = x;
        float dy = y;
        
        float lenght = Mathf.Sqrt(dx * dx + dy * dy);
        if (lenght < rad) {
            curX = dx;
            curY = dy;
        } else {
            float k = rad / lenght; 
            curX = dx * k;
            curY = dy * k;
        }

        ((RectTransform) cursor.transform).localPosition = new Vector2(curX, curY);
    }

    public Vector2 GetNormalized()
    {
        return ((RectTransform) cursor.transform).anchoredPosition.normalized;
    }

    public Vector2 GetRelativeCursorPosition()
    {
        return cursor.transform.position - transform.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector3 mousePosition = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);

        SetCursorPosition(mousePosition.x,
            mousePosition.y);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        ClearCursor();
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        ClearCursor();
    }
}
