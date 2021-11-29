using System;
using Content;
using UnityEngine;

public class Cursor : MonoBehaviour
{
    public static Cursor Instance;
    
    private SpriteRenderer _spriteRenderer;
    private Camera _camera;
    private Item _selectedItem;
    
    public Item SelectedItem => _selectedItem;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _camera = Camera.main;
    }

    private void Update()
    {
        UpdatePosition();
    }

    private void UpdatePosition()
    {
        var mousePos = _camera.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        transform.position = mousePos;
    }

    public void SetItem(Item newItem)
    {
        _selectedItem = newItem;
        _spriteRenderer.sprite = newItem != null ? _selectedItem.Icon : null;
    }

    public bool Empty()
    {
        return _selectedItem == null;
    }
} 
