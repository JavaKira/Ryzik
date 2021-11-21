using System;
using TMPro;
using UnityEngine;

public class Hotbar : MonoBehaviour
{
    private TMP_Text _itemNameText;
    private ItemSlot[] _slots;

    private void Start()
    {
        _itemNameText = GetComponentInChildren<TMP_Text>();
        _slots = GetComponentsInChildren<ItemSlot>();

        foreach (var slot in _slots)
        {
            slot.onSelected.AddListener(() =>
            {
                if (!slot.Empty()) 
                    _itemNameText.SetText(slot.Item.name);
            });
        }
    }
}