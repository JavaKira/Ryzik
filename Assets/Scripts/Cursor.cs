using UnityEngine;

public class Cursor : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;
    private Camera _camera;
    private Item _selectedItem;
    
    public Item SelectedItem => _selectedItem;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _camera = Camera.main;
    }

    void Update()
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
        _spriteRenderer.sprite = newItem != null ? _selectedItem.Sprite : null;
    }

    public bool Empty()
    {
        return _selectedItem == null;
    }
} 
