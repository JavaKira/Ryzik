using System;
using UnityEngine;

public class UIInput : MonoBehaviour
{
    [SerializeField] private Joystick joystick;
    [SerializeField] private GameObject inventory;
    [SerializeField] private GameObject pausePanel;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (inventory.activeSelf)
                CloseInventory();
            else
                OpenInventory();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Game.Instance.IsPause())
            {
                Game.Instance.Resume();
            }
            else
            {
                Game.Instance.Pause();
            }
            
            pausePanel.SetActive(!pausePanel.activeSelf);
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