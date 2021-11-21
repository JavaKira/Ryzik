using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private Image icon;

    public UnityEvent onSelected;

    public Item Item { get; private set; }
    private bool Selected { get; set; }

    private void Awake()
    {
        SetItem(Item.GetByName("Air"));
    }

    public virtual void OnPointerDown(PointerEventData eventData)
    {
        if (!Selected)
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
        else if (Empty())
        {
            SetItem(cursor.SelectedItem);
            cursor.SetItem(null);
        }
    }

    public void SetItem(Item newItem)
    {
        Item = newItem;
        icon.color = Item == null ? Color.clear : Color.white;
        if (Item != null) icon.sprite = Item.Sprite;
    }

    public bool Empty()
    {
        return Item == null || Item == Item.GetByName("Air");
    }

    private void Select()
    {
        Selected = true;
        onSelected.Invoke();
    }
}