using Content;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace UI
{
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
                Select();
            }

            if (Selected) return;
            Select();
        }

        public void SetItem(Item newItem)
        {
            Item = newItem;
            icon.color = Item == null ? Color.clear : Color.white;
            if (Item != null) icon.sprite = Item.Icon;
        }

        public bool Empty()
        {
            return Item == null || Item == Item.GetByName("Air");
        }

        private void Select()
        {
            Selected = true;
            GetComponentInChildren<Image>().color = Color.gray;
            onSelected.Invoke();
        }

        public void Unselect()
        {
            Selected = false;
            GetComponentInChildren<Image>().color = Color.white;
        }
    }
}