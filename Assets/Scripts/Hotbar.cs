using System;
using TMPro;
using UnityEngine;

public class Hotbar : MonoBehaviour
{
    private TMP_Text _itemNameText;
    private ItemSlot[] _slots;

    public ItemSlot SelectedSlot { get; set; }

    private void Start()
    {
        _itemNameText = GetComponentInChildren<TMP_Text>();
        _itemNameText.text = "";
        
        _slots = GetComponentsInChildren<ItemSlot>();

        foreach (var slot in _slots)
        {
            slot.onSelected.AddListener(() =>
            {
                SelectedSlot = slot;

                _itemNameText.SetText(!slot.Empty() ? slot.Item.name : "");

                foreach (var itemSlot in _slots)
                {
                    if (itemSlot != slot)
                        itemSlot.Unselect();
                }
            });
        }
    }
}