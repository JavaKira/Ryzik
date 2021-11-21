using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private Image icon;

    public Item Item { get; private set; }

    public UnityEvent onSelected;

    private bool _selected;

    private void Start()
    {
        SetItem(Item.GetByName("Stick"));
    }

    private void SetItem(Item newItem)
    {
        Item = newItem;
        icon.color =  Item == null ? Color.clear : Color.white;
        if (Item != null) icon.sprite =  Item.Sprite;
    }
    
    public void OnPointerDown(PointerEventData eventData)
    {
        if (!_selected)
        {
            Select();
            return;
        }
        
        var cursor = Cursor.Instance;
        if (cursor == null) return;
        
        if (cursor.Empty())
        {
            cursor.SetItem(Item);
            SetItem(null);
        }
        else
        {
            SetItem(cursor.SelectedItem);
            cursor.SetItem(null);
        }
    }

    public bool Empty()
    {
        return Item == null;
    }

    private void Select()
    {
        _selected = true;
        onSelected.Invoke();
    }
}