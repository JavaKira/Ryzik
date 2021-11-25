using UnityEngine;
using UnityEngine.SceneManagement;

public class PausePanel : MonoBehaviour
{
    public void OpenMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}