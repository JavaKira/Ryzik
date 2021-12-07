using UnityEngine;

namespace UI
{
    public class UIInput : MonoBehaviour
    {
        [SerializeField] private Joystick.Joystick joystick;
        [SerializeField] private GameObject inventory;

        private void Update()
        {
            if (!Input.GetKeyDown(KeyCode.E)) return;
            
            if (inventory.activeSelf)
                CloseInventory();
            else
                OpenInventory();
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
}