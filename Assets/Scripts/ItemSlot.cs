using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private Image icon;

    private Item _item;

    private void Start()
    {
        SetItem(Item.GetByName("Stick"));
    }

    private void SetItem(Item newItem)
    {
        _item = newItem;
        icon.color =  _item == null ? Color.clear : Color.white;
        if (_item != null) icon.sprite =  _item.Sprite;
    }
    
    public void OnPointerDown(PointerEventData eventData)
    {
        var cursor = Cursor.Instance;
        if (cursor == null) return;
        
        if (cursor.Empty())
        {
            cursor.SetItem(_item);
            SetItem(null);
        }
        else
        {
            SetItem(cursor.SelectedItem);
            cursor.SetItem(null);
        }
    }
}