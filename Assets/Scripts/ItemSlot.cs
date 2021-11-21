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

    private void Start()
    {
        SetItem(Item.GetByName("Stick"));
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
        else 
        {
            SetItem(cursor.SelectedItem);
            cursor.SetItem(null);
        }
    }

    private void SetItem(Item newItem)
    {
        Item = newItem;
        icon.color = Item == null ? Color.clear : Color.white;
        if (Item != null) icon.sprite = Item.Sprite;
    }

    public bool Empty()
    {
        return Item == null;
    }

    private void Select()
    {
        Selected = true;
        onSelected.Invoke();
    }
}