using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuPanelBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject middlePanel;
    
    public void PlayButton()
    {
        middlePanel.SetActive(true);
    }
}