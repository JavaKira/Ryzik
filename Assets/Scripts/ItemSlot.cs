using System;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    [SerializeField] private Image icon;

    private Item _item;

    private void Start()
    {
        SetItem(Item.GetByName("Air"));
    }

    private void SetItem(Item item)
    {
        _item = item;
        icon.sprite = item.Sprite;
    }
}