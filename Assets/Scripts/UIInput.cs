using System;
using UnityEngine;

public class UIInput : MonoBehaviour
{
    [SerializeField] private Joystick joystick;
    [SerializeField] private GameObject inventory;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (inventory.activeSelf)
                CloseInventory();
            else
                OpenInventory();
        }
    }

    public void OpenInventory()
    {
        inventory.SetActive(true);
        joystick.gameObject.SetActive(false);
    }

    public void CloseInventory()
    {
        inventory.SetActive(false);
        joystick.gameObject.SetActive(true);
    }
}