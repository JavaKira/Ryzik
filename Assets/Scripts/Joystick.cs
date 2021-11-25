using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Joystick : MonoBehaviour, IDragHandler, IEndDragHandler, IPointerUpHandler, IPointerDownHandler
{
    [SerializeField] private GameObject cursor;

    private int _touchID = -1;
    
    public GameObject Cursor
    {
        get => cursor;
    }

    private void ClearCursor()
    {
        _touchID = -1;
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
        var position = Input.GetTouch(_touchID).position;
        Vector3 mousePosition =
            new Vector3(position.x, position.y) - Camera.main.WorldToScreenPoint(transform.position);

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

    public void OnPointerDown(PointerEventData eventData)
    {
        if (_touchID == -1)
            _touchID = Input.touchCount - 1;
    }
}
